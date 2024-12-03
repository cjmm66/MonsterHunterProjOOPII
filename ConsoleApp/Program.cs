using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterProjOOPII;
using System.IO;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //variables / properties
            int mapNumber = 1;
            int selectedMapNumber = 0;


            //searches the maps in the directory
            string[] mapFiles = Directory.GetFiles(@".", "*.txt"); 

            //creates a HUNTER object
            HUNTER hunter = new HUNTER(0, 0);

            //creates a MAP object
            MAP map = new MAP();

            //creates a Monster(S) object
            MONSTER_S_ monster_S = new MONSTER_S_();

            #region Sets The Name

            Console.WriteLine("WELCOME TO MONSTER HUNTER!");
            do 
            {
                Console.Write("Enter the player's name: ");
                hunter.NAME = Console.ReadLine();
                if (hunter.hunterValidationError != "")
                {
                    hunter.checkError = true;
                    Console.WriteLine(hunter.hunterValidationError);
                    Console.WriteLine("Press any key to retry...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    hunter.checkError = false;
                }

                
            } while (hunter.checkError == true);
            Console.Clear();
            #endregion

            #region Shows Map and User Selects a Map

            Console.WriteLine($"WELCOME {hunter.NAME}");
            Console.WriteLine("Please choose a map from the list below");
            do
            {
                //list all the files on the screen
                listFiles(map.MAPFILES, mapNumber);
                Console.Write("Please type the number of the map you want to play at: ");
                string selectedMapString = Console.ReadLine();
                if (!int.TryParse(selectedMapString, out selectedMapNumber))
                {
                    //it's not a number
                    Console.WriteLine("That's not a number");
                    Console.WriteLine("Press a key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (selectedMapNumber > map.MAPFILES.Length || selectedMapNumber == 0)
                {
                    //the number is larger than the available maps
                    Console.WriteLine($"There are {map.MAPFILES.Length} map(s)");
                    Console.WriteLine("Press a key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }

            }while(selectedMapNumber > map.MAPFILES.Length || selectedMapNumber <= 0);
            Console.Clear();
            #endregion

            map.GlobalLoadAMapFromFile(map.MAPFILES[selectedMapNumber - 1], hunter,monster_S);
            DrawMap(map.mapArray, hunter, monster_S);

            Console.ReadLine();





        }

        static void listFiles(string[] mapFiles, int mapNumber)
        {
            Console.WriteLine("MAPS TO PLAY");
            foreach (string eachFile in mapFiles)
            {
                Console.WriteLine(mapNumber + " " + eachFile);
                mapNumber++;
            }
        }

        static void DrawMap(char[][] map, HUNTER hunter, MONSTER_S_ monsters)
        {
            //set the cursor to the top of the screen
            Console.SetCursorPosition(0, 0);

            //loop in the 1st dimension of the array
            for (int Y = 0; Y < map.GetLength(0); Y++)
            {
                //loop in the 2nd dimension of the array
                for (int X = 0; X < map[Y].Length; X++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //if we draw the player
                    //if (map[Y][X] == 'H')
                    if (X == hunter.POSINSCREENX && Y == hunter.POSINSCREENY)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        //draw the char at this position in the array
                        Console.Write('H');
                    }
                    //if we draw the monster
                    //I HAVE TO FINISH DRAWING THE MONSTER
                    else if(map[Y][X] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        //draw the char at this position in the array
                        //Console.Write(map[Y][X]);
                        Console.Write('M');
                    }
                    else
                    {
                        //Go back to color gray
                        Console.Write(map[Y][X]);

                    }
                    

                }
                Console.WriteLine();
            }

        }

    }
}
