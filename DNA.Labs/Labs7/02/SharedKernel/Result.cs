namespace DNA.Labs.Labs7._02.SharedKernel;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string? Error { get; }

    public static Result Success()
        => new Result(true, null);

    public static Result Failure(string error)
        => new Result(false, error);

    private Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
}