﻿using System;
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

        public Direction monsterDirection;

        public MONSTER(int X, int Y) : base(X, Y)
        {
            base.freezeTme = 2000; //sets the freeze time to 2 secs
        }

        public override bool moveCharacter(int mapX, int mapY)
        {
            if (mapX != this.POSINSCREENX && mapY != this.POSINSCREENY)
            {
                return true;
            }


                return false;
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

                default:
                        return Direction.None;




            }
        }
    }
}

