using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public interface IState //state of hunter
    {
        int calculate_Strenght(HUNTER hunter);
        int calculate_Defense(HUNTER hunter);
        int manage_HP(HUNTER hunter);
        int manage_FreezeTime(HUNTER hunter);
    }

    public class NormalState : IState
    {
        //lazy initialization
        private static NormalState instance = null;
        public static NormalState getInstance()
        {
            if(instance == null)
            {
                instance = new NormalState();
            }
            return instance;
        }

        public int calculate_Strenght(HUNTER hunter)
        {
            return hunter.STRENGHT = hunter.normalHunterStrenght;
        }

        public int calculate_Defense(HUNTER hunter)
        {
            return hunter.ARMOR = hunter.normalHunterArmor;
        }

        public int manage_HP(HUNTER hunter)
        {
            return hunter.CURRENTHP = hunter.maxHP;
        }

        public int manage_FreezeTime(HUNTER hunter)
        {
            return hunter.freezeTme = hunter.normalHunterFreezeTime;
        }
    }

    public class StrongState : IState
    {
        //lazy initialization
        private static StrongState instance = null;
        public static StrongState getInstance()
        {
            if (instance == null)
            {
                instance = new StrongState();
            }
            return instance;

        }
        public int calculate_Strenght(HUNTER hunter)
        {
            return hunter.STRENGHT * 2;
        }

        public int calculate_Defense(HUNTER hunter)
        {
            return hunter.ARMOR * 2;//I know I had to do 1.5 
        }

        public int manage_HP(HUNTER hunter)
        {
            return hunter.CURRENTHP = hunter.maxHP; //preguntar por como poner
                                                                //el const ahi
        }

        public int manage_FreezeTime(HUNTER hunter)
        {
            return hunter.freezeTme;
        }
    }

    public class PoisonedState : IState
    {
        private static PoisonedState instance = null;
        public static PoisonedState getInstance()
        {
            if (instance == null)
            {
                instance = new PoisonedState();
            }
            return instance;

        }

        public int calculate_Strenght(HUNTER hunter)
        {
            return hunter.STRENGHT / 2;
        }
        public int calculate_Defense(HUNTER hunter)
        {
            return hunter.ARMOR / 2;
        }
        public int manage_HP(HUNTER hunter)
        {
            return hunter.CURRENTHP - 5;
        }
        public int manage_FreezeTime(HUNTER hunter)
        {
            return hunter.freezeTme += hunter.freezeTme * Convert.ToInt32(1.25);//I know this wont work properly
        }
    }

    //terminar de implementar InvisibleState 
    public class InvisibleState : IState
    {
        private static InvisibleState instance = null;
        public static InvisibleState getInstance()
        {
            if (instance == null)
            {
                instance = new InvisibleState();
            }
            return instance;
        }

        public int calculate_Strenght(HUNTER hunter)
        {
            return RNG.Instance.Next(0, hunter.STRENGHT+1);
        }

        public int calculate_Defense(HUNTER hunter)
        {
            return RNG.Instance.Next(0, hunter.ARMOR+1);
        }

        public int manage_HP(HUNTER hunter)
        {
            return hunter.CURRENTHP;
        }

        public int manage_FreezeTime(HUNTER hunter)
        {
            return hunter.freezeTme;
        }
    }

    public class FastState : IState
    {
        private static FastState instance = null;
        public static FastState getInstance()
        {
            if (instance == null)
            {
                instance = new FastState();
            }
            return instance;
        }

        public int calculate_Strenght(HUNTER hunter)
        {
            return hunter.STRENGHT;
        }

        public int calculate_Defense(HUNTER hunter)
        {
            return hunter.ARMOR;
        }

        public int manage_HP(HUNTER hunter)
        {
            return hunter.CURRENTHP;
        }

        public int manage_FreezeTime(HUNTER hunter)
        {
            return hunter.freezeTme * Convert.ToInt32(0.5);
        }
    }

}


