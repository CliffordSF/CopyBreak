using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BeeHiveSimulatorGraphicalVersion
{
    class Bee
    {
        public enum BeeState
        {
            Idle,
            FlyingToFlower,
            GatheringNectar,
            ReturningToHive,
            MakingHoney,
            Retired
        }
        private const double HoneyConsumed = 0.5;
        private const int MoveRate = 3;
        private const double MinimumFlowerNectar = 1.5;
        private const int CareerSpan = 1000;

        public BeeState CurrentState { get; private set; }
        private World world;
        private Hive hive;

       // public enum CurrentState { get; set; }

        public int Age { get; private set; }
        public bool InsideHive { get; private set; }
        public double NectarCollected { get; private set; }

        private Point location;
        public Point Location { get { return location; } }
        private int ID;
        private Flower destinationFlower;

        public Bee (int id, Point location,  World world, Hive hive)
        {
            this.ID = id;
            Age = 0;
            this.location = location;
            this.world = world;
            this.hive = hive;
            InsideHive = true;
            destinationFlower = null;
            NectarCollected = 0;
            CurrentState = BeeState.Idle;
        }
        public void Go(Random random)
        {
            Age++;
            switch (CurrentState)
            {
                case BeeState.Idle:
                    if (Age > CareerSpan)
                    {
                        CurrentState = BeeState.Retired;
                    }
                    else
                    {
                        // What do we do if we're idle?
                    }
                    break;
                case BeeState.FlyingToFlower:
                    // move toward the flower we're heading to
                    break;
                case BeeState.GatheringNectar:
                    double nectar = destinationFlower.HarvestNectar();
                    if (nectar > 0)
                        NectarCollected += nectar;
                    else
                        CurrentState = BeeState.ReturningToHive;
                    break;
                case BeeState.ReturningToHive:
                    if (!InsideHive)
                    {
                        //move toward hive
                    }
                    else
                    {
                        // what do we do if we're inside the hive?
                    }
                    break;
                case BeeState.MakingHoney:
                    if (NectarCollected < 0.5)
                    {
                        NectarCollected = 0;
                        CurrentState = BeeState.Idle;
                    }
                    else
                    {
                        //once we have a hive, we'll turn the nectar into honey
                    }
                    break;
                case BeeState.Retired:
                    // Do nothing! We're retired!
                    break;
            }
        }
        private bool MoveTowardsLoction(Point destination)
        {
            if (destination != null)
            {
                if (Math.Abs(destination.X - location.X) <= MoveRate &&
                    Math.Abs(destination.Y - location.Y) <= MoveRate)
                    return true;
                if (destination.X > location.X)
                    location.X += MoveRate;
                else if (destination.X < location.X)
                    location.X -= MoveRate;
                if (destination.Y > location.Y)
                    location.Y += MoveRate;
                else if (destination.Y < location.Y)
                    location.Y -= MoveRate;
            }
            return false;
        }
       

      }
}
