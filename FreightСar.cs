namespace VehicleTestTask
{
    internal class FreightСar : Vehicle
    {
        private float _cargoWeight;
        private readonly float _distanceMarginReduction = 0.04f;
        private readonly float _cargoWeighReductionStep = 200.0f;
        public float CargoWeight
        {
            set
            {
                ValueGraterOrEqualsThenZero(value);
                _cargoWeight = value;
            }
            get => _cargoWeight;
        }

        public FreightСar(VehicleType vehicleEngineType, float averageFuelConsumption, float maxFuelTankVolume, float averageSpeed, float maxCargoWeight)
            : base(vehicleEngineType, averageFuelConsumption, maxFuelTankVolume, averageSpeed)
        {
            MaxCargoWeight = maxCargoWeight;
        }

        /// <summary>
        /// Get the maximum trip distance by remaining fuel level or full tank fuel level and current cargo weight.
        /// </summary>
        /// <param name="useFullFuelTank">Use a full tank for calculations</param>
        /// <returns>Maximum trip distance</returns>
        public override float GetMaxDistanceOnRemainingFuel(bool useFullFuelTank = false)
        {
            return base.GetMaxDistanceOnRemainingFuel(useFullFuelTank) * GetTotalDistanceMarginReduction();
        }

        /// <summary>
        /// Check whether the weight of the new load will exceed the maximum permissible value.
        /// </summary>
        /// <param name="newCargoWeight">Weight of added cargo</param>
        /// <param name="isNoCargoYet">Make calculations without already existing cargo</param>
        /// <returns>True if the weight of the cargo does not exceed the maximum allowable value, otherwise false</returns>
        public bool CanPutCargoOnBoard(float newCargoWeight, bool isNoCargoYet = false)
        {
            if (isNoCargoYet)
            {
                return newCargoWeight <= MaxCargoWeight;
            }

            return newCargoWeight + CargoWeight <= MaxCargoWeight;
        }

        private float GetTotalDistanceMarginReduction()
        {
            return 1.0f - ((float)Math.Floor(CargoWeight / _cargoWeighReductionStep) * _distanceMarginReduction);
        }
    }
}