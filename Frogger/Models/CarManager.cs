using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class CarManager
    {
        public List<Car> Cars = new List<Car>();

        public CarManager()
        {
            Cars.Add(new Car(Direction.Left, Settings.WindowHeight - Settings.BoxSize * 7));
            Cars.Add(new Car(Direction.Right, Settings.WindowHeight - Settings.BoxSize * 6));
            Cars.Add(new Car(Direction.Left, Settings.WindowHeight - Settings.BoxSize * 5));
            Cars.Add(new Car(Direction.Right, Settings.WindowHeight - Settings.BoxSize * 4));
            Cars.Add(new Car(Direction.Left, Settings.WindowHeight - Settings.BoxSize * 3));
            Cars.Add(new Car(Direction.Right, Settings.WindowHeight - Settings.BoxSize * 2));
        }

        public void DrawAndUpdateCars(Graphics g)
        {
            foreach (var car in Cars)
            {
                car.Draw(g);
                car.Update();
            }
        }
    }
}
