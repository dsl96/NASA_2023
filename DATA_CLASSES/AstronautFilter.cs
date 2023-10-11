using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_CLASSES
{
    internal class AstronautFilter
    {

        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }

        public bool? IsActive { get; set; }


    }
}
