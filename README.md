[![](https://img.shields.io/nuget/v/soenneker.extensions.dtos.problemdetails.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.dtos.problemdetails/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.dtos.problemdetails/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.dtos.problemdetails/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.dtos.problemdetails.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.dtos.problemdetails/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.dtos.problemdetails/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.dtos.problemdetails/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Dtos.ProblemDetails
Extension methods for converting and enriching `ProblemDetailsDto` error responses for use in application result pipelines.

## Installation

```bash
dotnet add package Soenneker.Extensions.Dtos.ProblemDetails
```

## Usage

```csharp
using Soenneker.Extensions.Dtos.ProblemDetails;

var problem = new ProblemDetailsDto
{
    Status = 404,
    Title = "Customer not found"
};

OperationResult result = problem.ToOperationResult();
// result.Problem is the same problem instance
// result.StatusCode == 404
```

Status selection follows a clear precedence:

1. An explicit `HttpStatusCode` argument wins.
2. Otherwise `problem.Status` is used.
3. If neither is present, the result uses `500`.

The problem object is assigned directly rather than cloned. The source must be non-null.
