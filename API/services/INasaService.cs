using DATA_CLASSES;

namespace API.services
{
    public interface INasaService
    {
        public Task<NasaDailyImageResponse> GetDailyImage(DateTime? dateTime = null);
    }
}
