using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>>? validators = null
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IEnumerable<IValidator<TRequest>>? _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators is null || !_validators.Any())
            return await next();

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(request, cancellationToken))
        );

        var failures = validationResults.SelectMany(r => r.Errors).Where(e => e != null).ToList();
        if (!failures.Any())
            return await next();

        var errors = failures.Select(f => Error.Validation(f.PropertyName, f.ErrorMessage)).ToList();

        return (dynamic)errors;
    }
}
