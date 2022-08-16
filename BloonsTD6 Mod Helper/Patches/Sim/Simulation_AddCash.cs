﻿using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Tracking;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(AnalyticsTrackerSimManager), nameof(AnalyticsTrackerSimManager.OnCashEarned))]
internal static class AnalyticsTrackerSimManager_OnCashEarned {
    [HarmonyPostfix]
    private static void Postfix(int playerId, double cash,
        Simulation.CashType from, Simulation.CashSource source, Tower tower) {
        ModHelper.PerformHook(mod => mod.OnCashAdded(cash, from, playerId, source, tower));
    }
}