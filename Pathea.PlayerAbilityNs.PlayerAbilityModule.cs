using Harmony;
using Pathea.PlayerAbilityNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExtendedSkillCaps
{
    [HarmonyPatch(typeof(PlayerAbilityModule))]
    [HarmonyPatch("OnLoad")]
    public static class PlayerAbilityLoadHook
    {
        private static FieldInfo refDataField;

        public static void Postfix(PlayerAbilityModule __instance, AbilityTable ___abilityTable)
        {
            if ( refDataField is null )
            {
                refDataField = typeof(AbilityItem).GetField("refData", BindingFlags.Instance | BindingFlags.NonPublic);
            }

            // Fight tree
            SetMaxPointsFor(___abilityTable, 0, 0, 0, 20);

            SetMaxPointsFor(___abilityTable, 0, 1, 0, 10);
            SetMaxPointsFor(___abilityTable, 0, 1, 1, 10);
            SetMaxPointsFor(___abilityTable, 0, 1, 2, 10);
            
            SetMaxPointsFor(___abilityTable, 0, 2, 0, 10);
            SetMaxPointsFor(___abilityTable, 0, 2, 1, 10);
            SetMaxPointsFor(___abilityTable, 0, 2, 2, 10);

            SetMaxPointsFor(___abilityTable, 0, 3, 0, 20);
            SetMaxPointsFor(___abilityTable, 0, 3, 1, 10);
            SetMaxPointsFor(___abilityTable, 0, 3, 2, 10);

            SetMaxPointsFor(___abilityTable, 0, 4, 0, 5);
            SetMaxPointsFor(___abilityTable, 0, 4, 1, 5);

            // Gather tree
            SetMaxPointsFor(___abilityTable, 1, 0, 0, 3);
            SetMaxPointsFor(___abilityTable, 1, 0, 1, 3);
            SetMaxPointsFor(___abilityTable, 1, 0, 2, 17);

            SetMaxPointsFor(___abilityTable, 1, 1, 0, 13);
            SetMaxPointsFor(___abilityTable, 1, 1, 1, 13);
            SetMaxPointsFor(___abilityTable, 1, 1, 2, 20);
            SetMaxPointsFor(___abilityTable, 1, 1, 3, 10);
            
            SetMaxPointsFor(___abilityTable, 1, 2, 1, 10);
            SetMaxPointsFor(___abilityTable, 1, 2, 2, 10);

            SetMaxPointsFor(___abilityTable, 1, 3, 0, 10);
            SetMaxPointsFor(___abilityTable, 1, 3, 1, 10);
            SetMaxPointsFor(___abilityTable, 1, 3, 2, 4);

            SetMaxPointsFor(___abilityTable, 0, 4, 0, 4);

            // Social tree
            SetMaxPointsFor(___abilityTable, 2, 0, 2, 10);

            SetMaxPointsFor(___abilityTable, 2, 1, 0, 25);
            SetMaxPointsFor(___abilityTable, 2, 1, 2, 10);

            SetMaxPointsFor(___abilityTable, 2, 2, 0, 10);
            SetMaxPointsFor(___abilityTable, 2, 2, 1, 5);
            SetMaxPointsFor(___abilityTable, 2, 2, 2, 10);

            SetMaxPointsFor(___abilityTable, 2, 3, 0, 10);
            SetMaxPointsFor(___abilityTable, 2, 3, 1, 10);
        }

        private static void SetMaxPointsFor( AbilityTable table, int tree, int group, int skill, int newMax )
        {
            var refData = (AbilityData)refDataField.GetValue(table[tree][group][skill]);
            refData.maxPoint = newMax;
        }
    }
}
