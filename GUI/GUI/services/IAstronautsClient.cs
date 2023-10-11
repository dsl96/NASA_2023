using GUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.services
{
    internal interface IAstronautsClient
    {
        Task<IEnumerable<AstronautResponse>> GetAstronaouts(int take, int skip = 0);
    }
}
