using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MonsterHunterProjOOPII
{
    //git hub test
    public class MAP
    {
        //test

        //const
        const int MAX_MAP_WIDTH = 75;
        const int MAX_MAP_HEIGHT = 35;

        //private variables
        private static int mapWidth, mapHeight;

        private string [] mapFiles;

        //public get/set
        public static string mapValidationError = "";

        public  static int mapWIDTH
        {
            get { return mapWidth; }
            private set
            {
                try
                {
                    //clear last error
                    mapValidationError = "";

                    //check width number
                    if(value > MAX_MAP_WIDTH || value <= 0)
                    {
                        mapValidationError = $"value cannot be more than {MAX_MAP_WIDTH} or less than 0";
                    }
                    else
                    {
                        mapWidth = value;
                    }
                    
                }
                catch (Exception e)
                {

                    throw new Exception("An error ocurred in the DLL (map width) setter ", e);
                }
            }
        }
        
        public static int mapHEIGHT
        {
            get { return mapHeight; }
            private set
            {
                try
                {
                    //clear last error
                    mapValidationError = "";

                    //check height number
                    if (value > MAX_MAP_HEIGHT || value <= 0)
                    {
                        mapValidationError = $"value cannot be more than {MAX_MAP_HEIGHT} or less than 0";
                    }
                    else
                    {
                        mapHeight = value;
                    }

                }
                catch (Exception e)
                {

                    throw new Exception("An error ocurred in the DLL (map height) setter ", e);
                }
            }
        }

        public string [] MAPFILES
        {
            get { return mapFiles; }
            private set { mapFiles = value; }
        }

        //jagged array (array of arrays)
        public char[][] mapArray = new char[][] { };
        public MAP()
        {
            //search the map in the directory
            mapFiles = Directory.GetFiles(@".", "*.txt");
        }

        private void loadMapFromFile(string fileName, HUNTER hunter, MONSTER_S_ monsters)
        {
            int y = 0;
     
            foreach (string fileLine in System.IO.File.ReadLines(fileName))
            {
                //convert the string into a char array
                char[] fileLineArray = fileLine.ToCharArray();

                Array.Resize(ref mapArray, mapArray.Length + 1);

                mapArray[mapArray.GetUpperBound(0)] = fileLineArray;

                //loop into the fileLineArray to find the player and the monsters
                for (int x = 0; x < fileLineArray.Length; x++)
                {
                    //if the actual position is a player
                    if(fileLineArray[x] == 'H')
                    {

                        hunter.POSINSCREENX = x;
                        hunter.POSINSCREENY = y;
                        mapArray[y][x] = ' ';
                    }

                    if(fileLineArray[x] == 'M')
                    {
                        MONSTER monster = new MONSTER(x, y);
                        monsters.AddToMonstersList(monster);
                        mapArray[y][x] = ' ';
                        
                    }

                }
                y++; //next line
            }

            //assigns the height
            try
            {
                //clears last error
                mapValidationError = "";
                if(mapArray.Length > MAX_MAP_HEIGHT)
                {
                    mapValidationError = "The map's height is too big";

                }
                else
                {
                   mapHEIGHT = mapArray.Length;
                }

            }
            catch (Exception e)
            {

                throw new Exception("An error occured in the DLL (Assigning map's height)", e);
            }
            //assigns the widht
            try
            {
                //clears the last error
                mapValidationError = "";
                if (mapArray[0].Length > MAX_MAP_WIDTH)
                {
                    mapValidationError = "The map's width is too big";

                }
                else
                {
                    mapWIDTH = mapArray[0].Length;
                }

            }
            catch (Exception e)
            {

                throw new Exception("An error occured in the DLL (Assigning map's width)", e);
            }
            
        }

        public void GlobalLoadAMapFromFile(string fileName, HUNTER hunter, MONSTER_S_ monsters)
        {
            loadMapFromFile(fileName, hunter, monsters);
        }

    }
}
