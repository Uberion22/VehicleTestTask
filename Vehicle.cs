namespace VehicleTestTask
{
    internal abstract class Vehicle
    {
        public  VehicleType VehicleEngineType { get; }

        public float AverageFuelConsumption 
        {
            set
            {
                ValueGraterThenZero(value);
                _averageFuelConsumption = value;
            }
            get => _averageFuelConsumption;
        }

        public float FuelTankVolume
        {
            set
            {
                ValueInRange(value,0, _maxFuelTankVolume);
                _fuelTankVolume = value;
            }
            get => _fuelTankVolume;
        }

        public float MaxFuelTankVolume
        {
            set
            {
                ValueGraterThenZero(value);
                _maxFuelTankVolume = value;
            }
            get => _maxFuelTankVolume;
        }

        public float AverageSpeed
        {
            set
            {
                ValueGraterThenZero(value);
                _averageSpeed = value;
            }
            get => _averageSpeed;
        }

        public float MaxCargoWeight
        {
            set
            {
                ValueGraterOrEqualsThenZero(value);
                _maxCargoWeight = value;
            }
            get => _maxCargoWeight;
        }

        public int MaxNumberOfPassengers
        {
            set
            {
                ValueGraterOrEqualsThenZero(value);
                _maxNumberOfPassengers = value;
            }
            get => _maxNumberOfPassengers;
        }

        private float _averageFuelConsumption;
        private float _fuelTankVolume;
        private float _maxFuelTankVolume;
        private float _averageSpeed;
        private float _maxCargoWeight;
        private int _maxNumberOfPassengers;

        protected Vehicle(VehicleType vehicleEngineType, float averageFuelConsumption, float maxFuelTankVolume,float averageSpeed)
        {
            VehicleEngineType = vehicleEngineType;
            _averageFuelConsumption = averageFuelConsumption;
            _maxFuelTankVolume = maxFuelTankVolume;
            _averageSpeed = averageSpeed;
        }



        /// <summary>
        /// Get the maximum trip distance by remaining fuel level or full tank fuel level.
        /// </summary>
        /// <param name="useFullFuelTank">Use a full tank for calculations</param>
        /// <returns>Maximum trip distance</returns>
        public virtual float GetMaxDistanceOnRemainingFuel(bool useFullFuelTank = false)
        {
            var result = useFullFuelTank 
                ? MaxFuelTankVolume / AverageFuelConsumption 
                : FuelTankVolume > 0 
                    ? FuelTankVolume / AverageFuelConsumption
                    : 0;
            return result;
        }

        /// <summary>
        /// Get travel time using distance and amount of fuel.
        /// </summary>
        /// <param name="fuel">Available amount of fuel</param>
        /// <param name="distance">Distance</param>
        /// <returns>-1 if there is not enough fuel, otherwise travel time</returns>
        public virtual float GetTravelTime(float fuel, float distance)
        {
            var distanceOnFuel = fuel / AverageFuelConsumption;
            if (distanceOnFuel < distance)
            {
                return -1;
            }
            return distance / AverageSpeed;
        }

        /// <summary>
        /// Get travel time using distance and current fuelTankVolume.
        /// </summary>
        /// <param name="distance">Distance</param>
        /// <returns>-1 if there is not enough fuel, otherwise travel time</returns>
        public virtual float GetTravelTime(float distance)
        {
            if (GetMaxDistanceOnRemainingFuel() < distance)
            {
                return -1;
            }
            return distance / AverageSpeed;
        }

        /// <summary>
        /// The task does not describe the behavior for the base class
        /// Standard implementation used.
        /// </summary>
        public virtual float GetMaxDistanceByPassengersAndCargoWeight()
        {
            return FuelTankVolume / AverageFuelConsumption;
        }

        /// <summary>
        /// Сhecking if the value is greater than zero.
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <exception cref="ArgumentException">Throws an error if the value is less than zero</exception>
        protected void ValueGraterThenZero(float value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value must be grater then 0.");
            }
        }

        /// <summary>
        /// Сhecking if the value is greater or Equals than zero.
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <exception cref="ArgumentException">Throws an error if the value is less than or equal to zero</exception>
        protected void ValueGraterOrEqualsThenZero(float value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value must be grater or equals then 0.");
            }
        }

        /// <summary>
        /// Check if value is within bounds.
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <param name="leftBound">Minimum value</param>
        /// <param name="rightBound">Maximum value</param>
        /// <exception cref="ArgumentException">Throws an error if the value is less than or equal to zero</exception>
        protected void ValueInRange(float value, float leftBound, float rightBound)
        {
            if (value < leftBound || value > rightBound)
            {
                throw new ArgumentException($"Value must be greater than or equal to {leftBound} and less than or equal to {rightBound}.");
            }
        }
    }
}
