using API.DAL;
using API.Migrations;
using DATA_CLASSES;
using System.Linq.Expressions;

namespace API.services.implementation
{
    public class AstonutsService : IAstonutsService
    {

        private readonly IRepository<AstronautResponse> _astronautsRepo;
        public AstonutsService(IRepository<AstronautResponse> repository)
        {
            _astronautsRepo = repository;
        }

        public async Task<IEnumerable<AstronautResponse>> GetAstronauts()
        {

            var includeProperties = new List<Expression<Func<AstronautResponse, object>>>
            {
              astronaut =>  astronaut.agency
            };

          //  Expression<Func<AstronautResponse, bool>> filter = astronaut => astronaut.agency.id == 1 ;

            return await _astronautsRepo.GetAllAsync(skip: 30,
                                                     take: 25, 
                                                     includeProperties: includeProperties
                                                     );
        }
    }
}
