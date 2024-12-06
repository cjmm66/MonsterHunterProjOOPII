using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MonsterHunterProjOOPII
{
    public class POTION
    {
        //const
        const int MIN_POTION = 1;
        const int MAX_POTION = 7; //+1 because of the .Next() max value
        const int POTION_POINTS = 25;

        //enumeration of the type of potions
        public enum TypeOfPotion
        {
            Strenght,
            Poisoned,
            Invisibility,
            Speed

        }

        public TypeOfPotion potionEffect;
       
        public POTION(HUNTER hunter, MAP map)
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_POTION, MAX_POTION);
            
            switch(numChosen)
            {
                case 1:
                    potionEffect = TypeOfPotion.Poisoned;
                    hunter.state = PoisonedState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    hunter.HUNTERSCORE += POTION_POINTS;
                    break;
                
                case 2:
                    potionEffect = TypeOfPotion.Speed;
                    hunter.state = FastState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    hunter.HUNTERSCORE += POTION_POINTS;
                    break;

                case 3:
                    potionEffect = TypeOfPotion.Speed;
                    hunter.state = FastState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    break;
                
                case 4:
                    potionEffect = TypeOfPotion.Invisibility;
                    hunter.state = InvisibleState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    hunter.HUNTERSCORE += POTION_POINTS;
                    break;
                
                case 5:
                    potionEffect = TypeOfPotion.Invisibility;
                    hunter.state = InvisibleState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    hunter.HUNTERSCORE += POTION_POINTS;
                    break;

                case 6:
                    potionEffect = TypeOfPotion.Strenght;
                    hunter.state = StrongState.getInstance();
                    hunter.CURRENTHP = hunter.state.manage_HP(hunter);
                    hunter.STRENGHT = hunter.state.calculate_Strenght(hunter);
                    hunter.ARMOR = hunter.state.calculate_Defense(hunter);
                    hunter.freezeTme = hunter.state.manage_FreezeTime(hunter);
                    Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('H');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hunter.StartPotionTimer();
                    hunter.HUNTERSCORE += POTION_POINTS;
                    break;

            }
        }
    }
}
