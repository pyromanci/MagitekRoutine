using ff14bot;
using ff14bot.Managers;
using Magitek.Extensions;
using Magitek.Models.Dancer;
using Magitek.Utilities;
using System.Linq;
using System.Threading.Tasks;


namespace Magitek.Logic.Dancer
{
    internal static class Aoe
    {
        public static async Task<bool> StarfallDance()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (Core.Me.ClassLevel < Spells.StarfallDance.LevelAcquired) return false;

            if (!Core.Me.HasAura(Auras.FlourishingStarfall)) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (!Core.Me.CurrentTarget.InCustomDegreeCone(10)) return false;

            if (Core.Me.CurrentTarget.Distance(Core.Me) > Spells.StarfallDance.Range) return false;

            return await Spells.StarfallDance.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> FanDance4()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (Core.Me.ClassLevel < Spells.FanDanceIV.LevelAcquired) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (!Core.Me.HasAura(Auras.FourfoldFanDance)) return false;

            if (!Core.Me.CurrentTarget.InCustomRadiantCone(Spells.StarfallDance.Radius)) return false;

            if (Core.Me.CurrentTarget.Distance(Core.Me) > Spells.FanDanceIV.Range) return false;

            return await Spells.FanDanceIV.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> FanDance3()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (Core.Me.ClassLevel < Spells.FanDance3.LevelAcquired) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            return await Spells.FanDance3.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> FanDance2()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.FanDanceTwo) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me) <= 5 + r.CombatReach) < DancerSettings.Instance.FanDanceTwoEnemies) return false;

            if (ActionResourceManager.Dancer.FourFoldFeathers < 4 && !Core.Me.HasAura(Auras.Devilment) && Core.Me.ClassLevel >= 62) return false;

            return await Spells.FanDance2.Cast(Core.Me);
        }

        public static async Task<bool> Bloodshower()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.Bloodshower) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me) <= 5 + r.CombatReach) < DancerSettings.Instance.BloodshowerEnemies) return false;

            if (!Core.Me.HasAura(Auras.FlourshingFlow) && !Core.Me.HasAura(Auras.FlourshingFountain)) return false;

            return await Spells.Bloodshower.Cast(Core.Me);
        }

        public static async Task<bool> RisingWindmill()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.RisingWindmill) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me) <= 5 + r.CombatReach) < DancerSettings.Instance.RisingWindmillEnemies) return false;

            if (Core.Me.CurrentTarget == null) return false;

            if (!Core.Me.HasAura(Auras.FlourishingSymmetry) && !Core.Me.HasAura(Auras.FlourshingFountain)) return false;

            return await Spells.RisingWindmill.Cast(Core.Me);
        }

        public static async Task<bool> SaberDance()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.SaberDance) return false;

            if (Core.Me.ClassLevel < Spells.SaberDance.LevelAcquired) return false;

            if (ActionResourceManager.Dancer.Esprit < DancerSettings.Instance.SaberDanceEsprit) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me.CurrentTarget) <= 5 + r.CombatReach) < DancerSettings.Instance.SaberDanceEnemies) return false;

            if (DancerSettings.Instance.UseExpermentalChecks)
                if (Core.Me.CurrentTarget.Distance(Core.Me) > Spells.SaberDance.Range) return false;

            return await Spells.SaberDance.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> Bladeshower()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.Bladeshower) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me) <= 5 + r.CombatReach) < DancerSettings.Instance.BladeshowerEnemies) return false;

            if (ActionManager.LastSpell != Spells.Windmill) return false;

            return await Spells.Bladeshower.Cast(Core.Me);
        }

        public static async Task<bool> Windmill()
        {
            if (!DancerSettings.Instance.UseAoe) return false;

            if (!DancerSettings.Instance.Windmill) return false;

            if (Core.Me.HasAura(Auras.StandardStep) || Core.Me.HasAura(Auras.TechnicalStep)) return false;

            if (Combat.Enemies.Count(r => r.Distance(Core.Me) <= 5 + r.CombatReach) < DancerSettings.Instance.WindmillEnemies) return false;

            return await Spells.Windmill.Cast(Core.Me);
        }
    }
}