using Soenneker.Dtos.ProblemDetails;
using Soenneker.Dtos.Results.Operation;
using System.Diagnostics.Contracts;
using System.Net;

namespace Soenneker.Extensions.Dtos.ProblemDetails;

/// <summary>
/// An extension class for ProblemDetails DTOs
/// </summary>
public static class ProblemDetailsDtosExtension
{
    /// <summary>
    /// Creates a new OperationResult instance from the specified problem details and optional HTTP status code.
    /// </summary>
    /// <param name="problem">The problem details to associate with the operation result. Cannot be null.</param>
    /// <param name="statusCode">An optional HTTP status code to assign to the result. If null, the status from the problem details is used; if
    /// that is also null, 500 is used.</param>
    /// <returns>An OperationResult containing the provided problem details and the specified or derived HTTP status code.</returns>
    [Pure]
    public static OperationResult ToOperationResult(this ProblemDetailsDto problem, HttpStatusCode? statusCode = null)
    {
        var result = new OperationResult { Problem = problem };

        if (statusCode == null)
            result.StatusCode = problem.Status ?? 500;
        else
            result.StatusCode = (int)statusCode;

        return result;
    }
}
