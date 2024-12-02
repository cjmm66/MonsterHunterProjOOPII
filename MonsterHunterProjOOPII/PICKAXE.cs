using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    class PICKAXE
    {
        const int MIN_CHANCE = 1;
        const int MAX_CHANCE = 4; //+ 1 because of the .Next() max value handlement


        public bool CheckIfPickaxeIsBroken()
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
                    return true;

                case 3:
                    return false;
      
            }
            
        }

    }
}
