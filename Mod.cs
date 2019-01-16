using Harmony;
using spacechase0.MiniModLoader.Api.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExtendedSkillCaps
{
    public class Mod : IMod
    {
        public override void AfterModsLoaded()
        {
            var harmony = HarmonyInstance.Create("spacechase0.ExtendedSkillCaps");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
