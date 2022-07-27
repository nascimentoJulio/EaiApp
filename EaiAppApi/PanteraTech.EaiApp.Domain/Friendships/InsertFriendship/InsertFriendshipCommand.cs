using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
using System.Linq;
using System.Text.Json.Serialization;

namespace PanteraTech.EaiApp.Domain.Friendships.InsertFriendship
{
    public class InsertFriendshipCommand : IRequest<long>
    {
        [JsonIgnore]
        public string EmailSend { get; set; }

        public string EmailReceive{ get; set; }


        public ValidationFailure? IsValid()
        {
            var validator = new InlineValidator<InsertFriendshipCommand>();
            validator.RuleFor(c => c.EmailSend)
            .NotEmpty()
            .EmailAddress()
            .WithErrorCode(Errors.INVALID_FIELD)
            .WithMessage(string.Format(
                Errors.INVALID_FIELD_MESSAGE,
                "Email",
                "O email de quem mandou deve estar presente."
                ));

            validator.RuleFor(c => c.EmailReceive)
            .NotEmpty()
            .WithErrorCode(Errors.INVALID_FIELD)
            .WithMessage(
              string.Format(
                Errors.INVALID_FIELD_MESSAGE,
                "Email",
                ""
                )
              );

            var result = validator.Validate(this)?.Errors;
            return result?.Count == 0 ? null : result.ToList().First();
        }
    }
}
