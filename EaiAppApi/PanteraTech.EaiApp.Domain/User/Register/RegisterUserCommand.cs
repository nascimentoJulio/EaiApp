using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;

namespace PanteraTech.EaiApp.Domain.User.Register
{
  public class RegisterUserCommand : IRequest<long>
  {
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string UrlProfileUser { get; set; }

    public ValidationFailure? IsValid()
    {
      var validator = new InlineValidator<RegisterUserCommand>();
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

    validator.RuleFor(c => c.Username)
   .NotEmpty()
   .WithErrorCode(Errors.INVALID_FIELD)
   .WithMessage(
     string.Format(
       Errors.INVALID_FIELD_MESSAGE,
       "Nome",
       "O campo deve ser preenchido"
       )
     );

    validator.RuleFor(c => c.UrlProfileUser)
   .NotEmpty()
   .WithErrorCode(Errors.INVALID_FIELD)
   .WithMessage(
     string.Format(
       Errors.INVALID_FIELD_MESSAGE,
       "Foto",
       "O campo deve ser preenchido"
       )
     );

      var result = validator.Validate(this)?.Errors;
      return result?.Count == 0 ? null : result.ToList().First();
    }
  }
}