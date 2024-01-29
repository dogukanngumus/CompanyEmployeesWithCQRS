using MediatR;

namespace Application.Commands;

public sealed record CompanyDeletedNotification(Guid Id, bool TrackChanges) : INotification;
