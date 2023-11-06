using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{
    public class AstronautFilter : ICloneable
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

        public AstronautFilter()
        {
        }

        public AstronautFilter(AstronautFilter other)
        {
            this.Skip = other.Skip;
            this.Take = other.Take;
            this.MinBirthDate = other.MinBirthDate;
            this.MaxBirthDate = other.MaxBirthDate;
            this.IsInSpace = other.IsInSpace;
            this.IsAlive = other.IsAlive;
            this.AgencyAbbrev = other.AgencyAbbrev;
            this.MinSpaceWalk = other.MinSpaceWalk;
            this.MinFlights = other.MinFlights;
            this.Reverse = other.Reverse;
            this.OrderBy = other.OrderBy;
        }

        public object Clone()
        {
            return new AstronautFilter(this);
        }

        public IEnumerable<string> OrderByOptions
        {
            get { return orderByOptions; }
        }

    }
}
