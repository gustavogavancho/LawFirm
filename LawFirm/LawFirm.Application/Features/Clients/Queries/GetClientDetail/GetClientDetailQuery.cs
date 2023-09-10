using LawFirm.Application.Features.Clients.Models;
using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientDetail;

public class GetClientDetailQuery : IRequest<ClientVm>
{
    public Guid Id { get; set; }
}