using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Mvx.ApiClient.Net.Test;

internal static class PublicApiSnapshot
{
    private static readonly NullabilityInfoContext NullabilityContext = new();

    public static string[] Create(Assembly assembly)
    {
        var lines = new List<string>();

        foreach (var type in assembly.GetExportedTypes().OrderBy(type => type.FullName, StringComparer.Ordinal))
        {
            lines.Add(FormatTypeDeclaration(type));

            var members = new List<string>();
            members.AddRange(type.GetConstructors(DeclaredPublicMembers).Select(FormatConstructor));
            members.AddRange(type.GetFields(DeclaredPublicMembers)
                .Where(field => field.Name != "value__")
                .Select(FormatField));
            members.AddRange(type.GetProperties(DeclaredPublicMembers).Select(FormatProperty));
            members.AddRange(type.GetEvents(DeclaredPublicMembers).Select(FormatEvent));
            members.AddRange(type.GetMethods(DeclaredPublicMembers)
                .Where(method => !method.IsSpecialName || method.Name.StartsWith("op_", StringComparison.Ordinal))
                .Select(FormatMethod));

            lines.AddRange(members.Order(StringComparer.Ordinal).Select(member => $"  {member}"));
        }

        return lines.ToArray();
    }

    private static string FormatTypeDeclaration(Type type)
    {
        var kind = type.IsEnum
            ? "enum"
            : type.IsInterface
                ? "interface"
                : type.IsValueType
                    ? "struct"
                    : typeof(MulticastDelegate).IsAssignableFrom(type.BaseType)
                        ? "delegate"
                        : "class";
        var modifiers = new List<string>();

        if (type.IsAbstract && type.IsSealed)
        {
            modifiers.Add("static");
        }
        else
        {
            if (type.IsAbstract && !type.IsInterface)
            {
                modifiers.Add("abstract");
            }

            if (type.IsSealed && !type.IsValueType && kind != "delegate")
            {
                modifiers.Add("sealed");
            }
        }

        var inheritance = new List<string>();
        if (type.BaseType is not null
            && type.BaseType != typeof(object)
            && type.BaseType != typeof(ValueType)
            && type.BaseType != typeof(Enum)
            && type.BaseType != typeof(MulticastDelegate))
        {
            inheritance.Add(FormatTypeName(type.BaseType));
        }

        inheritance.AddRange(type.GetInterfaces().Select(interfaceType => FormatTypeName(interfaceType)).Order(StringComparer.Ordinal));

        return string.Join(' ', new[]
        {
            "type",
            string.Join(' ', modifiers),
            kind,
            FormatTypeName(type),
            inheritance.Count == 0 ? string.Empty : $": {string.Join(", ", inheritance)}",
            FormatObsolete(type)
        }.Where(value => !string.IsNullOrEmpty(value)));
    }

    private static string FormatConstructor(ConstructorInfo constructor)
    {
        return $"ctor {FormatParameters(constructor.GetParameters())}{FormatObsolete(constructor)}";
    }

    private static string FormatField(FieldInfo field)
    {
        var modifiers = new List<string>();
        if (field.IsLiteral)
        {
            modifiers.Add("const");
        }
        else
        {
            if (field.IsStatic)
            {
                modifiers.Add("static");
            }

            if (field.IsInitOnly)
            {
                modifiers.Add("readonly");
            }
        }

        var value = field.IsLiteral ? $" = {FormatDefaultValue(field.GetRawConstantValue(), field.FieldType)}" : string.Empty;

        return $"field {string.Join(' ', modifiers)} {FormatTypeName(field.FieldType, NullabilityContext.Create(field))} {field.Name}{value}{FormatObsolete(field)}";
    }

    private static string FormatProperty(PropertyInfo property)
    {
        var accessors = new List<string>();
        if (property.GetMethod?.IsPublic == true)
        {
            accessors.Add("get");
        }

        if (property.SetMethod?.IsPublic == true)
        {
            var isInit = property.SetMethod.ReturnParameter
                .GetRequiredCustomModifiers()
                .Contains(typeof(IsExternalInit));
            accessors.Add(isInit ? "init" : "set");
        }

        var indexParameters = property.GetIndexParameters();
        var name = indexParameters.Length == 0 ? property.Name : $"this{FormatParameters(indexParameters)}";
        var isStatic = property.GetMethod?.IsStatic == true || property.SetMethod?.IsStatic == true ? "static " : string.Empty;

        return $"property {isStatic}{FormatTypeName(property.PropertyType, NullabilityContext.Create(property))} {name} {{ {string.Join("; ", accessors)}; }}{FormatObsolete(property)}";
    }

    private static string FormatEvent(EventInfo eventInfo)
    {
        var isStatic = eventInfo.AddMethod?.IsStatic == true ? "static " : string.Empty;
        var eventType = eventInfo.EventHandlerType is null
            ? "unknown"
            : FormatTypeName(eventInfo.EventHandlerType, NullabilityContext.Create(eventInfo));

        return $"event {isStatic}{eventType} {eventInfo.Name}{FormatObsolete(eventInfo)}";
    }

    private static string FormatMethod(MethodInfo method)
    {
        var modifiers = new List<string>();
        if (method.IsStatic)
        {
            modifiers.Add("static");
        }

        if (method.IsAbstract)
        {
            modifiers.Add("abstract");
        }
        else if (method.IsVirtual && method.GetBaseDefinition() == method)
        {
            modifiers.Add("virtual");
        }
        else if (method.GetBaseDefinition() != method)
        {
            modifiers.Add("override");
        }

        var genericArguments = method.IsGenericMethodDefinition
            ? $"<{string.Join(", ", method.GetGenericArguments().Select(argument => argument.Name))}>"
            : string.Empty;
        var constraints = method.IsGenericMethodDefinition
            ? string.Concat(method.GetGenericArguments().Select(FormatGenericConstraints))
            : string.Empty;
        var returnType = FormatTypeName(method.ReturnType, NullabilityContext.Create(method.ReturnParameter));

        return $"method {string.Join(' ', modifiers)} {returnType} {method.Name}{genericArguments}{FormatParameters(method.GetParameters())}{constraints}{FormatObsolete(method)}";
    }

    private static string FormatParameters(IReadOnlyList<ParameterInfo> parameters)
    {
        return $"({string.Join(", ", parameters.Select(FormatParameter))})";
    }

    private static string FormatParameter(ParameterInfo parameter)
    {
        var modifier = parameter.GetCustomAttribute<ParamArrayAttribute>() is not null
            ? "params "
            : parameter.IsOut
                ? "out "
                : parameter.ParameterType.IsByRef && parameter.IsIn
                    ? "in "
                    : parameter.ParameterType.IsByRef
                        ? "ref "
                        : string.Empty;
        var type = parameter.ParameterType.IsByRef ? parameter.ParameterType.GetElementType()! : parameter.ParameterType;
        var defaultValue = parameter.HasDefaultValue
            ? $" = {FormatDefaultValue(parameter.DefaultValue, type)}"
            : string.Empty;

        return $"{modifier}{FormatTypeName(type, NullabilityContext.Create(parameter))} {parameter.Name}{defaultValue}";
    }

    private static string FormatGenericConstraints(Type genericArgument)
    {
        var constraints = new List<string>();
        var attributes = genericArgument.GenericParameterAttributes;

        if ((attributes & GenericParameterAttributes.ReferenceTypeConstraint) != 0)
        {
            constraints.Add("class");
        }

        if ((attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0)
        {
            constraints.Add("struct");
        }

        constraints.AddRange(genericArgument.GetGenericParameterConstraints().Select(constraint => FormatTypeName(constraint)));

        if ((attributes & GenericParameterAttributes.DefaultConstructorConstraint) != 0
            && (attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == 0)
        {
            constraints.Add("new()");
        }

        return constraints.Count == 0 ? string.Empty : $" where {genericArgument.Name} : {string.Join(", ", constraints)}";
    }

    private static string FormatTypeName(Type type, NullabilityInfo? nullability = null)
    {
        if (type == typeof(void))
        {
            return "void";
        }

        if (type.IsGenericParameter)
        {
            return type.Name;
        }

        var nullableUnderlyingType = Nullable.GetUnderlyingType(type);
        if (nullableUnderlyingType is not null)
        {
            return $"{FormatTypeName(nullableUnderlyingType, nullability?.GenericTypeArguments.FirstOrDefault())}?";
        }

        if (type.IsArray)
        {
            var arrayName = $"{FormatTypeName(type.GetElementType()!, nullability?.ElementType)}[{new string(',', type.GetArrayRank() - 1)}]";
            return AppendNullableAnnotation(arrayName, type, nullability);
        }

        var alias = GetAlias(type);
        var name = alias ?? GetNamedType(type);

        if (type.IsGenericType)
        {
            var genericArguments = type.GetGenericArguments();
            var nullabilityArguments = nullability?.GenericTypeArguments ?? [];
            var formattedArguments = genericArguments.Select((argument, index) =>
                FormatTypeName(argument, index < nullabilityArguments.Length ? nullabilityArguments[index] : null));
            name = $"{name}<{string.Join(", ", formattedArguments)}>";
        }

        return AppendNullableAnnotation(name, type, nullability);
    }

    private static string GetNamedType(Type type)
    {
        var name = type.FullName ?? type.Name;
        var genericMarker = name.IndexOf('`');
        if (genericMarker >= 0)
        {
            name = name[..genericMarker];
        }

        return name.Replace('+', '.');
    }

    private static string AppendNullableAnnotation(string name, Type type, NullabilityInfo? nullability)
    {
        return !type.IsValueType && nullability?.ReadState == NullabilityState.Nullable ? $"{name}?" : name;
    }

    private static string? GetAlias(Type type)
    {
        if (type == typeof(bool)) return "bool";
        if (type == typeof(byte)) return "byte";
        if (type == typeof(sbyte)) return "sbyte";
        if (type == typeof(short)) return "short";
        if (type == typeof(ushort)) return "ushort";
        if (type == typeof(int)) return "int";
        if (type == typeof(uint)) return "uint";
        if (type == typeof(long)) return "long";
        if (type == typeof(ulong)) return "ulong";
        if (type == typeof(float)) return "float";
        if (type == typeof(double)) return "double";
        if (type == typeof(decimal)) return "decimal";
        if (type == typeof(char)) return "char";
        if (type == typeof(string)) return "string";
        if (type == typeof(object)) return "object";

        return null;
    }

    private static string FormatDefaultValue(object? value, Type declaredType)
    {
        if (value is null || value == DBNull.Value || value == Missing.Value)
        {
            return declaredType.IsValueType && Nullable.GetUnderlyingType(declaredType) is null ? "default" : "null";
        }

        if (value is string stringValue)
        {
            return $"\"{stringValue.Replace("\"", "\\\"", StringComparison.Ordinal)}\"";
        }

        if (value is char charValue)
        {
            return $"'{charValue}'";
        }

        if (value is bool boolValue)
        {
            return boolValue ? "true" : "false";
        }

        if (declaredType.IsEnum)
        {
            var underlyingType = Enum.GetUnderlyingType(declaredType);
            var numericValue = Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture);
            return $"{FormatTypeName(declaredType)}.{Enum.GetName(declaredType, value)} ({Convert.ToString(numericValue, CultureInfo.InvariantCulture)})";
        }

        return Convert.ToString(value, CultureInfo.InvariantCulture) ?? "default";
    }

    private static string FormatObsolete(MemberInfo member)
    {
        var obsolete = member.GetCustomAttribute<ObsoleteAttribute>();
        return obsolete is null
            ? string.Empty
            : $" [Obsolete(\"{obsolete.Message}\", IsError={obsolete.IsError})]";
    }

    private const BindingFlags DeclaredPublicMembers =
        BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
}
