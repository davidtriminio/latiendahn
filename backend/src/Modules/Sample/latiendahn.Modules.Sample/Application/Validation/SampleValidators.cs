using FluentValidation;
using latiendahn.Modules.Sample.Application.Contracts;

namespace latiendahn.Modules.Sample.Application.Validation;

public sealed class CreateSampleRequestValidator : AbstractValidator<CreateSampleRequest>
{
    public CreateSampleRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(2000);
    }
}

public sealed class UpdateSampleRequestValidator : AbstractValidator<UpdateSampleRequest>
{
    public UpdateSampleRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(2000);
    }
}