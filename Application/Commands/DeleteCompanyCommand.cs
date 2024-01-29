using MediatR;

namespace Application;

public record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest;