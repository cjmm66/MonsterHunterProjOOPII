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
        //const
        const int MAX_MAP_WIDTH = 75;
        const int MAX_MAP_HEIGHT = 35;

        //private variables
        private int mapWidth, mapHeight;

        private string [] mapFiles;

        //public get/set
        public string validationError = "";

        public  int mapWIDTH
        {
            get { return mapWidth; }
            private set
            {
                try
                {
                    //clear last error
                    validationError = "";

                    //check width number
                    if(value > MAX_MAP_WIDTH || value <= 0)
                    {
                        validationError = $"value cannot be more than {MAX_MAP_WIDTH} or less than 0";
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
        
        public  int mapHEIGHT
        {
            get { return mapHeight; }
            private set
            {
                try
                {
                    //clear last error
                    validationError = "";

                    //check height number
                    if (value > MAX_MAP_HEIGHT || value <= 0)
                    {
                        validationError = $"value cannot be more than {MAX_MAP_HEIGHT} or less than 0";
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

        //jagged array (array of arrays)
        public static char[][] mapArray = new char[][] { };
        public MAP()
        {
            //search the map in the directory
            mapFiles = Directory.GetFiles(@".", "*.txt");
        }

        private static void loadMapFromFile(string fileName, HUNTER hunter, List<MONSTER> monsters)
        {
            foreach (string fileLine in System.IO.File.ReadLines(fileName))
            {
                //convert the string into a char array
                char[] fileLineArray = fileLine.ToCharArray();

                Array.Resize(ref mapArray, mapArray.Length + 1);

                mapArray[mapArray.GetUpperBound(0)] = fileLineArray;
            }
            //assigns the height

            try
            {
                if(mapArray.Length > MAX_MAP_HEIGHT)
                {
                    Console.WriteLine("The map's height is too big");

                }
                else
                {
                   // mapHEIGHT = mapArray.Length;
                }

            }
            catch (Exception e)
            {

                throw new Exception("An error occured in the DLL (Assigning map's height)", e);
            }

            try
            {
                if (mapArray[0].Length > MAX_MAP_WIDTH)
                {
                    Console.WriteLine("The map's width is too big");

                }
                else
                {
                    //mapWIDTH = mapArray[0].Length;
                }

            }
            catch (Exception e)
            {

                throw new Exception("An error occured in the DLL (Assigning map's width)", e);
            }
        }



    }
}
