using MediatR;
using PagedList;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Messages.GetMessageByChat
{
    public class GetMessageByChatCommandHandler : IRequestHandler<GetMessagesByChatCommand, GetMessageByChatCommandResult>
    {
        private readonly IMessagesRepository _messagesRepository;

        public GetMessageByChatCommandHandler(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<GetMessageByChatCommandResult> Handle(GetMessagesByChatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var messages = await _messagesRepository.GetMessageByChat(request);
                var pagedResult = messages.ToPagedList(request.Page, request.PageSize);

                return new GetMessageByChatCommandResult
                {
                    HasNextPage = pagedResult.HasNextPage,
                    IsFirstPage = pagedResult.IsFirstPage,
                    IsLastPage = pagedResult.IsLastPage,
                    HasPreviousPage = pagedResult.HasPreviousPage,
                    PageNumber = pagedResult.PageNumber,
                    Messages = pagedResult.ToList(),
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new HttpException(System.Net.HttpStatusCode.InternalServerError, Errors.INTERNAL_ERROR, Errors.INTERNAL_ERROR_MESSAGE);
            }
        }
    }
}
