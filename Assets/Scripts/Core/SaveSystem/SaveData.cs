using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class SaveData
    {
        public TowerScriptable[] TowerList;

        public SaveData()
        {
            TowerList = new TowerScriptable[10];
        }

        public void AddTower(TowerScriptable tower)
        {
            for (int i = 0; i < TowerList.Length; i++)
            {
                if (TowerList[i] == null)
                {
                    tower.SaveInt = i;
                    TowerList[i] = tower;
                    return;
                }
            }
        }

        public void DeleteTower(int i)
        {
            TowerList[i] = null;
        }
    }
}
