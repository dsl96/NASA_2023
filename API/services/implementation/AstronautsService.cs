using API.DAL;
using API.Migrations;
using DATA_CLASSES;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace API.services.implementation
{
    public class AstronautsService : IAstronautsService
    {

        private readonly IRepository<AstronautResponse> _astronautsRepo;
        public AstronautsService(IRepository<AstronautResponse> repository)
        {
            _astronautsRepo = repository;
        }

        public async Task<IEnumerable<AstronautResponse>> GetAstronauts(AstronautFilter astronautFilter)
        {

            
            var includeProperties = new List<Expression<Func<AstronautResponse, object>>>
            {
              astronaut =>  astronaut.agency
            };

            //  Expression<Func<AstronautResponse, object>> orderBy = a =>  a.date_of_birth;

            List<Expression<Func<AstronautResponse, bool>>> filterExpression = CreateFilterExpressions(astronautFilter);


            return await _astronautsRepo.GetAllAsync(skip: astronautFilter.Skip,
                                                     take: astronautFilter.Take, 
                                                     includeProperties: includeProperties
                                                     ,filters:filterExpression
                                                    );
        }



        public List<Expression<Func<AstronautResponse, bool>>> CreateFilterExpressions(AstronautFilter filter)
        {
            List<Expression<Func<AstronautResponse, bool>>> filterExpressions = new List<Expression<Func<AstronautResponse, bool>>>();

            if (filter.MinBirthDate.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.date_of_birth >= filter.MinBirthDate;
                filterExpressions.Add(expression);
            }

            if (filter.MaxBirthDate.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.date_of_birth <= filter.MaxBirthDate;
                filterExpressions.Add(expression);
            }

            if (filter.IsInSpace.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.in_space == filter.IsInSpace;
                filterExpressions.Add(expression);
            }

            if (filter.IsAlive.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => (astronaut.date_of_death == null) == filter.IsAlive;
                filterExpressions.Add(expression);
            }

            if (!string.IsNullOrEmpty(filter.AgencyName))
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.agency != null && astronaut.agency.name == filter.AgencyName;
                filterExpressions.Add(expression);
            }

            if (filter.MinDaysInSpace.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.TimeSpanInSpace.HasValue &&  astronaut.TimeSpanInSpace.Value.Days >= filter.MinDaysInSpace;
                filterExpressions.Add(expression);
            }

            return filterExpressions;
        }
    }
}

