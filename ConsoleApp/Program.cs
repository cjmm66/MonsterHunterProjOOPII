using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterProjOOPII;
using System.IO;
using System.Threading;

//For the infoMessage
//do an array
//replace[0] with [1] and so on
//so the array [2] gest the new message

namespace ConsoleApp
{
    class Program
    {
        static bool canMoveMonster = true;
        static bool canMoveHunter = true;
        static ConsoleKeyInfo keyPressed;
        static bool gameOn = true;
        static string decide;
        static int intDecide = 1;
        static bool gameLoop = true;
        //creates static weapons
        static SHIELD shield;
        static SWORD sword;
        static PICKAXE pickaxe;

        static void Main(string[] args)
        {
            //variables / properties
            int mapNumber = 1;
            int selectedMapNumber = 0;
            string infoMessage = "";

            //searches the maps in the directory
            string[] mapFiles = Directory.GetFiles(@".", "*.txt");

            //creates a HUNTER object
            HUNTER hunter = new HUNTER(0, 0);

            //creates a MAP object
            MAP map;

            //creates a Monster(S) object
            MONSTER_S_ monster_S = new MONSTER_S_();



            //creates a Monster
            //MONSTER monster = new MONSTER(0, 0);

            gameLoop = true;
            intDecide = 1;


            while(gameLoop)
            {

                switch (intDecide)
                {
                    case 1:
                    //reset values
                    gameOn = true;
                    hunter.ResetValues();
                    monster_S.ResetList();
                    
                    map = new MAP();


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

                    } while (selectedMapNumber > map.MAPFILES.Length || selectedMapNumber <= 0);
                    Console.Clear();
                    #endregion

                        map.GlobalLoadAMapFromFile(map.MAPFILES[selectedMapNumber - 1], hunter, monster_S);
                        DrawMap(map.mapArray, hunter, monster_S);
                        ShowGameInfo(hunter, map, selectedMapNumber, infoMessage);
                        while (gameOn)
                        {
                            MoveMonster(canMoveMonster, monster_S, map, hunter);
                            MoveHunter(hunter, map, monster_S);
                            CheckPotion(hunter, map);
                            CheckIfWeaponFound(hunter, map);
                            checkMonsterAndHunter(monster_S, hunter);

                        }
                        AskUserForNewGame();
                        map.resetMapArray(map.MAPFILES);
                        break;

                    case 2:
                        gameLoop = false;
                        break;
                }
            }
            Console.WriteLine("Thankk you for playing!");
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
                    //if player was found
                    if (X == hunter.POSINSCREENX && Y == hunter.POSINSCREENY)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        //draw the char at this position in the array
                        Console.Write('H');
                    }
                    //if monster was found
                    //else if(map[Y][X] == 'M')
                    else if (X == monsters.ReturnMonsterX(monsters.ReturnMonsterList()) && Y == monsters.ReturnMonsterY(monsters.ReturnMonsterList()))
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        //draw the char at this position in the array
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

        //have to fix this
        static void ShowGameInfo(HUNTER hunter, MAP map, int selectedMap, string InfoMessage)
        {

            Console.WriteLine($"Player: {hunter.NAME}");
            Console.WriteLine($"Map: {map.MAPFILES[selectedMap - 1]}");
            Console.WriteLine($"HP: {hunter.CURRENTHP}");
            Console.WriteLine($"Level: {map.MAPFILES[selectedMap - 1].IndexOf(Convert.ToChar(selectedMap)) + 2}");
            Console.WriteLine($"{hunter.HUNTERSCORE}");
            Console.WriteLine($"Infos: {InfoMessage}");//I have to finish implementing info message

        }

        static void MoveMonster(bool canMove, MONSTER_S_ monsters, MAP map, HUNTER hunter)
        {
            if (canMove)
            {

                //bool doneMoving = false;
                foreach (MONSTER thisMonster in monsters.ReturnMonsterList())
                {

                    thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();

                    if (thisMonster.monsterDirection == MONSTER.Direction.Left)
                    {
                        if (thisMonster.POSINSCREENX == 0 || thisMonster.POSINSCREENX - 1 < 0)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (map.mapArray[thisMonster.POSINSCREENY][thisMonster.POSINSCREENX - 1] == '#')
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (thisMonster.POSINSCREENX - 1 == hunter.POSINSCREENX && thisMonster.POSINSCREENY == hunter.POSINSCREENY)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else
                        {

                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.Write(' ');
                            thisMonster.POSINSCREENX = thisMonster.POSINSCREENX - 1;
                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('M');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartMonsterSleepThread(thisMonster);
                        }


                    }

                    if (thisMonster.monsterDirection == MONSTER.Direction.Right)
                    {
                        if (thisMonster.POSINSCREENX == 0 || thisMonster.POSINSCREENX + 1 > map.mapWIDTH)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (map.mapArray[thisMonster.POSINSCREENY][thisMonster.POSINSCREENX + 1] == '#')
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (thisMonster.POSINSCREENX + 1 == hunter.POSINSCREENX && thisMonster.POSINSCREENY == hunter.POSINSCREENY)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else
                        {

                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.Write(' ');
                            thisMonster.POSINSCREENX = thisMonster.POSINSCREENX + 1;
                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('M');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartMonsterSleepThread(thisMonster);
                        }


                    }

                    if (thisMonster.monsterDirection == MONSTER.Direction.Up)
                    {
                        if (thisMonster.POSINSCREENY == 0 || thisMonster.POSINSCREENY - 1 < 0)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (map.mapArray[thisMonster.POSINSCREENY - 1][thisMonster.POSINSCREENX] == '#')
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (thisMonster.POSINSCREENX == hunter.POSINSCREENX && thisMonster.POSINSCREENY - 1 == hunter.POSINSCREENY)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else
                        {


                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.Write(' ');
                            thisMonster.POSINSCREENY = thisMonster.POSINSCREENY - 1;
                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('M');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartMonsterSleepThread(thisMonster);
                        }

                    }

                    if (thisMonster.monsterDirection == MONSTER.Direction.Down)
                    {
                        if (thisMonster.POSINSCREENY == 0 || thisMonster.POSINSCREENY + 1 > map.mapHEIGHT)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (map.mapArray[thisMonster.POSINSCREENY + 1][thisMonster.POSINSCREENX] == '#')
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else if (thisMonster.POSINSCREENX == hunter.POSINSCREENX && thisMonster.POSINSCREENY + 1 == hunter.POSINSCREENY)
                        {
                            thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        }
                        else
                        {

                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.Write(' ');
                            thisMonster.POSINSCREENY = thisMonster.POSINSCREENY + 1;
                            Console.SetCursorPosition(thisMonster.POSINSCREENX, thisMonster.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('M');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartMonsterSleepThread(thisMonster);
                        }


                    }
                    //thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                    //StartMonsterSleepThread(thisMonster, canMove);
                }

            }
        }

        static void StartMonsterSleepThread(MONSTER monster)
        {
            Thread moveUpThread = new Thread(new ThreadStart(() => MonsterSleep(monster.freezeTme)));
            moveUpThread.IsBackground = true;//if close main thread, it will close the child thread
            moveUpThread.Start();
        }

        static void StartHunterSleepThread(HUNTER hunter)
        {
            Thread moveUpThread = new Thread(new ThreadStart(() => HunterSleep(hunter.freezeTme)));
            moveUpThread.IsBackground = true;//if close main thread, it will close the child thread
            moveUpThread.Start();
        }

        static void MonsterSleep(int freezeTime)
        {
            canMoveMonster = false;
            Thread.Sleep(freezeTime);//sleeping in the child thread does not freeze the game
            canMoveMonster = true;
        }

        static void HunterSleep(int freezeTime)
        {
            canMoveHunter = false;
            Thread.Sleep(freezeTime);//sleeping in the child thread does not freeze the game
            canMoveHunter = true;
        }

        static void checkMonsterAndHunter(MONSTER_S_ monsters, HUNTER hunter)
        {
            //checks if a Monster ha a player on it's side and attacks
            foreach (MONSTER monster in monsters.ReturnMonsterList())
            {
                //check up
                if (monster.POSINSCREENY - 1 == hunter.POSINSCREENY && monster.POSINSCREENX == hunter.POSINSCREENX)
                {
                    Attack(hunter, monster);
                }

                //check bottom
                if (monster.POSINSCREENY + 1 == hunter.POSINSCREENY && monster.POSINSCREENX == hunter.POSINSCREENX)
                {
                    Attack(hunter, monster);
                }

                //check left
                if (monster.POSINSCREENY == hunter.POSINSCREENY && monster.POSINSCREENX - 1 == hunter.POSINSCREENX)
                {
                    Attack(hunter, monster);
                }

                //check right
                if (monster.POSINSCREENY == hunter.POSINSCREENY && monster.POSINSCREENX + 1 == hunter.POSINSCREENX)
                {
                    Attack(hunter, monster);
                }
            }
        }

        static void Attack(HUNTER hunter, MONSTER monster)
        {
            //calculates the amount of damage inflicted by the monster
            if (hunter.hasShield == true)
            {
                hunter.CURRENTHP -= monster.STRENGHT - hunter.ARMOR + shield.shieldArmor;
                hunter.CheckIfDead(hunter.CURRENTHP);
                if (hunter.CheckIfDead(hunter.CURRENTHP) == true)
                {
                    gameOn = false;
                }
            }
            else
            {
                hunter.CURRENTHP -= monster.STRENGHT - hunter.ARMOR;
                hunter.CheckIfDead(hunter.CURRENTHP);
                if (hunter.CheckIfDead(hunter.CURRENTHP) == true)
                {
                    gameOn = false;
                }
            }

            //calculates the amount of damage inflicted by the hunter
            if (hunter.hasSword == true)
            {
                monster.CURRENTHP -= hunter.STRENGHT + sword.swordStrenght - monster.ARMOR;
                monster.CheckIfDead(monster.CURRENTHP);
            }

        }

        static void AskUserForNewGame()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing the game!");
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Enter 1 if yes, o 2 to Exit");
            decide = Console.ReadLine();
            if (!int.TryParse(decide, out intDecide))
            {
                //it's not a number
                Console.WriteLine("That's not a number");
                Console.WriteLine("Press a key to try again");
                Console.ReadKey();
                Console.Clear();
            }

            if (intDecide < 1 || intDecide > 2)
            {
                //the number is larger than the available maps
                Console.WriteLine($"Please enter 1 or 2");
                Console.WriteLine("Press a key to try again");
                Console.ReadKey();
                Console.Clear();
            }
            while (intDecide < 1 || intDecide > 2) ;
            
        
        }

        static void CheckPotion(HUNTER hunter, MAP map)
        {
            if(map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'p')
            {
                POTION potion = new POTION(hunter, map);

            }
        }

        static void CheckIfWeaponFound(HUNTER hunter, MAP map)
        {
            if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'w')
            {
                hunter.hasPickaxe = false;
                hunter.hasShield = false;
                sword = new SWORD();
                hunter.hasSword = true;

            }

            if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'h')
            {
                hunter.hasSword = false;
                hunter.hasPickaxe = false;
                shield = new SHIELD();
                hunter.hasShield = true;

            }

            if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'x')
            {
                hunter.hasSword = false;
                hunter.hasShield = false;
                pickaxe = new PICKAXE();
                hunter.hasPickaxe = true;

            }


        }
        
        static void MoveHunter(HUNTER hunter, MAP map,MONSTER_S_ monsters)
        {
            keyPressed = Console.ReadKey();

            if (canMoveHunter)
            {
                switch (keyPressed.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (hunter.POSINSCREENX > 0
                            && map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX -1] != '#'
                             && !monsters.ReturnMonsterList().Exists
                            (monster => monster.POSINSCREENX == hunter.POSINSCREENX-1 
                            && monster.POSINSCREENY == hunter.POSINSCREENY))

                        {

                            //clear the actual player position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.Write(' ');
                            //move the player to the left in memory
                            hunter.POSINSCREENX--;
                            //draw player at new position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('H');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartHunterSleepThread(hunter);
                        }
                        if(map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOn = false;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (hunter.POSINSCREENX > 0 && hunter.POSINSCREENX + 1 < map.mapArray[hunter.POSINSCREENY].Length-1
                            && map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX+1] != '#'
                             && !monsters.ReturnMonsterList().Exists
                            (monster => monster.POSINSCREENX == hunter.POSINSCREENX+1 
                            && monster.POSINSCREENY == hunter.POSINSCREENY))
                        {
                            //clear the actual player position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.Write(' ');
                            //move the player to the left in memory
                            hunter.POSINSCREENX++;
                            //draw player at new position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('H');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartHunterSleepThread(hunter);

                        }
                        if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOn = false;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (hunter.POSINSCREENY > 0
                            && map.mapArray[hunter.POSINSCREENY-1][hunter.POSINSCREENX] != '#'
                            && !monsters.ReturnMonsterList().Exists
                            (monster => monster.POSINSCREENX ==hunter.POSINSCREENX 
                            && monster.POSINSCREENY == hunter.POSINSCREENY -1))
                        {
                            //clear the actual player position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.Write(' ');
                            //move the player to the left in memory
                            hunter.POSINSCREENY--;
                            //draw player at new position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('H');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartHunterSleepThread(hunter);
                            if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                            {
                                gameOn = false;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (hunter.POSINSCREENY > 0 && hunter.POSINSCREENY + 1 < map.mapArray.GetLength(0)-1
                            && map.mapArray[hunter.POSINSCREENY + 1][hunter.POSINSCREENX] != '#'
                            && !monsters.ReturnMonsterList().Exists
                            (monster => monster.POSINSCREENX == hunter.POSINSCREENX 
                            && monster.POSINSCREENY == hunter.POSINSCREENY + 1))
                        {
                            //clear the actual player position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.Write(' ');
                            //move the player to the left in memory
                            hunter.POSINSCREENY++;
                            //draw player at new position
                            Console.SetCursorPosition(hunter.POSINSCREENX, hunter.POSINSCREENY);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('H');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            StartHunterSleepThread(hunter);
                            if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                            {
                                gameOn = false;
                            }
                        }
                        break;
                }




            }

        }
    }   
    
}
