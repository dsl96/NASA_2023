using API.DAL;
using API.Migrations;
using DATA_CLASSES;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace API.services.implementation
{
    public class AstonutsService : IAstonutsService
    {

        private readonly IRepository<AstronautResponse> _astronautsRepo;
        public AstonutsService(IRepository<AstronautResponse> repository)
        {
            _astronautsRepo = repository;
        }

        public async Task<IEnumerable<AstronautResponse>> GetAstronauts(int skip = 0, int take = int.MaxValue)
        {

            
            var includeProperties = new List<Expression<Func<AstronautResponse, object>>>
            {
              astronaut =>  astronaut.agency
            };

          //  Expression<Func<AstronautResponse, object>> orderBy = a =>  a.date_of_birth;

            List<Expression<Func<AstronautResponse, bool>>> filterExpression =new() { astronaut => astronaut.age  < 40 };


            return await _astronautsRepo.GetAllAsync(skip: skip,
                                                     take: take, 
                                                     includeProperties: includeProperties
                                                     ,filters: filterExpression);
        }
    }
}
