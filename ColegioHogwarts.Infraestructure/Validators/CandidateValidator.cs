using ColegioHogwarts.Core.DTOs;
using FluentValidation;

namespace ColegioHogwarts.Infraestructure.Validators
{
    public class CandidateValidator : AbstractValidator<CandidateDto>
    {
        public CandidateValidator()
        {
            RuleFor(candidate => candidate.Identification)
                .NotNull()
                .LessThanOrEqualTo(9999999999);

            RuleFor(candidate => candidate.Name)
                .NotNull()
                .Length(3, 20);

            RuleFor(candidate => candidate.LastName)
                .NotNull()
                .Length(3, 20);

            RuleFor(candidate => candidate.Age)
                .NotNull()
                .LessThanOrEqualTo(99);

            RuleFor(candidate => candidate.House)
                .NotNull();
        }
    }
}
