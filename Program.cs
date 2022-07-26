using VehicleTestTask;

var passengerCar = new PassengerCar(VehicleType.Gasoline, 5.0f, 40.0f, 30.0f, 4);

passengerCar.FuelTankVolume = 25;
Console.WriteLine(passengerCar.GetMaxDistanceOnRemainingFuel());
Console.WriteLine(passengerCar.GetMaxDistanceOnRemainingFuel(true));
passengerCar.NumberOfPassengers = 3;

Console.WriteLine(passengerCar.GetMaxDistanceOnRemainingFuel());
Console.WriteLine(passengerCar.GetMaxDistanceOnRemainingFuel(true));

var freightCar = new FreightСar(VehicleType.Gasoline, 5.0f, 40.0f, 30.0f, 700);

freightCar.FuelTankVolume = 25;
Console.WriteLine(freightCar.GetMaxDistanceOnRemainingFuel());
Console.WriteLine(freightCar.GetMaxDistanceOnRemainingFuel(true));
freightCar.CargoWeight = 599;

Console.WriteLine(freightCar.GetMaxDistanceOnRemainingFuel());
Console.WriteLine(freightCar.GetMaxDistanceOnRemainingFuel(true));


