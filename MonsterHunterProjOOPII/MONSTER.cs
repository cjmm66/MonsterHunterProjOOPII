using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonsterHunterProjOOPII
{
    public class MONSTER : CHARACTER
    {
        //const
        const int MIN_NUM_DIRECTION = 1;
        const int MAX_NUM_DIRECTION = 6;//one more because of the .Next() max value handlement

        //variables
        static bool canMove = true;

        public Direction monsterDirection;
        
        public MONSTER(int X, int Y) : base(X,Y)
        {
            base.freezeTme = 2000; //sets the freeze time to 2 secs
        }

        public override bool moveCharacter(int X, int Y, MONSTER_S_ monsters ,HUNTER hunter, char [][] map)
        {
            bool doneMoving = false;
            foreach (MONSTER thisMonster in monsters.ReturnMonsterList())
            {
                //if there are pixels left to move
                if (canMove)
                {
                    if(map[X][Y] != '#' && X != hunter.POSINSCREENX && Y != hunter.POSINSCREENY)
                        if (thisMonster.monsterDirection == MONSTER.Direction.Left)
                        {
                            thisMonster.POSINSCREENX = X;
                            thisMonster.POSINSCREENY = Y;
                        }

                        if (thisMonster.monsterDirection == Monster.Direction.Right)
                        {
                            thisMonster.monsterPictureBox.Left++;
                            thisMonster.pixelsToMove--;
                        }

                        //if the monster is done moving
                        if (thisMonster.pixelsToMove == 0)
                        {
                            //Specify the monster is not moving in any direction
                            thisMonster.monsterDirection = Monster.Direction.None;
                            doneMoving = true;
                        }
                }
                return false;
            }
        }

        static void StartMonsterSleepThread()
        {
            Thread moveUpThread = new Thread(new ThreadStart(playerSleep));
            moveUpThread.IsBackground = true;//if close main thread, it will close the child thread
            moveUpThread.Start();
        }

        static void playerSleep()
        {
            canMove = false;
            Thread.Sleep(3000);//sleeping in the child thread does not freeze the game
            canMove = true;
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }

        public Direction ReturnRandomDirection()
        {
            int numChosen;
            numChosen = RNG.Instance.Next(MIN_NUM_DIRECTION, MAX_NUM_DIRECTION);

            switch (numChosen)
            {
                case 1:
                    return Direction.Down;

                case 2:
                    return Direction.Left;

                case 3:
                    return Direction.Right;

                case 4:
                    return Direction.Up;

                case 5:
                    return Direction.None;

                default
                    return Direction.None;
                    

                

            }
        }
    }
}
