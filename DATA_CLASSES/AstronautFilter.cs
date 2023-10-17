using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA_CLASSES
{
    public class AstronautFilter
    {

        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to 0.")]
        public int Skip { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to 1.")]
        public int Take { get; set; }
        public DateTime? MinBirthDate { get; set; }
        public DateTime? MaxBirthDate { get; set; }

        public bool? IsInSpace { get; set; }
        public bool? IsAlive { get; set; }

        public string? AgencyName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to 0.")]
        public int? MinDaysInSpace { get; set; }
    }
}
