using GUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.services.implementation
{
    internal class AstronautsGenerator : IAstronautsGenerator
    {

        private readonly int _take;
        private int _skip;

        private readonly IAstronautsClient _astronautsClient;
        public AstronautsGenerator(int take)
        {
            if (take <= 0)
            {
                throw new ArgumentException("The argument must be greater than or equal to 0.", nameof(take));
            }

            _take = take;
            _skip = 0;
            _astronautsClient = new AstronautsClient();
        }


        public async Task<IEnumerable<AstronautResponse>> GetMoreAstronauts()
        {
 
            int oldSkip = _skip;

            this._skip +=   this._take;
            var astronautList = await _astronautsClient.GetAstronaouts(_take, oldSkip);

            if (astronautList != null)
            {
                _skip += _take;
            }
            return astronautList;

        }
    }
}
