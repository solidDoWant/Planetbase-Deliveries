using Harmony;

namespace Planetbase_Deliveries.Patches.Planetbase.ColonyShip
{
    /// <summary>
    /// This class disabled recycling until the ship has actually landed
    /// </summary>
    
    [HarmonyPatch(typeof(global::Planetbase.ColonyShip))]
    [HarmonyPatch("isDeleteable")]
    public class IsDeleteable
    {
        public static void Postfix(out bool buttonEnabled, ref bool __result)
        {
            __result = __result && DeliveriesMod.Ship.isDone();
            buttonEnabled = __result;
        }
    }
}