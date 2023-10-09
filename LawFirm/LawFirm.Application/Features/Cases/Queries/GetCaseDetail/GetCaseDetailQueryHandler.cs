﻿using AutoMapper;
using LawFirm.Application.Contracts.Persistence;
using LawFirm.Application.Exceptions;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Domain.Entities;
using MediatR;

namespace LawFirm.Application.Features.Cases.Queries.GetCaseDetail;

public class GetCaseDetailQueryHandler : IRequestHandler<GetCaseDetailQuery, CaseVm>
{
    private readonly IMapper _mapper;
    private readonly ICaseRepository _caseRepository;

    public GetCaseDetailQueryHandler(IMapper mapper,
        ICaseRepository caseRepository)
    {
        _mapper = mapper;
        _caseRepository = caseRepository;
    }

    public async Task<CaseVm> Handle(GetCaseDetailQuery request, CancellationToken cancellationToken)
    {
        var @case = await _caseRepository.GetByIdAsync(request.Id);

        if(@case is null)
        {
            throw new NotFoundException(nameof(Case), request.Id);
        }

        var caseDetailDto = _mapper.Map<CaseVm>(@case);

        return caseDetailDto;
    }
}