using MediatR;

namespace LawFirm.Application.Features.Clients.Queries.GetClientDetail;

public class GetClientDetailQuery : IRequest<ClientDetailVm>
{
    public Guid Id { get; set; }
}