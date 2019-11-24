using System;
using Planetbase;
using PlanetbaseFramework;

namespace Planetbase_Deliveries
{
    public class DeliveriesMod : ModBase
    {
        public override string ModName { get; } = "Deliveries";

        public const string AssemblyVersion = "1.0.0.0";
        public override Version ModVersion { get; } = new Version(AssemblyVersion);

        public static bool ActiveDeliveryShip { get; set; }
        public static ColonyShip Ship { get; set; }

        public override void Init()
        {
            InjectPatches();
        }

        public override void Update()
        {
            if (!ActiveDeliveryShip) return;

            //Wait for a ship to land and be recycled before sending another
            if (Ship.isDone() && Ship.mObject == null)
            {
                ActiveDeliveryShip = false;
            }
        }
    }
}