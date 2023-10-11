using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{

    public class AstronautResponse
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Status status { get; set; }
        public bool? in_space { get; set; }
        public string time_in_space { get; set; }
        public string eva_time { get; set; }
        public int? age { get; set; }
        public DateTime? date_of_birth { get; set; }
        public DateTime? date_of_death { get; set; }
        public string nationality { get; set; }
        public string bio { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string wiki { get; set; }
        public Agency agency { get; set; }
        public string profile_image { get; set; }
        public string profile_image_thumbnail { get; set; }
        public int? flights_count { get; set; }
        public int? landings_count { get; set; }
        public int? spacewalks_count { get; set; }
        public DateTime? last_flight { get; set; }
        public DateTime? first_flight { get; set; }
    }
    public class Agency
    {
 
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public bool? featured { get; set; }
        public string type { get; set; }
        public string country_code { get; set; }
        public string abbrev { get; set; }
        public string description { get; set; }
        public string administrator { get; set; }
        public string founding_year { get; set; }
        public string launchers { get; set; }
        public string spacecraft { get; set; }
        public string logo_url { get; set; }
    }


    public class Status
    {
 
        public int? stausId { get; set; }

 
        public string Name { get; set; }
    }
}

