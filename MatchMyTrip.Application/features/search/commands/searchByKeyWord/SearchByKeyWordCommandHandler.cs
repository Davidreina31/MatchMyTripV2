using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.search.commands.searchByKeyWord
{
    public class SearchByKeyWordCommandHandler : IRequestHandler<SearchByKeyWordCommand, List<UserQueryDTO>>
    {
        private readonly ISearchRepository _repo;
        private readonly IMapper _mapper;

        public SearchByKeyWordCommandHandler(ISearchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<UserQueryDTO>> Handle(SearchByKeyWordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetMatchListByKeyWord(request.KeyWord);

            return _mapper.Map<List<UserQueryDTO>>(user);
        }
    }
}
