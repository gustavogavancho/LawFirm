using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientList;

public class GetClientListQuery : IRequest<List<ClientListVm>>
{

}