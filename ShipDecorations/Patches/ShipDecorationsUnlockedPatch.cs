using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShipDecorations.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class ShipDecorationsUnlockedPatch
    {

        //[HarmonyPatch(nameof(Terminal.ShipDecorSelection))]
        [HarmonyPatch(nameof(Terminal.RotateShipDecorSelection))]
        [HarmonyPostfix]
        static void unlockAllShipDecorations(ref List<TerminalNode> ___ShipDecorSelection)
        {
            ___ShipDecorSelection.Clear();
            List<TerminalNode> list = new List<TerminalNode>();
            for (int i = 0; i < StartOfRound.Instance.unlockablesList.unlockables.Count; i++)
            {
                if (StartOfRound.Instance.unlockablesList.unlockables[i].shopSelectionNode != null && !StartOfRound.Instance.unlockablesList.unlockables[i].alwaysInStock)
                {
                    list.Add(StartOfRound.Instance.unlockablesList.unlockables[i].shopSelectionNode);
                }
            }

            for (int j = 0; j < list.Count; j++)
            {
                TerminalNode item = list[j];
                //ShipDecorationsUnlockedModBase.Log("Adding item " + item.name);
                //if (ConfigSettings.makeShipDecorationsFree.Value)
                //{
                //    item.itemCost = 0;
                    //ShipDecorationsUnlockedModBase.Log("Setting cost of item " + item.name + " to 0");
                //}
                ___ShipDecorSelection.Add(item);
            }
        }
    }
}
