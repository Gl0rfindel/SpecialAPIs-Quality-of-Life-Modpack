using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatDoesntStealArmor
{
    public class RatDoesntStealArmorModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            PickupObjectDatabase.GetById(120).IgnoredByRat = true;
            ETGModConsole.Log("Rat Doesn't Steal Armor successfully initialized.");
        }

        public override void Exit()
        {
        }
    }
}
