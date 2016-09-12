using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BeeHiveSimulatorGraphicalVersion
{
    class Flower
    {
        public const int LifeSpanMin = 15000;
        public const int LifeSpanMax = 30000;
        public const double InitialNectar = 1.5;
        public const double MaxNectar = 5.0;
        public const double NectarAddedPerTurn = 0.01;
        public const double NectarGatheredPerTurn = 0.03;

        public Point Location { get; private set; }
        public int Age { get; private set; }
        public bool Alive { get; private set; }
        public double Nectar { get; private set; }
        public double NectarHarvested { get; set; }
        private int Lifespan;

        public double HarvestNectar()
        {
            if(NectarGatheredPerTurn > Nectar)
                return 0;
            else
            {
                Nectar = Nectar - NectarGatheredPerTurn;
                NectarHarvested = NectarHarvested + NectarGatheredPerTurn;
                return NectarHarvested;
               
            }

        }

        public void Go()
        {
            this.Age = this.Age + 1;
            if (Age > this.Lifespan)
                this.Alive = false;
            else
            {
                Nectar += NectarAddedPerTurn;
                if (Nectar > MaxNectar)
                    Nectar = MaxNectar;
            }


            if (Nectar > MaxNectar)
                Nectar = MaxNectar;
        }

        public Flower(Point location, Random random)
        {
            Location = location;
            random = new Random();
            Age = 0;
            Alive = true;
            Nectar = InitialNectar;
            Lifespan = random.Next(LifeSpanMin, LifeSpanMax + 1);

        }
    }
}
