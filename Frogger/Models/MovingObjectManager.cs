using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class MovingObjectManager
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        public List<Log> Logs = new List<Log>();

        public MovingObjectManager()
        {
            Vehicles.Add(new Car1(Direction.Right, ZeroWidth(), Row(2)));
            Vehicles.Add(new Car1(Direction.Right, HalfWidth(), Row(2)));
            Vehicles.Add(new Car2(Direction.Left, ZeroWidth(), Row(3)));
            Vehicles.Add(new Car2(Direction.Left, HalfWidth(), Row(3)));
            Vehicles.Add(new SportCar1(Direction.Right, ZeroWidth(), Row(4)));
            Vehicles.Add(new SportCar1(Direction.Right, HalfWidth(), Row(4)));
            Vehicles.Add(new SportCar2(Direction.Left, ZeroWidth(), Row(5)));
            Vehicles.Add(new SportCar2(Direction.Left, HalfWidth(), Row(5)));
            Vehicles.Add(new Truck(Direction.Right, ZeroWidth(), Row(6)));
            Vehicles.Add(new Truck(Direction.Right, HalfWidth(), Row(6)));
            Vehicles.Add(new Bus(Direction.Left, ZeroWidth(), Row(7)));
            Vehicles.Add(new Bus(Direction.Left, HalfWidth(), Row(7)));

            Logs.Add(new Log(LogWidth.Short, ZeroWidth(), Row(9), 5));
            Logs.Add(new Log(LogWidth.Medium, HalfWidth(), Row(9), 5));
            Logs.Add(new Log(LogWidth.Long, ZeroWidth(), Row(10), 2));
            Logs.Add(new Log(LogWidth.Short, HalfWidth(), Row(10), 2));
            Logs.Add(new Log(LogWidth.Short, ZeroWidth(), Row(11), 3));
            Logs.Add(new Log(LogWidth.Medium, HalfWidth(), Row(11), 3));
            Logs.Add(new Log(LogWidth.Short, ZeroWidth(), Row(12), 2));
            Logs.Add(new Log(LogWidth.Medium, HalfWidth(), Row(12), 2));
            Logs.Add(new Log(LogWidth.Short, ZeroWidth(), Row(13), 5));
            Logs.Add(new Log(LogWidth.Short, HalfWidth(), Row(13), 5));
        }

        public void DrawAndUpdateVehicles(Graphics g)
        {
            foreach (var vehicle in Vehicles)
            {
                vehicle.Draw(g);
                vehicle.Move();
            }
        }

        public void DrawAndUpdateLogs(Graphics g)
        {
            foreach (var log in Logs)
            {
                log.Draw(g);
                log.Move();
            }
        }

        public int Row(int row)
        {
            return Settings.WindowHeight - Settings.BoxSize * row;
        }

        public int ZeroWidth()
        {
            return 0;
        }

        public int HalfWidth()
        {
            return Settings.WindowWidth / 2;
        }
    }
}
