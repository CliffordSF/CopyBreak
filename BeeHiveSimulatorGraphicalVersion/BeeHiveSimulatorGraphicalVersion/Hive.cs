using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BeeHiveSimulatorGraphicalVersion
{
    class Hive
    {
        public double Honey { get; private set; }
        private Dictionary<string, Point> locations;
        private int beeCount;
        private World world;

        public const int initialBeesInHive = 6;
        public const double initialHoneyInHive = 3.2;
        public const double maxHoneyStoredInHive = 15;
        public const double ratioNectarToHoney = 0.25;
        public const int maxBees = 8;
        public const double minHoneyForBabies = 4;

        public Point GetLocation(string location)
        {
            if(locations.Keys.Contains(location))
            {
                return locations[location];
            }
            else
            {
                throw new ArgumentException("Unknown location " + location);
            }
        }

        public void initializeLocations()
        {
            locations = new Dictionary<string,Point>();
            locations.Add("Entrance", new Point (600, 100));
            locations.Add("Nursery", new Point(95, 174));
            locations.Add("HoneyFactory", new Point(157, 98));
            locations.Add("Exit", new Point(194, 213));
        }
        public Hive(World world)
        {
            this.world = world;
            Honey = initialHoneyInHive;
            initializeLocations();
            Random random = new Random();
            for(int i = 0; i < initialBeesInHive; i++)
                AddBee(random);
            
        }
        public bool AddHoney(double nectar)
        {
            double honeyToAdd = nectar * ratioNectarToHoney;
            if (honeyToAdd + Honey > maxHoneyStoredInHive)
                return false;
            Honey += honeyToAdd;
            return true;
        }

        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey)
                return false;
            else
                Honey -= amount;
            return true;

        }

        private void AddBee(Random random)
        {
            beeCount++;
            int r1 = random.Next(100) - 50;
            int r2 = random.Next(100) - 50;
            Point startPoint = new Point(locations["Nursery"].X + r1, locations["Nursery"].Y + r2);

            Bee newBee = new Bee (beeCount, startPoint, world, this);
            // Once we have a system, we need to add this bee to the system
        }
        public void Go(Random random)
        {
            if (Honey > minHoneyForBabies && random.Next(10) == 1)
            {
                AddBee(random);
            }



        }


        }
    }

