using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    class SWORD
    {
        //const
        const int MIN_STRENGHT = 4;
        const int MAX_STRENGHT = 10; //+ 1 because of the .Next() max value 

        const int MIN_CHANCE = 1;
        const int MAX_CHANCE = 6; //+ 1 because of the .Next() max value handlement


        //variables
        public int swordStrenght;

        public SWORD()
        {
            swordStrenght = RNG.Instance.Next(MIN_STRENGHT, MAX_STRENGHT);
        }

        //methods
        public bool CheckIfShieldIsBroken()
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_CHANCE, MAX_CHANCE);

            switch (numChosen)
            {
                default:
                    return false;

                case 1:
                    return true;

                case 2:
                    return false;

                case 3:
                    return false;

                case 4:
                    return false;

                case 5:
                    return false;

            }

        }

    }
}
