using API.DAL;
using API.Migrations;
using DATA_CLASSES;
using Microsoft.IdentityModel.Tokens;
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

            Expression<Func<AstronautResponse, object>> orderBy = CreateOrderByExpression(astronautFilter);

            List<Expression<Func<AstronautResponse, bool>>> filterExpression = CreateFilterExpressions(astronautFilter);


            return await _astronautsRepo.GetAllAsync(skip: astronautFilter.Skip,
                                                     take: astronautFilter.Take,
                                                     includeProperties: includeProperties
                                                     , filters: filterExpression
                                                     ,orderBy: orderBy
                                                     ,reverseOrder:astronautFilter.Reverse
                                                    );
        }

        public Expression<Func<AstronautResponse, object>>? CreateOrderByExpression(AstronautFilter filter)
        {
            if (filter.OrderBy.IsNullOrEmpty())
            {
                return null;
            }


            switch (filter.OrderBy)
            {
                case "age":
                    return a => a.date_of_birth;
                  
                case "spaceWalks":
                    return a => a.spacewalks_count;
                   
                case "flights":
                    return a => a.flights_count;
                
                default:
                    throw new ArgumentException("Invalid value for OrderBy. Valid options are 'age', 'spaceWalk', and 'flights'.");
            }        
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
            if (filter.MinSpaceWalk.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.spacewalks_count >= filter.MinSpaceWalk;
                filterExpressions.Add(expression);
            }

            if (filter.MinFlights.HasValue)
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.flights_count >= filter.MinFlights;
                filterExpressions.Add(expression);
            }

            if (!string.IsNullOrEmpty(filter.AgencyAbbrev))
            {
                Expression<Func<AstronautResponse, bool>> expression = astronaut => astronaut.agency != null && astronaut.agency.abbrev == filter.AgencyAbbrev;
                filterExpressions.Add(expression);
            }

            return filterExpressions;
        }
    }
}

