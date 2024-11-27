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
            Vehicles.Add(new Car1(Direction.Right, 0, Settings.WindowHeight - Settings.BoxSize * 2));
            Vehicles.Add(new Car1(Direction.Right, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 2));
            Vehicles.Add(new Car2(Direction.Left, 0, Settings.WindowHeight - Settings.BoxSize * 3));
            Vehicles.Add(new Car2(Direction.Left, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 3));
            Vehicles.Add(new SportCar1(Direction.Right, 0, Settings.WindowHeight - Settings.BoxSize * 4));
            Vehicles.Add(new SportCar1(Direction.Right, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 4));
            Vehicles.Add(new SportCar2(Direction.Left, 0, Settings.WindowHeight - Settings.BoxSize * 5));
            Vehicles.Add(new SportCar2(Direction.Left, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 5));
            Vehicles.Add(new Truck(Direction.Right, 0, Settings.WindowHeight - Settings.BoxSize * 6));
            Vehicles.Add(new Truck(Direction.Right, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 6));
            Vehicles.Add(new Bus(Direction.Left, 0, Settings.WindowHeight - Settings.BoxSize * 7));
            Vehicles.Add(new Bus(Direction.Left, Settings.WindowWidth / 2, Settings.WindowHeight - Settings.BoxSize * 7));
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
