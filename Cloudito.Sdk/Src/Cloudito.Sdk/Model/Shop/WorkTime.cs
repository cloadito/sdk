namespace Cloudito.Sdk;

public record TimeRange(TimeOnly Start, TimeOnly End);

public record WeeklyWorkTime(
    Guid Id,
    Guid ShopId,
    DayOfWeek Day,
    bool IsClosed,
    IEnumerable<TimeRange> TimeRanges);

public record UpsertWeeklyWorkTime(
    Guid? Id,
    Guid ShopId,
    DayOfWeek Day,
    bool IsClosed,
    IEnumerable<TimeRange> TimeRanges);

public record WorkTimeException(
    Guid Id,
    Guid ShopId,
    DateOnly Date,
    bool IsClosed,
    string? Reason,
    IEnumerable<TimeRange> TimeRanges);
    
public record UpsertWorkTimeException(
    Guid? Id,
    Guid ShopId,
    DateOnly Date,
    bool IsClosed,
    string? Reason,
    IEnumerable<TimeRange> TimeRanges);