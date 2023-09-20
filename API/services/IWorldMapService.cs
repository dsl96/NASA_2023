namespace API.services
{
    public interface IWorldMapService
    {
        Task<byte[]?> GetWorldMap((double, double)[] markersLonLat);
    }
}
