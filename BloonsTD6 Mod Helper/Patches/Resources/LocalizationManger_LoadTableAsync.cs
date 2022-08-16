﻿using System;

using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;

using NinjaKiwi.Common;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(LocalizationManager._LoadTableAsync_d__45),
    nameof(LocalizationManager._LoadTableAsync_d__45.MoveNext))]
internal static class LocalizationManger_LoadTableAsync {
    [HarmonyPostfix]
    private static void Postfix(LocalizationManager._LoadTableAsync_d__45 __instance) {
        if (!MelonLoaderChecker.IsVersionNewEnough()) return;

        var result = __instance.__t__builder.Task.Result;
        if (result != null) {
            foreach (var namedModContent in ModContent.GetContent<NamedModContent>()) {
                try {
                    namedModContent.RegisterText(result);
                } catch (Exception e) {
                    ModHelper.Log($"Failed to register text for {namedModContent}");
                    ModHelper.Error(e);
                }
            }
        }
    }
}