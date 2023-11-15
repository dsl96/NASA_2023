using GUI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.services
{
    internal interface IIssClient
    {

        Task<IssDataResponse> GetIssLocation();
        
    }
}
