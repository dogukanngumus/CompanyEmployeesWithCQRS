using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;
public record class CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;