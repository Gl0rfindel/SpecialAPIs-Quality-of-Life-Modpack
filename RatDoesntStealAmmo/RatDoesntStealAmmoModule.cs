using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatDoesntStealAmmo
{
    public class RatDoesntStealAmmoModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            PickupObjectDatabase.GetById(78).IgnoredByRat = true;
            PickupObjectDatabase.GetById(600).IgnoredByRat = true;
            ETGModConsole.Log("Rat Doesn't Steal Ammo successfully initialized.");
        }

        public override void Exit()
        {
        }
    }
}
