using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

public sealed class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    public GetCompaniesHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
       var companies = await _repositoryManager.Company.GetAllCompaniesAsync(request.TrackChanges);
       var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
       return companyDtos;
    }
}
