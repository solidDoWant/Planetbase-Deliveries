using Harmony;
using Planetbase;
using UnityEngine;

namespace Planetbase_Deliveries.Patches.Planetbase.GuiMenuSystem
{
    /// <summary>
    /// Add the deliver ship button to the main menu bar
    /// </summary>

    [HarmonyPatch(typeof(global::Planetbase.GuiMenuSystem))]
    [HarmonyPatch("init")]
    public class InitPatch
    {
       public static void Postfix(global::Planetbase.GuiMenuSystem __instance)
        {
            var buttonIcon = TypeList<ModuleType, ModuleTypeList>.find(typeof(ModuleTypeStorage).Name).getIcon();

            //Create the new button
            var pauseMenuItem = new GuiMenuItem(
                buttonIcon,
                StringList.get("menu_deliver"),
                parameter =>
                {
                    if (DeliveriesMod.ActiveDeliveryShip) return;

                    DeliveriesMod.ActiveDeliveryShip = true;

                    var startPosition = ((GameStateGame) GameManager.getInstance().mGameState).findStartPosition();

                    DeliveriesMod.Ship = global::Planetbase.ColonyShip.create(
                        startPosition + Vector3.up * 100f,
                        startPosition,
                        PlanetManager.getCurrentPlanet().getStartingResources()
                    );
                }
            );

            //Add the new button to the main GUI menu and reorder it
            var mainMenu = __instance.mMenuMain;

            mainMenu.mItems.Remove(__instance.mItemHelp);
            mainMenu.addItem(pauseMenuItem);
            mainMenu.addItem(__instance.mItemHelp);
        }
    }
}