using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using PanteraTech.EaiApp.Domain.Constanst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Messages.SendMessage
{
    public class SendMessageCommand : IRequest<bool>
    {
        public string MessageContent { get; set; }

        [JsonIgnore]
        public DateTime DataSend => DateTime.Now;

        [JsonIgnore]
        public string UserSend { get; set; }

        public string UserReceive { get; set; }

        public int IdChat { get; set; }


        public ValidationFailure? IsValid()
        {
            var validator = new InlineValidator<SendMessageCommand>();

            validator.RuleFor(c => c.MessageContent)
            .NotEmpty()
            .WithErrorCode(Errors.INVALID_FIELD)
            .WithMessage(string.Format(
                Errors.INVALID_FIELD_MESSAGE,
                "MessageContent",
                "O campo não pode ser nulo"
                )
            );

            validator.RuleFor(c => c.DataSend)
           .NotEmpty()
           .WithErrorCode(Errors.INVALID_FIELD)
           .WithMessage(string.Format(
               Errors.INVALID_FIELD_MESSAGE,
               "DataSend",
               "O campo não pode ser nulo"
               )
           );

            validator.RuleFor(c => c.MessageContent)
           .NotEmpty()
           .WithErrorCode(Errors.INVALID_FIELD)
           .WithMessage(string.Format(
               Errors.INVALID_FIELD_MESSAGE,
               "UserReceive",
               "O campo não pode ser nulo"
               )
           );

            validator.RuleFor(c => c.MessageContent)
          .NotEmpty()
          .WithErrorCode(Errors.INVALID_FIELD)
          .WithMessage(string.Format(
              Errors.INVALID_FIELD_MESSAGE,
              "IdChat",
              "O campo não pode ser nulo"
              )
          );
            var result = validator.Validate(this)?.Errors;
            return result?.Count == 0 ? null : result.ToList().First();
        }
    }
}
