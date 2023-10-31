using GUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace GUI.services.implementation
{
    internal class AstronautsGenerator : IAstronautsGenerator
    {

        

        private readonly IAstronautsClient _astronautsClient;
        private readonly AstronautFilter  _astronautFilter;
        public AstronautsGenerator( AstronautFilter astronautFilter)
        {
            astronautFilter.Take = 20;
            astronautFilter.Skip = 0;
             
            _astronautsClient = new AstronautsClient();
            this._astronautFilter = astronautFilter;
        }

      
        public async Task<IEnumerable<AstronautResponse>> GetMoreAstronauts()
        {      
            
           
            var astronautList = await _astronautsClient.GetAstronaouts(_astronautFilter);
            
            if (astronautList != null)
            {
                _astronautFilter.Skip +=_astronautFilter.Take;
            }
            return astronautList;

        }
    }
}
