using System.Linq;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;

namespace PanteraTech.EaiApp.Domain.Chats.CreateChats
{
  public class CreateChatsCommand : IRequest<long>
  {
    [JsonIgnore]
    public string UserEmail { get; set; }

    public string EmailFriend { get; init; }

    public ValidationFailure? IsValid()
    {
      var validator = new InlineValidator<CreateChatsCommand>();
      validator.RuleFor(c => c.UserEmail)
      .NotEmpty()
      .EmailAddress()
      .WithErrorCode(Errors.INVALID_FIELD)
      .WithMessage(string.Format(
          Errors.INVALID_FIELD_MESSAGE,
          "UserEmail",
          "Confira a informação passada e tente novamente"
          ));

      validator.RuleFor(c => c.UserEmail)
       .NotEmpty()
       .EmailAddress()
       .WithErrorCode(Errors.INVALID_FIELD)
       .WithMessage(string.Format(
           Errors.INVALID_FIELD_MESSAGE,
           "EmailFriend",
           "Confira a informação passada e tente novamente"
           ));

      var result = validator.Validate(this)?.Errors;
      return result?.Count == 0 ? null : result.ToList().First();
    }
  }
}