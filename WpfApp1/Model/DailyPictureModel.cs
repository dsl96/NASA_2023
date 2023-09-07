using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA_CLASSES;
using API.services.implementation;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Net.Http;

namespace GUI.Model
{
    internal class DilyPictureModel
    {
        NasaDailyImageResponse NasaDailyImageResponse { get; set; }
        NasaService nasaService { get; set; }

        public DilyPictureModel() {
            nasaService = new NasaService();
            NasaDailyImageResponse = NasaService.GetDailyImage();
        }
    }
}
