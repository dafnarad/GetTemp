using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetTempBusinessLayer.Handlers
{
    public class TemperatureHandler
    {
        public TemperatureDto HandleIncomingRequest(DateTime date, double lat, double lon)
        {
            TemperatureDto temp = new TemperatureDto();
            GetAWSData aws = new GetAWSData();
            temp.TemperatureF= aws.GetDataFromAWS(date, lat,lon);
            return temp;
        }
    }
}
