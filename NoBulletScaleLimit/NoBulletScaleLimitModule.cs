using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NoBulletScaleLimit
{
    public class NoBulletScaleLimitModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            ETGModMainBehaviour.Instance.gameObject.AddComponent<NoBulletScaleLimitBehaviour>();
            Projectile.s_maxProjectileScale = float.MaxValue;
            ETGModConsole.Log("No Bullet Scale Limit initialized.");
        }

        public override void Exit()
        {
        }
    }

    public class NoBulletScaleLimitBehaviour : MonoBehaviour
    {
        public void Update()
        {
            if(Projectile.s_maxProjectileScale != float.MaxValue)
            {
                Projectile.s_maxProjectileScale = float.MaxValue;
            }
        }
    }
}
