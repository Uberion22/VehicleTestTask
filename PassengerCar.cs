namespace VehicleTestTask
{
    internal class PassengerCar: Vehicle
    {
        private int _numberOfPassengers;
        private readonly float _distanceMarginReduction = 0.06f;

        public int NumberOfPassengers
        {
            get => _numberOfPassengers;
            set
            {
                if (value > MaxNumberOfPassengers)
                {
                    throw new ArgumentOutOfRangeException($"The number of passengers must be between 0 and {MaxNumberOfPassengers}");
                }
                _numberOfPassengers = value;
            }
        }

        public PassengerCar(VehicleType vehicleEngineType, float averageFuelConsumption, float maxFuelTankVolume, float averageSpeed, int maxNumberOfPassengers) 
            : base(vehicleEngineType, averageFuelConsumption, maxFuelTankVolume, averageSpeed)
        {
            MaxNumberOfPassengers = maxNumberOfPassengers;
        }

        /// <summary>
        /// Get the maximum trip distance by remaining fuel level or full tank fuel level and number of Passengers.
        /// </summary>
        /// <param name="useFullFuelTank">Use a full tank for calculations</param>
        /// <returns>Maximum trip distance</returns>
        public override float GetMaxDistanceOnRemainingFuel(bool useFullFuelTank = false)
        {
            return base.GetMaxDistanceOnRemainingFuel(useFullFuelTank) * GetTotalDistanceMarginReduction(); 
        }

        private float GetTotalDistanceMarginReduction()
        {
            return 1.0f - _numberOfPassengers * _distanceMarginReduction;
        }
    }
}
