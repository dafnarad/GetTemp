using System;

namespace GetTemp
{
    public class TempItem
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public double lon { get; set; }
        
        public double lat { get; set; }
    }
}
