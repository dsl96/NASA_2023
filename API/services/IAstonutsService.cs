using DATA_CLASSES;

namespace API.services
{
    public interface IAstonutsService
    {
        Task<IEnumerable<AstronautResponse>> GetAstronauts(int skip = 0, int take = int.MaxValue);
    }
}
