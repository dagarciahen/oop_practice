using Xunit;
using vehicle;

public class parkingLogTest
{
	[Fact]
	public void Test()
	{
		Console.WriteLine("Testing Car");
		Vehicle car = new Car("CarAbc123");
		Vehicle moto = new MotorCycle("MotoABC123");
		Vehicle truck = new Truck("TRUCKABC123");

		Assert.Equal(VehicleSize.MEDIUM, car.getVehicleSize());
		Assert.Equal("TRUCKABC123", truck.getLicensePlate());

		Console.WriteLine("TestingSpots");

		ParkingSpot small = new CompactSpot(1);
		ParkingSpot Medium = new MediumSpot(1);
		Assert.Equal(VehicleSize.SMALL, small.getSize(1));
		 
		
  }

}
