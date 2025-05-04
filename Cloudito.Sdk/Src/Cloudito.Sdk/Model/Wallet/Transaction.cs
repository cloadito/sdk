namespace Cloudito.Sdk;

public record WalletTransaction(Guid Id, Guid WalletId, string UniqId, decimal Amount, TransactionType Type, TransactionStatus Status, WalletTransactionDetails? Details);

public record WalletTransactionDetails(Guid Id, string Description, IEnumerable<ClouditoMetadata> Metadata);

public enum TransactionType
{
    Increment,
    Decrement,
    Transfer,
}

public enum TransactionStatus
{
    Pending,
    Complete,
    Failed
}