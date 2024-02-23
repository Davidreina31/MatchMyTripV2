using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match.commands.common;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.commands.deleteMatchCommand
{
    public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, MatchCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match> _repo;

        public DeleteMatchCommandHandler(IMapper mapper, IRepository<Match> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<MatchCommandResponse> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var response = new MatchCommandResponse();
            var match = await _repo.DeleteAsync(request.Id);

            response.Match = _mapper.Map<MatchDTO>(match);

            return response;
        }
    }
}
