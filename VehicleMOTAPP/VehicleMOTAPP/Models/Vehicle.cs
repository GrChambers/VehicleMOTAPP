namespace VehicleMOTAPP.Models
{

    public class Vehicle
    {
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string PrimaryColour { get; set; }
        public List<MOTTest> MotTests { get; set; }
    }

}
