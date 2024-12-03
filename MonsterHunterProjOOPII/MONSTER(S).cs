using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class MONSTER_S_
    {
        private List <MONSTER> allMonsters;

        public MONSTER_S_()
        {
            //I was getting a null error so this helped
            allMonsters = new List<MONSTER>();
        }

        public List<MONSTER> FindMonsters(List<MONSTER> allMonsters, int X, int Y)
        {
            return allMonsters.FindAll(monster => monster.POSINSCREENX == X && monster.POSINSCREENY == Y);
        }

        public void AddToMonstersList(MONSTER monster)
        {
            allMonsters.Add(monster);
        }

        public List<MONSTER> ReturnMonsterList()
        {

            return allMonsters;
        }

    }
}
