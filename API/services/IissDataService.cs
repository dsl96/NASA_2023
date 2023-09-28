using DATA_CLASSES;

namespace API.services
{

    /// <summary>
    /// iterface to service to get all iss data like location astrunauts ...
    /// </summary>
    public interface IissDataService
    {
        Task<IssLocationResponse?> GetIssLocation();
    }
}
