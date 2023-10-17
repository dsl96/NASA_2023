using DATA_CLASSES;

namespace API.services
{
    public interface IAstronautsService
    {
        Task<IEnumerable<AstronautResponse>> GetAstronauts( AstronautFilter filter);
    }
}
