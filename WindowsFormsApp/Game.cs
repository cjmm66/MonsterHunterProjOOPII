using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonsterHunterProjOOPII;
using System.Threading;

namespace WindowsFormsApp
{
    public partial class Game : Form
    {
        static bool gameOver = false;

        const int SQUARE_SIZE = 30;

        public HUNTER hunter = new HUNTER(0, 0);

        public MONSTER_S_ monster_S = new MONSTER_S_();

        public MAP map;

        public string selectedMap;

        bool readyToMove = true;


        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            MessageBox.Show(selectedMap);
            map = new MAP();
            map.GlobalLoadAMapFromFile(selectedMap, hunter, monster_S);
            DrawMap(map.mapArray, hunter, monster_S);
        }



        private void DrawMap(char[][] map, HUNTER hunter, MONSTER_S_ monsters)
        {
            //loop in the 1st dimension of the array
            for (int y = 0; y < map.GetLength(0); y++)
            {
                //loop in the secodn array
                for (int x = 0; x < map[y].Length; x++)
                {
                    //draw map
                    if (map[y][x] == '#')
                    {
                        PictureBox newWall = new PictureBox();
                        newWall.Name = "picWall-" + x + "-" + y;
                        newWall.Image = Properties.Resources.wall;
                        newWall.Width = SQUARE_SIZE;//use const
                        newWall.Height = SQUARE_SIZE;//use const
                        newWall.SizeMode = PictureBoxSizeMode.StretchImage;
                        newWall.Left = x * SQUARE_SIZE;//use const
                        newWall.Top = y * SQUARE_SIZE;
                        this.Controls.Add(newWall);


                    }

                    //draw player
                    if (x == hunter.POSINSCREENX && y == hunter.POSINSCREENY)
                    {

                        picPlayer.Left = hunter.POSINSCREENX * SQUARE_SIZE;
                        picPlayer.Top = hunter.POSINSCREENY * SQUARE_SIZE;
                    }

                    //draw monster
                    if (x == monsters.ReturnMonsterX(monsters.ReturnMonsterList()) && y == monsters.ReturnMonsterY(monsters.ReturnMonsterList()))
                    {
                        monsterPic.Left = x * SQUARE_SIZE;
                        monsterPic.Top = y * SQUARE_SIZE;
                    }

                    //draw goal
                    if(map[y][x] == 'G')
                    {
                        picGoal.Left = x * SQUARE_SIZE;
                        picGoal.Top = y * SQUARE_SIZE;
                    }

                }

            }
        }

       

        private void moveUpPlayerSlowlyInChildThread()//no params
        {
            int xVelocity = 0;
            int yVelocity = -1;
            //int squareSize = SQUARE_SIZE;
            //use constant
            int sleepTime = hunter.freezeTme/ SQUARE_SIZE;

            for (int i = 1; i < SQUARE_SIZE; i++)
            {
                Thread.Sleep(sleepTime);//because sleep is running in child thread,
                                        //we're not freezing our game
                                        //call the delegate ("bridge" between the threads )
                Invoke(new movePlayerBetweenThreads(movePlayerByOneFrame),
                    new object[] { xVelocity, yVelocity, readyToMove});

            }

        }

        private void moveDownPlayerSlowlyInChildThread()//no params
        {
            int xVelocity = 0;
            int yVelocity = 1;
            //int squareSize = SQUARE_SIZE;
            //use constant
            int sleepTime = 1000 / SQUARE_SIZE;

            for (int i = 1; i < SQUARE_SIZE; i++)
            {
                Thread.Sleep(sleepTime);//because sleep is running in child thread,
                                        //we're not freezing our game
                                        //call the delegate ("bridge" between the threads )
                Invoke(new movePlayerBetweenThreads(movePlayerByOneFrame),
                    new object[] { xVelocity, yVelocity , readyToMove });


            }

        }

        private void moveLeftPlayerSlowlyInChildThread()//no params
        {
            int xVelocity = -1;
            int yVelocity = 0;
            //int squareSize = SQUARE_SIZE;
            //use constant
            int sleepTime = 1000 / SQUARE_SIZE;

            for (int i = 1; i < SQUARE_SIZE; i++)
            {
                Thread.Sleep(sleepTime);//because sleep is running in child thread,
                                        //we're not freezing our game
                                        //call the delegate ("bridge" between the threads )
                Invoke(new movePlayerBetweenThreads(movePlayerByOneFrame),
                    new object[] { xVelocity, yVelocity,readyToMove });


            }

        }

        private void moveRightPlayerSlowlyInChildThread()//no params
        {
            int xVelocity = 1;
            int yVelocity = 0;
            //int squareSize = SQUARE_SIZE;
            //use constant
            int sleepTime = 1000 / SQUARE_SIZE;

            for (int i = 1; i < SQUARE_SIZE; i++)
            {
                Thread.Sleep(sleepTime);//because sleep is running in child thread,
                                        //we're not freezing our game
                                        //call the delegate ("bridge" between the threads )
                Invoke(new movePlayerBetweenThreads(movePlayerByOneFrame),
                    new object[] { xVelocity, yVelocity, readyToMove });


            }

        }

        private delegate void movePlayerBetweenThreads(int xVelocity, int yVelocity, bool doneMoving);

        private void movePlayerByOneFrame(int xVelocity, int yVelocity, bool doneMoving)
        {
            readyToMove = false;
            picPlayer.Left = picPlayer.Left + xVelocity;
            picPlayer.Top = picPlayer.Top + yVelocity;
            if (doneMoving)
            {
                readyToMove = true;
            }

        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                MessageBox.Show("Sorry I couldn't make the form as good as the console");
                this.Hide();
                Application.Exit();
                
            }
            switch(e.KeyCode)
            {
                case Keys.Up:
                    if (hunter.POSINSCREENY > 0
                    && map.mapArray[hunter.POSINSCREENY - 1][hunter.POSINSCREENX] != '#'
                    && !monster_S.ReturnMonsterList().Exists
                    (monster => monster.POSINSCREENX == hunter.POSINSCREENX
                    && monster.POSINSCREENY == hunter.POSINSCREENY - 1))
                    {
                        hunter.POSINSCREENY--;
                        picPlayer.Top = hunter.POSINSCREENY * SQUARE_SIZE;
                        if(map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOver = true;
                        }
                    }
                    //Thread moveUpThread = new Thread(new ThreadStart(this.moveUpPlayerSlowlyInChildThread));
                    //moveUpThread.IsBackground = true;
                    //moveUpThread.Start();
                    break;

                case Keys.Left:
                    if (hunter.POSINSCREENX > 0
                           && map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX - 1] != '#'
                            && !monster_S.ReturnMonsterList().Exists
                           (monster => monster.POSINSCREENX == hunter.POSINSCREENX - 1
                           && monster.POSINSCREENY == hunter.POSINSCREENY))
                    {
                        hunter.POSINSCREENX--;
                        picPlayer.Left = hunter.POSINSCREENX * SQUARE_SIZE;
                        if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOver = true;
                        }
                    }
                    //Thread moveLeftThread = new Thread(new ThreadStart(this.moveLeftPlayerSlowlyInChildThread));
                    //moveLeftThread.IsBackground = true;
                    //moveLeftThread.Start();

                    break;

                case Keys.Right:
                    if (hunter.POSINSCREENX > 0 && hunter.POSINSCREENX + 1 < map.mapArray[hunter.POSINSCREENY].Length - 1
                           && map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX + 1] != '#'
                            && !monster_S.ReturnMonsterList().Exists
                           (monster => monster.POSINSCREENX == hunter.POSINSCREENX + 1
                           && monster.POSINSCREENY == hunter.POSINSCREENY))
                    {
                        hunter.POSINSCREENX++;
                        picPlayer.Left = hunter.POSINSCREENX * SQUARE_SIZE;
                        if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOver = true;
                        }
                    }
                    //Thread moveRightThread = new Thread(new ThreadStart(this.moveRightPlayerSlowlyInChildThread));
                    //moveRightThread.IsBackground = true;
                    //moveRightThread.Start();
                    break;

                case Keys.Down:
                    if (hunter.POSINSCREENY > 0 && hunter.POSINSCREENY + 1 < map.mapArray.GetLength(0) - 1
                            && map.mapArray[hunter.POSINSCREENY + 1][hunter.POSINSCREENX] != '#'
                            && !monster_S.ReturnMonsterList().Exists
                            (monster => monster.POSINSCREENX == hunter.POSINSCREENX
                            && monster.POSINSCREENY == hunter.POSINSCREENY + 1))
                    {
                        hunter.POSINSCREENY++;
                        picPlayer.Top = hunter.POSINSCREENY * SQUARE_SIZE;
                        if (map.mapArray[hunter.POSINSCREENY][hunter.POSINSCREENX] == 'G')
                        {
                            gameOver = true;
                        }
                    }
                    //Thread moveDownThread = new Thread(new ThreadStart(this.moveDownPlayerSlowlyInChildThread));
                    //moveDownThread.IsBackground = true;
                    //moveDownThread.Start();
                    break;
            }
        }

        private void moveMonsterByOneFrame()//In the main thread we need to move the pictureBox
        {
            bool doneMoving = false;
            foreach (MONSTER thisMonster in monster_S.ReturnMonsterList())
            {
                thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                //if there are pixels left to move
                if (thisMonster.pixelsToMove > 0)
                {
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

                            monsterPic.Left--;
                            thisMonster.pixelsToMove--;
                            
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

                            monsterPic.Left++;
                            thisMonster.pixelsToMove--;
                            
                        }

                    }

                    if(thisMonster.monsterDirection == MONSTER.Direction.Up)
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

                            monsterPic.Top--;
                            thisMonster.pixelsToMove--;

                           
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

                            monsterPic.Top++;
                            thisMonster.pixelsToMove--;
                            
                        }
                    }


                    //if the monster is done moving
                    if (thisMonster.pixelsToMove == 0)
                    {
                        //Specify the monster is not moving in any direction
                        thisMonster.monsterDirection = thisMonster.ReturnRandomDirection();
                        doneMoving = true;
                    }
                }

            }
            if (doneMoving)
            {
                foreach (MONSTER thisMonster in monster_S.ReturnMonsterList())
                {
                    //TODO: choose randomly a new direction to move(check walls collision, re-roll if yes)
                    thisMonster.monsterDirection = MONSTER.Direction.Left;
                    thisMonster.pixelsToMove = 50;
                }

                Thread moveUpThread = new Thread(new ThreadStart(this.moveMonsterSlowlyInChildThread));
                moveUpThread.IsBackground = true;//if close main thread, it will close the child thread
                moveUpThread.Start();
            }
        }

        private void moveMonsterSlowlyInChildThread()
        {
            int squareSize = SQUARE_SIZE;
            int sleepTime = 2000 / SQUARE_SIZE; //use a var instead of 2000

            for (int i = 1; i <= squareSize; i++)
            {
                Thread.Sleep(sleepTime);//because sleep is running in child thread,
                                        //we're not freezing the game
                                        //Call delegate ("bridge") to move
                Invoke(new moveMonstersBetweenThreads(moveMonsterByOneFrame));
            }

        }

        private delegate void moveMonstersBetweenThreads();

        
    }
}
