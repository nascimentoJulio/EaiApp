using MediatR;
using PanteraTech.EaiApp.Domain.Constanst;
using PanteraTech.EaiApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Domain.Friendships.InsertFriendship
{
    public class InsertFriendshipCommandHandler : IRequestHandler<InsertFriendshipCommand, long>
    {
        private readonly IFriendshipRepository _friendshipRepository;

        private readonly IUserRepository _userRepository;

        public InsertFriendshipCommandHandler(IFriendshipRepository friendshipRepository, IUserRepository userRepository)
        {
            _friendshipRepository = friendshipRepository;
            _userRepository = userRepository;
        }

        public async Task<long> Handle(InsertFriendshipCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid() != null) throw new HttpException(
                HttpStatusCode.UnprocessableEntity,
                request.IsValid().ErrorCode,
                request.IsValid().ErrorMessage
            );

            var hasUser = await _userRepository.HasUserWithEmail(request.EmailReceive);

            if (!hasUser) 
            {
                throw new HttpException(
                    HttpStatusCode.NotFound
                );
            }

            var requests = await _friendshipRepository.GetFriendshipRequestAsync(request.EmailReceive);

            requests.ForEach(f =>
            {
                if (f.Email.Equals(request.EmailSend))
                {
                    throw new HttpException
                    (
                        HttpStatusCode.UnprocessableEntity,
                        Errors.LIMIT_EXCEEDED,
                        string.Format(Errors.LIMIT_EXCEEDED_MESSAGE, "1")
                    );
                }
            });

            return await _friendshipRepository.InsertFriendshipRequest(request.EmailReceive, request.EmailSend);
        }
    }
}
