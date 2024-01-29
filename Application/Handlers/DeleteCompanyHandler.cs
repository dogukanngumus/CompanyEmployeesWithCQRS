using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application;

internal sealed class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IRepositoryManager _repository;
    public DeleteCompanyHandler(IRepositoryManager repository) => _repository = repository;
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _repository.Company.GetCompanyAsync(request.Id, request.TrackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(request.Id);
        }    
        _repository.Company.DeleteCompany(company);
        await _repository.SaveAsync();
    }
}