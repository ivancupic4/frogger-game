using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class VehicleManager
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();

        public VehicleManager()
        {
            Vehicles.Add(new Vehicle(VehicleType.Car1, Direction.Left, Settings.WindowHeight - Settings.BoxSize * 2));
            Vehicles.Add(new Vehicle(VehicleType.Car2, Direction.Right, Settings.WindowHeight - Settings.BoxSize * 3));
            Vehicles.Add(new Vehicle(VehicleType.SportCar1, Direction.Left, Settings.WindowHeight - Settings.BoxSize * 4));
            Vehicles.Add(new Vehicle(VehicleType.SportCar2, Direction.Right, Settings.WindowHeight - Settings.BoxSize * 5));
            Vehicles.Add(new Vehicle(VehicleType.Truck, Direction.Left, Settings.WindowHeight - Settings.BoxSize * 6));
            Vehicles.Add(new Vehicle(VehicleType.Bus, Direction.Right, Settings.WindowHeight - Settings.BoxSize * 7));
        }

        public void DrawAndUpdateVehicles(Graphics g)
        {
            foreach (var vehicles in Vehicles)
            {
                vehicles.Draw(g);
                vehicles.Update();
            }
        }
    }
}
