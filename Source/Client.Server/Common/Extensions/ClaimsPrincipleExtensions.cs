namespace Erdmier.GigHero.Client.Server.Common.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static Guid GetId(this ClaimsPrincipal user)
    {
        string? value = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value), message: "No user id found in claims.");
        }

        try
        {
            return Guid.Parse(value);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            throw;
        }
    }

    public static Guid? TryGetId(this ClaimsPrincipal user)
    {
        string? value = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return Guid.TryParse(value, out Guid id) ? id : null;
    }
}
