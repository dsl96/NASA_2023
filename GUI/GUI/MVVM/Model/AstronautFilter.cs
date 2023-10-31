using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{
    public class AstronautFilter
    {     
        public int Skip { get; set; }
        public int Take { get; set; }
        public DateTime? MinBirthDate { get; set; }
        public DateTime? MaxBirthDate { get; set; }

        public bool IsInSpace { get; set; } = false;
        public bool IsAlive { get; set; } = true;

        public string AgencyAbbrev { get; set; }
        
        public int? MinSpaceWalk { get; set; }
        public int? MinFlights { get; set; }


        public bool Reverse { get; set; }

        public string OrderBy { get; set; }



        private static readonly IEnumerable<string> orderByOptions = new List<string>
        {

        "age",
        "spaceWalks",
        "flights",
        };

     

        public bool IsValidOrderBy()
        {
            return string.IsNullOrEmpty(OrderBy) || OrderByOptions.Contains(OrderBy);
        }

        public IEnumerable<string> OrderByOptions
        {
            get { return orderByOptions; }
        }

    }
}
