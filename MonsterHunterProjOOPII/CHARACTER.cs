using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    abstract class CHARACTER
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
        public int freezeTme;

        public int SCREENX
        {
            get { return positionInScreenX; }
            set { positionInScreenX = value; }
        }

        public int SCREENY
        {
            get { return positionInScreenY; }
            set { positionInScreenY = value; }
        }

        public int MAPWIDTH
        {
            get { return mapWidth; }
            set
            {
                try
                {
                    if (positionInScreenX != 0 && positionInScreenX > mapWidth)
                    {
                        Console.WriteLine("The player is outside of the bounds of the map");
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
                    if (positionInScreenY != 0 && positionInScreenY > mapHeight)
                    {
                        Console.WriteLine("The player is outside of the bounds of the map");
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
                        Console.WriteLine($"The maximum HP is {MAX_CHARACTER_HP}");
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
                        Console.WriteLine($"The maximum strenght possible is {MAX_STRENGHT}");
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
                        Console.WriteLine($"The maximum strenght possible is {MAX_ARMOR}");
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
        public CHARACTER(int X, int Y) { }
        
        public CHARACTER(int X, int Y, int MaxX, int MaxY) { }

    }
}
