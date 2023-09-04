namespace BankingSystem.Web.Models;

public static class Transfer
{
    public static long SourceId { get; set; }
    public static long TargetId { get; set; }
    public static decimal Amount { get; set; }
}