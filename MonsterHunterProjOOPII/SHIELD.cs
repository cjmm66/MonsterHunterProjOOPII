using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class SHIELD : WEAPON
    {
        //const
        const int MIN_DEFENSE = 3;
        const int MAX_DEFENSE = 7; //+ 1 because of the .Next() max value 

        const int MIN_CHANCE = 1;
        const int MAX_CHANCE = 5; //+ 1 because of the .Next() max value handlement


        //variables
        public int shieldArmor;

        public SHIELD()
        {
            shieldArmor = RNG.Instance.Next(MIN_DEFENSE, MAX_DEFENSE);
        }

        //methods
        public override bool CheckIfIsBroken(HUNTER hunter)
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_CHANCE, MAX_CHANCE);
        
            switch (numChosen)
            {
                default:
                    return false;

                case 1:
                    return false;

                case 2:
                    return false;

                case 3:
                    return false;

                case 4:
                    hunter.hasShield = false;
                    return true;

            }

        }
    }
}
