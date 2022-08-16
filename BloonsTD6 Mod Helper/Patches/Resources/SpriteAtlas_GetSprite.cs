using BTD_Mod_Helper.Api;

using UnityEngine;
using UnityEngine.U2D;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(SpriteAtlas), nameof(SpriteAtlas.GetSprite))]
internal static class SpriteAtlas_GetSprite {
    [HarmonyPrefix]
    private static bool Prefix(SpriteAtlas __instance, string name, ref Sprite __result) {
        if (__instance.name == ModContent.HijackSpriteAtlas && ResourceHandler.GetSprite(name) is Sprite spr) {
            spr.texture.mipMapBias = -1;
            __result = spr;
            return false;
        }

        return true;
    }
}