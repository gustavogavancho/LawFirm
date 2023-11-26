using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Application.Models.Pagination;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetPagedClientList;

public class GetPagedClientListQueryHandler : IRequestHandler<GetPagedClientListQuery, PagedList<ClientVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Client> _clientRepository;

    public GetPagedClientListQueryHandler(IMapper mapper,
        IAsyncRepository<Client> clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<PagedList<ClientVm>> Handle(GetPagedClientListQuery request, CancellationToken cancellationToken)
    {
        var pagedItems = await _clientRepository.ListAllAsync(true);

        var mappedItems =  _mapper.Map<List<ClientVm>>(pagedItems);

        return PagedList<ClientVm>.ToPagedList(mappedItems, request.ItemsParameters.PageNumber, request.ItemsParameters.PageSize);
    }
}