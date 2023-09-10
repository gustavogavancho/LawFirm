using LawFirm.Application.Features.Clients.Models;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientList;

public class GetClientListQuery : IRequest<List<ClientVm>>
{

}