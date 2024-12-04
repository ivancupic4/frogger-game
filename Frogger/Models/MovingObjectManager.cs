﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    public class MovingObjectManager
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        public List<Turtle> Turtles = new List<Turtle>();
        public List<Log> Logs = new List<Log>();

        public MovingObjectManager()
        {
            Vehicles.Add(new Car1(Direction.Right, Beginning(), Row(2)));
            Vehicles.Add(new Car1(Direction.Right, HalfWidth(), Row(2)));
            Vehicles.Add(new Car2(Direction.Left, Beginning(), Row(3)));
            Vehicles.Add(new Car2(Direction.Left, HalfWidth(), Row(3)));
            Vehicles.Add(new SportCar1(Direction.Right, Beginning(), Row(4)));
            Vehicles.Add(new SportCar1(Direction.Right, HalfWidth(), Row(4)));
            Vehicles.Add(new SportCar2(Direction.Left, Beginning(), Row(5)));
            Vehicles.Add(new SportCar2(Direction.Left, HalfWidth(), Row(5)));
            Vehicles.Add(new Truck(Direction.Right, Beginning(), Row(6)));
            Vehicles.Add(new Truck(Direction.Right, HalfWidth(), Row(6)));
            Vehicles.Add(new Bus(Direction.Left, Beginning(), Row(7)));
            Vehicles.Add(new Bus(Direction.Left, HalfWidth(), Row(7)));

            Turtles.Add(new Turtle(Width.Short, Beginning(), Row(9), 5));
            Turtles.Add(new Turtle(Width.Medium, HalfWidth(), Row(9), 5));
            Turtles.Add(new Turtle(Width.Short, Beginning(), Row(12), 2));
            Turtles.Add(new Turtle(Width.Medium, HalfWidth(), Row(12), 2));

            Logs.Add(new Log(Width.Long, Beginning(), Row(10), 2));
            Logs.Add(new Log(Width.Short, HalfWidth(), Row(10), 2));
            Logs.Add(new Log(Width.Short, Beginning(), Row(11), 3));
            Logs.Add(new Log(Width.Medium, HalfWidth(), Row(11), 3));
            Logs.Add(new Log(Width.Short, Beginning(), Row(13), 5));
            Logs.Add(new Log(Width.Short, HalfWidth(), Row(13), 5));
        }

        public void DrawAndUpdateVehicles(Graphics g)
        {
            foreach (var vehicle in Vehicles)
            {
                vehicle.Draw(g);
                vehicle.Move();
            }
        }

        public void DrawAndUpdateTurtles(Graphics g)
        {
            foreach (var turtle in Turtles)
            {
                turtle.Draw(g);
                turtle.Move();
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

        public int Row(int row) => Settings.WindowHeight - Settings.BoxSize * row;

        public int Beginning() => 0;

        public int HalfWidth() => Settings.WindowWidth / 2;
    }
}
