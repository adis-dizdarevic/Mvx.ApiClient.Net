using System.Globalization;

namespace Mvx.ApiClient.Net.Infrastructure;

internal enum QueryCollectionFormat
{
    CommaSeparated,
    Repeated
}

internal sealed class QueryParameters
{
    private readonly List<KeyValuePair<string, string>> _values = [];

    public IReadOnlyList<KeyValuePair<string, string>> Values => _values;

    public static QueryParameters? From(QueryOptions? options)
    {
        if (options is null)
        {
            return null;
        }

        var parameters = new QueryParameters();
        parameters.AddPagination(options.Pagination);

        return parameters;
    }

    public QueryParameters AddString(string name, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            Add(name, value);
        }

        return this;
    }

    public QueryParameters AddBoolean(string name, bool? value)
    {
        if (value is not null)
        {
            Add(name, value.Value ? "true" : "false");
        }

        return this;
    }

    public QueryParameters AddNumber<T>(string name, T value)
        where T : struct, IFormattable
    {
        Add(name, value.ToString(null, CultureInfo.InvariantCulture));

        return this;
    }

    public QueryParameters AddOptionalNumber<T>(string name, T? value)
        where T : struct, IFormattable
    {
        if (value is not null)
        {
            AddNumber(name, value.Value);
        }

        return this;
    }

    public QueryParameters AddCollection(
        string name,
        IEnumerable<string>? values,
        QueryCollectionFormat format = QueryCollectionFormat.CommaSeparated)
    {
        if (values is null)
        {
            return this;
        }

        var materializedValues = values
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .ToArray();

        if (materializedValues.Length == 0)
        {
            return this;
        }

        if (format == QueryCollectionFormat.CommaSeparated)
        {
            Add(name, string.Join(',', materializedValues));
            return this;
        }

        foreach (var value in materializedValues)
        {
            Add(name, value);
        }

        return this;
    }

    public QueryParameters AddPagination(Pagination? pagination)
    {
        if (pagination is null)
        {
            return this;
        }

        ValidatePagination(pagination);
        AddOptionalNumber("size", pagination.Limit);
        AddOptionalNumber("from", pagination.Offset);

        return this;
    }

    private void Add(string name, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        _values.Add(new KeyValuePair<string, string>(name, value));
    }

    private static void ValidatePagination(Pagination pagination)
    {
        if (pagination.Limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), "Pagination limit cannot be negative.");
        }

        if (pagination.Limit > Pagination.MaximumLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), $"Pagination limit cannot exceed {Pagination.MaximumLimit}.");
        }

        if (pagination.Offset < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), "Pagination offset cannot be negative.");
        }
    }
}
