namespace DotnetBlogApi.Domain.Common;

public record ResultObject<T>(bool IsError, string Message, T Data);
public record ResultObject(bool IsError, string Message);

public static class Result<T>
{
    public static ResultObject<T> Failure(T data, string message = "Something went wrong.")
    {
        return new ResultObject<T>(true, message, data);
    }
    
    public static ResultObject<T> Success(T data, string message = "Operation has been done.")
    {
        return new ResultObject<T>(false, message, data);
    }
}


public static class Result
{
    public static ResultObject Failure(string message = "Something went wrong.")
    {
        return new ResultObject(true, message);
    }
    
    public static ResultObject Success(string message = "Operation has been done.")
    {
        return new ResultObject(false, message);
    }
}
