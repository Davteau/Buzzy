using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class ErrorOrExtensions
{
    public static IResult MatchToResult<T>(this ErrorOr<T> result, string v)
    {
        return result.Match(
            value => Results.Ok(value),
            errors => MapErrors(errors)
        );
    }

    public static IResult MatchToResultCreated<T>(this ErrorOr<T> result, string uri)
    {
        return result.Match(
            value => Results.Created(uri, value),
            errors => MapErrors(errors)
        );
    }

    private static IResult MapErrors(IReadOnlyList<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var errorsDict = errors
                .GroupBy(e => e.Code)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.Description).ToArray()
                );
            return Results.ValidationProblem(errorsDict);
        }

        if (errors.All(e => e.Type == ErrorType.NotFound))
        {
            return Results.NotFound(new { Errors = errors.Select(e => e.Description) });
        }

        return Results.Problem(
            detail: string.Join("; ", errors.Select(e => e.Description)),
            statusCode: 500
        );
    }

}
