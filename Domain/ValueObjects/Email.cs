using Domain.Primitives;
using Gatherly.Domain.Shared;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public const int MaxLength = 50;

    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);


    public string Value { get; private set; }

    private Email(string value)
    {
        Value = value;
    }


    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Email>(new Error(
                "Email.Empty",
                "Email is empty."));
        }

        if (email.Length > MaxLength)
        {
            return Result.Failure<Email>(new Error(
                "Email.TooLong",
                $"Email cannot be longer than {MaxLength} characters."));
        }

        if (!EmailRegex.IsMatch(email))
        {
            return Result.Failure<Email>(new Error(
                "Email.InvalidFormat",
                "Email format is invalid."));
        }

        return Result.Success(new Email(email));
    }


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;
}
