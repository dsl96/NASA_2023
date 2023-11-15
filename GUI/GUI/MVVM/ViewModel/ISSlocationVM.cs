using GUI.command;
using GUI.models;
using GUI.services;
using GUI.services.implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.MVVM.ViewModel
{
    internal class ISSlocationVM : ViewModelBase
    {
        public string Text { get; set; }
        public IssDataResponse _IssLocation { get; set; }


        private IssClient _IssClient { get; set; }

        public IssDataResponse ISSDataResponse
        {
            get { return _IssLocation; }
            set
            {
                _IssLocation = value;
                OnPropertyChanged("ISSDataResponse");
            }
        }

        public ISSlocationVM()
        {
            var IssLocation = new IssClient().GetIssLocation();
            new Thread(() => RefreshData()).Start();
            Text = "The International Space Station (ISS) is a remarkable, multinational collaborative effort in space exploration. It serves as a microgravity research laboratory and an orbiting home for astronauts from various countries. Launched in 1998, the ISS is a symbol of international cooperation, involving space agencies such as NASA (United States), Roscosmos (Russia), ESA (European Space Agency), JAXA (Japan Aerospace Exploration Agency), and CSA (Canadian Space Agency).\r\n\r\nOrbiting the Earth at an average altitude of approximately 420 kilometers (261 miles), the ISS facilitates scientific experiments in a unique microgravity environment. Researchers from around the globe utilize the station to conduct experiments in physics, biology, astronomy, and materials science, providing valuable insights that benefit life on Earth and contribute to our understanding of space.\r\n\r\nThe ISS consists of multiple interconnected modules, laboratories, and solar arrays, creating a space-based environment for scientific discovery, technological advancements, and international collaboration. Manned by rotating crews of astronauts, the ISS continues to be a beacon of human achievement, fostering scientific innovation and strengthening global partnerships in the exploration of outer space.";

        }

        private async void RefreshData()
        {
            //int times = 0;
            while (true)
            {
                ISSDataResponse = await new IssClient().GetIssLocation();
                Thread.Sleep(5000);
                //times++;
            }
        }
    }
}
