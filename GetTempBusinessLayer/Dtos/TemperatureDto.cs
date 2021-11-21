using System;

namespace GetTempBusinessLayer
{
    public class TemperatureDto
    {
        public DateTime Date { get; set; }

        public double TemperatureC => (TemperatureF - 32) * 5 / 9;

        public double TemperatureF { get; set; } //=> 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public double lon { get; set; }

        public double lat { get; set; }
        
    }
}
