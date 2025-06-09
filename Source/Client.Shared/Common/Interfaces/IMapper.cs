namespace Erdmier.GigHero.Client.Shared.Common.Interfaces;

public interface IMapper<TDomain, TDto>
{
    public TDto MapToDto(TDomain domain);

    public TDomain MapToDomain(TDto dto);
}
