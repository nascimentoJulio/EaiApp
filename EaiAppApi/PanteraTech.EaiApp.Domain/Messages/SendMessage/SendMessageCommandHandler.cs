using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {

        private  readonly IMessagesRepository _messagesRepository;

        public SendMessageCommandHandler(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IsValid() != null) throw new HttpException(
                        HttpStatusCode.UnprocessableEntity,
                        request.IsValid().ErrorCode,
                        request.IsValid().ErrorMessage
                 );

                await _messagesRepository.InsertMessage(request);
                
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Erro: " + ex.Message);
                throw new HttpException(HttpStatusCode.InternalServerError, Errors.INTERNAL_ERROR, Errors.INTERNAL_ERROR_MESSAGE);
            }
        }
    }
}
