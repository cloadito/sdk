namespace Cloudito.Sdk;

/// <summary>
/// Ticket message model
/// </summary>
/// <param name="Id">nullable id that use for upsert</param>
/// <param name="ReplyId">reply message id</param>
/// <param name="SenderId">sender message id</param>
/// <param name="Text">message text</param>
public record TicketMessage(Guid? Id, Guid? ReplyId, Guid SenderId, string Text);