using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterProjOOPII
{
    public class MONSTER_S_
    {
        //const
        const int DEFAULT_RETURN = 0;

        private List <MONSTER> allMonsters;

        public MONSTER_S_()
        {
            //I was getting a null error so this helped
            allMonsters = new List<MONSTER>();
        }

        public List<MONSTER> FindMonster(List<MONSTER> allMonsters, int X, int Y)
        {
            return allMonsters.FindAll(monster => monster.POSINSCREENX == X && monster.POSINSCREENY == Y);
        }

        public int ReturnMonsterX(List<MONSTER> monsterList)//, int X)
        {
            int safeReturn = -1;
            foreach(MONSTER monster in monsterList)
            {
                //if(monster.POSINSCREENX == X)
                //{
                    return monster.POSINSCREENX;
                //}
                //break;
            }
            return safeReturn;
        }

        public int ReturnMonsterY(List<MONSTER> monsterList)//, int Y)
        {
            int safeRetrun = -1;
            foreach (MONSTER monster in monsterList)
            {
                //if(monster.POSINSCREENY == Y)
                //{
                    safeRetrun = monster.POSINSCREENY;
                    return monster.POSINSCREENY;
                //}
                //break;
            }
            return safeRetrun;
        }

        public void AddToMonstersList(MONSTER monster)
        {
            allMonsters.Add(monster);
        }

        public List<MONSTER> ReturnMonsterList()
        {

            return allMonsters;
        }

        public void ResetList()
        {
            for(int i = allMonsters.Count -1; i>=0;i--)
            {
                allMonsters.RemoveAt(i);
            }
        }

    }
}
