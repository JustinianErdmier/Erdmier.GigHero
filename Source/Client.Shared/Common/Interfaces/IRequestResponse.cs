namespace Erdmier.GigHero.Client.Shared.Common.Interfaces;

public interface IRequestResponse
{
    string? ErrorMessage { get; }

    bool IsSuccess { get; }

    bool IsFailure => !IsSuccess;
}

public interface IRequestResponse<out TReturnData> : IRequestResponse
{
    TReturnData? Data { get; }

    // [ MemberNotNullWhen(returnValue: true, nameof(Data)) ]
    bool HasData { get; }
}
