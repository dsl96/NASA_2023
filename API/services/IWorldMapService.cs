namespace API.services
{
    /// <summary>
    /// interface to service of world map services
    /// </summary>
    public interface IWorldMapService
    {
        Task<byte[]?> GetWorldMap((double, double)[] markersLonLat);
    }
}
