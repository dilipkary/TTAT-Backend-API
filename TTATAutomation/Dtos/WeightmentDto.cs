
using TTATAutomation.Helpers;

namespace TTATAutomation.Data.Dto
{
    public class WeighmentAddDto
    {
        public string RFIDTag { get; set; }
        public decimal Weight { get; set; }
        public WeighmentType WeighmentType { get; set; }
        public Guid VehicleNumber { get; set; }
    }
    public class WeighmentAddDto2
    {
        public decimal Weight { get; set; }
        public Guid VehicleNumber { get; set; }
    }
    public class WeighmentAddRequestDto
    {
        public string RFIDTag { get; set; }
        public decimal Weight { get; set; }
        //public WeighmentType WeighmentType { get; set; }
    }
}