using DATA_CLASSES;

namespace API.services
{
    public interface IissDataService
    {
        Task<IssLocationResponse?> GetIssLocation();
    }
}
