namespace BankingSystem.Service.Exceptions;

public class CustomException : Exception
{
	public int StatusCode { get; set; }
	public CustomException(int statusCode, string message):base(message) 
    {
        
    }
    public CustomException(string message,Exception innerException):base(message,innerException) 
    {
    }
}
