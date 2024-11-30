using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    class RNG : Random
    {
        //variables
        static bool busy = false;

        //create singleton
        private static RNG instance = null;

        public static RNG Instance
        {
            get
            {
                //while (busy) ;

                if (instance == null)
                {//first time
                    busy = true;
                    instance = new RNG(); //1second
                    busy = false;
                }
                return instance;
            }
        }
    }
}
