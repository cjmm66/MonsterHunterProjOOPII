using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace MonsterHunterProjOOPII
{
    public class HUNTER : CHARACTER
    {

        //const
        const int MAX_NAME_CHARACTERS = 20;

        const int MIN_NAME_CHARACTERS = 3;

        const int MAX_HUNTER_SCORE = 100000;

        //private variables
        private string hunterName = "";

        private int hunterScore;

        static private Timer potionTimer;

        static int timePassed = 0;

        //public get/set
        public string hunterValidationError = "";

        public int normalHunterArmor = 4;
        public int normalHunterStrenght = 7;
        public int normalHunterFreezeTime = 1000;

        public int maxHP = 30;

        public IState state; //internal state of the object

        public string NAME
        {
            get { return hunterName; }
            set
            {
                try
                {
                    //clear the previous error
                    hunterValidationError = "";
                    if(value.Length > MAX_NAME_CHARACTERS)
                    {
                        hunterValidationError = $"The maximum characters is {MAX_NAME_CHARACTERS}";
                    }
                    if(value.Length < MIN_NAME_CHARACTERS)
                    {
                        hunterValidationError = $"The minimum characters is {MIN_NAME_CHARACTERS}";
                    }
                    else
                    {
                        hunterName = value;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public int HUNTERSCORE
        {
            get { return hunterScore; }
            set
            {
                try
                {
                    //clear last error
                    hunterValidationError = "";
                    
                    if(value > MAX_HUNTER_SCORE)
                    {
                        hunterValidationError = $"the maximum score is {MAX_HUNTER_SCORE}";
                    }
                    else if(value < 0)
                    {
                        hunterValidationError = "The score cannot be negative";
                    }
                    else
                    {
                        hunterScore = value;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public char[][] hunterMap;

        public bool hasSword = false;
        public bool hasShield = false;
        public bool hasPickaxe = false;
        
        //constructor
        public HUNTER(int positionX, int positionY) : base (positionX, positionY)
        {
            base.freezeTme = 1000; //sets the freeze time to 1 sec
        }

        //methods
        public override bool moveCharacter(int moveX, int moveY)
        {
            //if (moveX > 0 && moveX < hunterMap.Length && moveY > 0 && moveY < hunterMap[moveY].Length)
            //{
                if (hunterMap[moveY][moveX] != '#' && hunterMap[moveY][moveX] != 'M')
                {
                    POSINSCREENX = moveX;
                    POSINSCREENY = moveY;

                    return true;
                }

            //}
            return false;
        }

        public void StartPotionTimer()
        {
            timePassed = 0;
            potionTimer = new Timer(10000);
            potionTimer.Enabled = true;
            potionTimer.Elapsed += WhenTimerReaches10Sec;
            potionTimer.AutoReset = true;

        }

        private void WhenTimerReaches10Sec(object timer, ElapsedEventArgs e)
        {
            timePassed++;
            if (timePassed == 10)
            {
                this.state = NormalState.getInstance();
                this.CURRENTHP = this.state.manage_HP(this);
                this.STRENGHT = this.state.calculate_Strenght(this);
                this.ARMOR = this.state.calculate_Defense(this);
                this.freezeTme = this.state.manage_FreezeTime(this);
                potionTimer.Stop();
                potionTimer.Enabled = false;
            }
        }

        public void ResetValues()
        {
            this.POSINSCREENX = 0;
            this.POSINSCREENY = 0;
            this.CURRENTHP = this.maxHP;
            this.STRENGHT = this.normalHunterArmor;
            this.STRENGHT = this.normalHunterStrenght;
            this.HUNTERSCORE = 0;
            this.NAME = "";
            this.state = NormalState.getInstance();
        }

    }
}
