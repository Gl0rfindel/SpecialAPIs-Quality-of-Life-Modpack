using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace NoExplosionQueue
{
    public class NoExplosionQueueModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            Hook explosionHook = new Hook(
                typeof(Exploder).GetMethod("Explode", BindingFlags.Public | BindingFlags.Static),
                typeof(NoExplosionQueueModule).GetMethod("ExplosionHook")
            );
            ETGModConsole.Log("No Explosion Queue initialized.");
        }

        public static void ExplosionHook(Action<Vector3, ExplosionData, Vector2, Action, bool, CoreDamageTypes, bool> orig, Vector3 position, ExplosionData data, Vector2 sourceNormal, Action onExplosionBegin, bool ignoreQueues, CoreDamageTypes damageTypes, 
            bool ignoreDamageCaps)
        {
            orig(position, data, sourceNormal, onExplosionBegin, true, damageTypes, ignoreDamageCaps);
        }

        public override void Exit()
        {
        }

        public delegate void Action<T, T2, T3, T4, T5, T6, T7>(T arg, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    }
}
