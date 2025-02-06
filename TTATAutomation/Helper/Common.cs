namespace TTATAutomation.Helpers
{
    public enum VehicleType
    {
        Compact = 1, Standard = 2, Oversized = 3
    }
    public enum WeighmentStatus
    {
        FirstWeighmentRecorded = 1, SecondWeighmentRecorded = 2, Approved = 3
    }
    public enum VehicleLocation
    {
        ParkingGate = 1, Parking = 2, ParkingExit = 3, Weighbridge = 4, WeighbridgeExit = 5, LoadingBay = 6, UnloadingBay = 7, Weighment = 8, WeighmentExit = 9, WeighmentApproval = 10, WeighmentApprovalExit = 11, PlantGate = 12, PlantExit = 13
    }
    public enum WeighmentType
    {
        Loading = 1, Unloading = 2
    }
    public static class WeighmentSettings
    {
        public static decimal MinNetWeight { get; set; } = 1000; // Minimum allowed net weight in kg
        public static decimal MaxNetWeight { get; set; } = 50000; // Maximum allowed net weight in kg
        public static decimal TolerancePercentage { get; set; } = 5; // Allowed weight variation percentage
    }
}