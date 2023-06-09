﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using pierce_without_tde_06;

[assembly: MelonInfo(typeof(PierceWithoutTDE06), "Pierce without TDE (ver. 0.6)", "1.0.1", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace pierce_without_tde_06;
public class PierceWithoutTDE06 : MelonMod
{
    // After checking for a flag state
    [HarmonyPatch(typeof(EventBit), nameof(EventBit.evtBitCheck))]
    private class Patch
    {
        public static void Postfix(ref int no, ref bool __result)
        {
            // Checks the flag responsible for unlocking Pierce
            if (no == 2241)
            {
                if (!__result) __result = true; // Artificially makes it obtainable
                else tblHearts.fclHeartsTbl[1].Skill[5].TargetLevel = 21; // If unlocked normally, you can get it early
            }
        }
    }

    // When booting the game
    public override void OnInitializeMelon()
    {
        tblHearts.fclHeartsTbl[1].Skill[5].TargetLevel = 80; // Make Pierce obtainable at level 80 instead of level 21
    }
}
