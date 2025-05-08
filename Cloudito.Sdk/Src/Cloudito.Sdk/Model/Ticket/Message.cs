namespace Cloudito.Sdk;

public record TicketMessage(Guid Id, Guid? ReplyId, Guid SenderId, string Text);

public record UpsertTicketMessage(Guid TicketId, Guid? Id, Guid? ReplyId, Guid SenderId, string Text);