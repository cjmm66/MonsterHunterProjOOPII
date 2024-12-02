using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class HUNTER : CHARACTER
    {

        //const
        const int MAX_NAME_CHARACTERS = 20;

        const int MAX_HUNTER_SCORE = 100000;

        //private variables
        private string hunterName = "";

        private int hunterScore;

        //public get/set
        public string hunterValidationError = "";

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
                        hunterValidationError = $"The maximum characters are {MAX_NAME_CHARACTERS}";
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

        //constructor
        public HUNTER(int positionX, int positionY) : base (positionX, positionY)
        {
            base.freezeTme = 1000; //sets the freeze time to 1 sec
        }

        //methods
        public override bool moveCharacter(int X, int Y)
        {
            return false;
                
        }


    }
}
