using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class PICKAXE : WEAPON
    {
        const int MIN_CHANCE = 1;
        const int MAX_CHANCE = 4; //+ 1 because of the .Next() max value handlement


        public override bool CheckIfIsBroken(HUNTER hunter)
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_CHANCE, MAX_CHANCE);
            
            switch(numChosen)
            {
                default:
                    return false;

                case 1:
                    return false;

                case 2:
                    hunter.hasPickaxe = false;
                    return true;

                case 3:
                    return false;
      
            }
            
        }

    }
}
