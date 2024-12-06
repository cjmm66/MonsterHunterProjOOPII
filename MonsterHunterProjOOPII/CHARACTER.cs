using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterProjOOPII
{
    public abstract class CHARACTER
    {
        //const
        private const int MAX_CHARACTER_HP = 30;
        
        private const int MAX_STRENGHT = 7;
        
        private const int MAX_ARMOR = 4;

        //private variables
        private int positionInScreenX, positionInScreenY;

        private int mapWidth, mapHeight;

        private int currentHp;

        private int strenght, armor;


        //public get/set
        public string characterValidationError = "";

        public bool checkError;
        
        public int freezeTme;

        public int POSINSCREENX
        {
            get { return positionInScreenX; }
            set 
            {
                try
                {
                    //clears the last error
                    characterValidationError = "";
                    if (mapWidth != 0)
                    {
                        if (value > mapWidth || value < 0)
                        {
                            characterValidationError = "Position is outside of bounds";
                        }
                    }
                    else
                    {
                        positionInScreenX = value;

                    }
                }
                catch (Exception e)
                {

                    throw;
                }
            
            
            
            }
        }

        public int POSINSCREENY

        {
            get { return positionInScreenY; }
            set 
            {
                try
                {
                    //clears the last error
                    characterValidationError = "";
                    if(mapHeight != 0)
                    {
                        if(value > mapHeight || value < 0)
                        {
                            characterValidationError = "Position is outside of bounds";
                        }
                    }
                    else
                    {
                       positionInScreenY = value; 

                    }

                }
                catch (Exception e)
                {

                    throw;
                }
                
            
            }
        }

        public int MAPWIDTH
        {
            get { return mapWidth; }
            set
            {
                try
                {
                    if (positionInScreenX > mapWidth)
                    {
                        characterValidationError = "The player is outside of the bounds of the map";
                    }
                    else
                    {
                        mapWidth = value;
                    }

                }
                catch (Exception e)
                {

                    throw new Exception("error", e);
                }
            }
        }

        public int MAPHEIGHT
        {
            get { return mapHeight; }
            set
            {
                try
                {
                    if (positionInScreenY > mapHeight)
                    {
                        characterValidationError ="The player is outside of the bounds of the map";
                    }
                    else
                    {
                        mapHeight = value;
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
    
        public int CURRENTHP
        {
            get { return MAX_CHARACTER_HP; }
            set
            {
                try
                {
                    if(value > 30)
                    {
                        characterValidationError = $"The maximum HP is {MAX_CHARACTER_HP}";
                    }
                    else
                    {
                        currentHp = value;
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
            }

        }

        public int STRENGHT
        {
            get { return strenght; }
            set
            {
                try
                {
                    if(value > MAX_STRENGHT)
                    {
                        characterValidationError = $"The maximum strenght possible is {MAX_STRENGHT}";
                    }
                    else
                    {
                        strenght = value;
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public int ARMOR
        {
            get { return armor; }
            set
            {
                try
                {
                    if (value > MAX_ARMOR)
                    {
                        characterValidationError = $"The maximum strenght possible is {MAX_ARMOR}";
                    }
                    else
                    {
                        armor = value;
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
            }

        }

        //methods
        public abstract bool moveCharacter(int X, int Y);

        public bool CheckIfDead(int currentHP)
        {
            if (currentHp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        //constructor
        public CHARACTER(int X, int Y)
        {
            positionInScreenX = X;
            positionInScreenY = Y;
        }
        
        public CHARACTER(int X, int Y, int MaxX, int MaxY) 
        {
            positionInScreenX = X;
            positionInScreenY = Y;
            MAPWIDTH = MaxX;
            MAPHEIGHT = MaxY;


        }

        

    }
}
