# Security Policy

## Supported versions

Security fixes are applied to the latest released version of Mvx.ApiClient.Net.

## Reporting a vulnerability

Please do not open a public issue for a security vulnerability.

Report security concerns through GitHub's private vulnerability reporting for this repository, or contact the maintainer privately if private reporting is not available.

Include:

- Affected package version or commit.
- A clear description of the issue.
- Steps to reproduce, when possible.
- Impact and any known mitigations.

## Scope

This package is a client wrapper around public MultiversX API GET endpoints. Relevant security issues include unsafe URL handling, credential or secret leakage, dependency vulnerabilities with practical impact, denial-of-service risks caused by client behavior, or incorrect error handling that exposes sensitive consumer data.

Reports about the upstream MultiversX API itself should be reported to the upstream project or service owner.
