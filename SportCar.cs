namespace VehicleTestTask
{
    internal class SportCar : Vehicle
    {
        public SportCar(VehicleEngineType vehicleEngineType, float averageFuelConsumption, float maxFuelTankVolume, float averageSpeed)
            : base(vehicleEngineType, averageFuelConsumption, maxFuelTankVolume, averageSpeed)
        {
        }
    }
}
