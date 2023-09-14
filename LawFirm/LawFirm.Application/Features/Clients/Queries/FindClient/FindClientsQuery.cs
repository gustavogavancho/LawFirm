using LawFirm.Application.Features.Clients.Models;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientDetail;

public class FindClientsQuery : IRequest<List<ClientVm>>
{
    public string SearchTerm { get; set; }
}