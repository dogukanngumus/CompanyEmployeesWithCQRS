using MediatR;
using Shared.DataTransferObjects;

namespace Application;

public record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest;
