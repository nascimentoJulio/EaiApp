using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
namespace PanteraTech.EaiApp.Domain.User.Login
{
  public class LoginCommand : IRequest<LoginCommandResult>
  {
    public string Email { get; set; }

    public string Password { get; set; }


    public ValidationFailure? IsValid()
    {
      var validator = new InlineValidator<LoginCommand>();
      validator.RuleFor(c => c.Email)
      .NotEmpty()
      .EmailAddress()
      .WithErrorCode(Errors.INVALID_FIELD)
      .WithMessage(string.Format(
          Errors.INVALID_FIELD_MESSAGE,
          "Email",
          "Confira a informação passada e tente novamente"
          ));

      validator.RuleFor(c => c.Password)
      .NotEmpty()
      .WithErrorCode(Errors.INVALID_FIELD)
      .WithMessage(
        string.Format(
          Errors.INVALID_FIELD_MESSAGE,
          "Senha",
          "O campo deve ser preenchido"
          )
        );

        var result = validator.Validate(this)?.Errors;
        return result?.Count == 0 ? null : result.ToList().First();
    }
  }
}