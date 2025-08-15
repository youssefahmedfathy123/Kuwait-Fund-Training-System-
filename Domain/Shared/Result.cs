using Gatherly.Domain.Shared;

namespace Gatherly.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }



    public bool IsSuccess { get; }


    public bool IsFailure => !IsSuccess;


    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    // Error.Success<Error>(Error);
    // return Result.Failure<Invitation>(DomainErrors.Gathering.AlreadyPassed);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Failure<T>(Error error) => new (default,false, error);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}


// return Result.Failure<Attendee>(DomainErrors.Gathering.Expired);



