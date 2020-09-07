using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace SprunTellsTheTrigger
{
    public class SprunTellsTheTriggerModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            ETGMod.Databases.Strings.Core.Set("#SPRUN_CURRENTTRIGGER_TEXT", "Current Trigger: %SPRUN_TRIGGER.");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_UNASSIGNED", "Unassigned");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_USED_LAST_BLANK", "Player uses their last blank.");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_LOST_LAST_ARMOR", "Player loses their last piece of armor");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_REDUCED_TO_ONE_HEALTH", "Player goes down to half a heart.");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_GUN_OUT_OF_AMMO", "Player's gun runs out of ammo");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_SET_ON_FIRE", "Player is set on fire");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_ELECTROCUTED_OR_POISONED", "Player takes damage from electrocution or poison");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_FELL_IN_PIT", "Player falls into a pit");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_TOOK_ANY_HEART_DAMAGE", "Player takes damage to hearts");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_FLIPPED_TABLE", "Player flips a table");
            ETGMod.Databases.Strings.Core.Set("#SPRUN_ACTIVE_ITEM_USED", "Player uses an active item");
            PickupObjectDatabase.GetById(578).gameObject.AddComponent<SprunTellsTheTriggerBehaviour>();
            ETGModConsole.Log("Sprun Tells The Trigger initialized.");
        }

        public override void Exit()
        {
        }
    }

    public class SprunTellsTheTriggerBehaviour : BraveBehaviour
    {
        public void Awake()
        {
            if (base.GetComponent<SprenOrbitalItem>())
            {
                base.GetComponent<SprenOrbitalItem>().OnPickedUp += this.OnPickedUpSprun;
            }
        }

        private void OnPickedUpSprun(PlayerController player)
        {
            base.GetComponent<SprenOrbitalItem>().StartCoroutine(this.TellTheTriggerCR());
        }

        private IEnumerator TellTheTriggerCR()
        {
            yield return null;
            if (base.GetComponent<SprenOrbitalItem>())
            {
                GameObject orbital = (orbitalInfo.GetValue(base.GetComponent<PlayerOrbitalItem>()) as GameObject);
                string text = StringTableManager.GetString("#SPRUN_CURRENTTRIGGER_TEXT").Replace("%SPRUN_TRIGGER", StringTableManager.GetString("#SPRUN_" + triggerInfo.GetValue(base.GetComponent<SprenOrbitalItem>())));
                TextBoxManager.ShowTextBox(orbital.transform.position + Vector3.up / 2, orbital.transform, 5, text, "", false, TextBoxManager.BoxSlideOrientation.NO_ADJUSTMENT, false, false) ;
            }
            yield break;
        }

        private static FieldInfo orbitalInfo = typeof(PlayerOrbitalItem).GetField("m_extantOrbital", BindingFlags.NonPublic | BindingFlags.Instance);
        private static FieldInfo triggerInfo = typeof(SprenOrbitalItem).GetField("m_trigger", BindingFlags.NonPublic | BindingFlags.Instance);
    }
}
