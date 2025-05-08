namespace Cloudito.Sdk;

public record Ticket(Guid Id, string Title, string Description, TicketStatus Status, TicketPriority Priority, Guid RequesterId, Guid? DepartmentId);

public record NewTicket(string Title, string Description, TicketStatus Status, TicketPriority Priority, Guid RequesterId, Guid? DepartmentId);

public enum TicketStatus
{
    Active,
    Inactive,
}

public enum TicketPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}
