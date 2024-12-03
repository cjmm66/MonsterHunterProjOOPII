using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    class POTION
    {
        //const
        const int MIN_POTION = 1;
        const int MAX_POTION = 7; //+1 because of the .Next() max value

        //enumeration of the type of potions
        public enum TypeOfPotion
        {
            Strenght,
            Poisoned,
            Invisibility,
            Speed

        }

        public TypeOfPotion potionEffect;
        
        public POTION()
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_POTION, MAX_POTION);
            
            switch(numChosen)
            {
                case 1:
                    potionEffect = TypeOfPotion.Poisoned;
                    break;
                
                case 2:
                    potionEffect = TypeOfPotion.Speed;
                    break;

                case 3:
                    potionEffect = TypeOfPotion.Speed;
                    break;
                
                case 4:
                    potionEffect = TypeOfPotion.Invisibility;
                    break;
                
                case 5:
                    potionEffect = TypeOfPotion.Invisibility;
                    break;

                case 6:
                    potionEffect = TypeOfPotion.Strenght;
                    break;

            }
        }
    }
}
