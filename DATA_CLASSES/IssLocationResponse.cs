using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_CLASSES
{
    public class IssLocationResponse
    {
        public string? message { get; set; }
        public DateTime dateTime { get; set; }
        public IssPosition iss_position { get; set; }
        public byte[]? imageData { get; set; }  
    }

    public class IssPosition
    {
        public Double latitude { get; set; }
        public Double longitude { get; set; }
    }
}
