using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class POTION
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
        
        //HACER COLORES PARA CUANDO CAMBIE EL EFECTO
        public POTION(HUNTER hunter)
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_POTION, MAX_POTION);
            
            switch(numChosen)
            {
                case 1:
                    potionEffect = TypeOfPotion.Poisoned;
                    hunter.state = PoisonedState.getInstance();
                    break;
                
                case 2:
                    potionEffect = TypeOfPotion.Speed;
                    hunter.state = FastState.getInstance();
                    break;

                case 3:
                    potionEffect = TypeOfPotion.Speed;
                    hunter.state = FastState.getInstance();
                    break;
                
                case 4:
                    potionEffect = TypeOfPotion.Invisibility;
                    //hunter.state = InvisibleState.getInstance();
                    break;
                
                case 5:
                    potionEffect = TypeOfPotion.Invisibility;
                    break;

                case 6:
                    potionEffect = TypeOfPotion.Strenght;
                    hunter.state = StrongState.getInstance();
                    break;

            }
        }
    }
}
