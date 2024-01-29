using MediatR;
using Shared.DataTransferObjects;

namespace Application;
public record class CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;