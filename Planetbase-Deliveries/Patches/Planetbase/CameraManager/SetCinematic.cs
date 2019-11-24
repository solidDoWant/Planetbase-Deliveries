using Harmony;
using Planetbase;

namespace Planetbase_Deliveries.Patches.Planetbase.CameraManager
{
    /// <summary>
    /// This class causes the camera to NOT focus on the landing ship during deliveries.
    /// </summary>
    
    [HarmonyPatch(typeof(global::Planetbase.CameraManager))]
    [HarmonyPatch("setCinematic")]
    public class SetCinematic
    {
        public static bool Prefix(Cinematic cimenatic)
        {
            //Skip intro/landing camera cinematics only if a delivery has been called.
            if (cimenatic is IntroCinemetic)
                return !DeliveriesMod.ActiveDeliveryShip;
            
            return true;
        }
    }
}