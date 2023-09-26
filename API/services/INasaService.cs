using DATA_CLASSES;

namespace API.services
{
    /// <summary>
    /// interface to service of nasa api like daily image  and astouid data ...
    /// </summary>
    public interface INasaService
    {
        public Task<NasaDailyImageResponse> GetDailyImage(DateTime? dateTime = null);
    }
}
