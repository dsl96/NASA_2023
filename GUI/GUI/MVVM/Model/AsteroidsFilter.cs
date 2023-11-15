using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{
    public class AsteroidsFilter
    {
        public string[] GroupProperty { get; set; }

        public string SelectPropertyGroup { get; set; }

        public DateTime MaxDate { set; get; }

        public DateTime StartDate {set; get; }

        public DateTime EndDate { set; get; }

        internal AsteroidsFilter()
        {
            this.GroupProperty = new string[] { "Key", "Hazardous", "Sentry", "None" };
            SelectPropertyGroup = "Key";
            this.StartDate = DateTime.Now.AddDays(-6);
            this.EndDate = DateTime.Now;
            this.MaxDate = DateTime.Now;
        }

    }
}
