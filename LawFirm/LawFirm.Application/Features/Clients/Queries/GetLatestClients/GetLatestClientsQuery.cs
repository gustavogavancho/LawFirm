using LawFirm.Application.Features.Clients.Models;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetLatestClients;

public class GetLatestClientsQuery : IRequest<List<ClientVm>>
{
}