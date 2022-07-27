using MediatR;
using PagedList;
using PanteraTech.EaiApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Friendships.GetFriendshipsRequest
{
    public class GetRequestFriendshipsCommandHandler : IRequestHandler<GetRequestFriendshipsCommand, GetRequestFrindshipsCommandResult>
    {

        private IFriendshipRepository _friendshipRepository { get; set; }

        public GetRequestFriendshipsCommandHandler(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task<GetRequestFrindshipsCommandResult> Handle(GetRequestFriendshipsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _friendshipRepository.GetFriendshipRequestAsync(request.EmailUser);
                var pagedResult = result.ToPagedList(request.Page, request.PageSize);
               

                var response = pagedResult.Select( async f => 
                new GetRequestFrindshipsCommandResult
                {
                    HasNextPage = pagedResult.HasNextPage,
                    IsFirstPage = pagedResult.IsFirstPage,
                    IsLastPage = pagedResult.IsLastPage,
                    HasPreviousPage = pagedResult.HasPreviousPage,
                    PageNumber = pagedResult.PageNumber,
                    UserData =  await _friendshipRepository.GetFriendshipData(f.Email)
                });

                
                return await response.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, "500", "Ocorreu um erro de comunicação");
            }
        }
    }
}
