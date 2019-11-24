using System;
using PlanetbaseFramework;

namespace Planetbase_Deliveries
{
    public class DeliveriesMod : ModBase
    {
        public override string ModName { get; } = "DeliveriesMod";

        public const string AssemblyVersion = "1.0.0.0";
        public override Version ModVersion { get; } = new Version(AssemblyVersion);

        public override void Init()
        {
            InjectPatches();
        }
    }
}