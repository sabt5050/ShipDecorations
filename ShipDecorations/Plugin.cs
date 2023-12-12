using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using ShipDecorations.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDecorations
{
    public static class ConfigSettings
    {
        public static ConfigEntry<bool> makeShipDecorationsFree;

        public static void BindConfigSettings()
        {
            //ShipDecorationsUnlockedModBase.Instance.log.Log("BindingConfigs");
            //makeShipDecorationsFree = ((BaseUnityPlugin)ShipDecorationsUnlockedModBase.instance).Config.Bind<bool>("ShipDecorations", "MakeDecorationsFree", false, "Make all of the ship decorations free");
        }

        public static string GetDisplayName(string key)
        {
            key = key.Replace("<Keyboard>/", "");
            key = key.Replace("<Mouse>/", "");
            string text = key;
            text = text.Replace("leftAlt", "Alt");
            text = text.Replace("rightAlt", "Alt");
            text = text.Replace("leftCtrl", "Ctrl");
            text = text.Replace("rightCtrl", "Ctrl");
            text = text.Replace("leftShift", "Shift");
            text = text.Replace("rightShift", "Shift");
            text = text.Replace("leftButton", "LMB");
            text = text.Replace("rightButton", "RMB");
            return text.Replace("middleButton", "MMB");
        }
    }

    [BepInPlugin(modGUID, modName, modVersion)]
    public class ShipDecorationsUnlockedModBase : BaseUnityPlugin
{
    private const string modGUID = "Sant.ShipDecorationsUnlock";
    private const string modName = "Unlock Ship Decorations";
    private const string modVersion = "1.0.0.0";

    private readonly Harmony harmony = new Harmony(modGUID);

    public static ShipDecorationsUnlockedModBase instance;

    internal ManualLogSource mls;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //ConfigSettings.BindConfigSettings();

        mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

        mls.LogInfo("The Ship Decorations Unlock mod has awaken");

        harmony.PatchAll(typeof(ShipDecorationsUnlockedModBase));
        harmony.PatchAll(typeof(ShipDecorationsUnlockedPatch));
    }
        public static void Log(string message)
        {
            ShipDecorationsUnlockedModBase.Log(message);
        }
}
}
