using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class MONSTER : CHARACTER
    {
        public MONSTER(int X, int Y) : base(X,Y)
        {
            base.freezeTme = 2000; //sets the freeze time to 2 secs
        }

        public override bool moveCharacter(int X, int Y)
        {
            return false;
        }
    }
}
