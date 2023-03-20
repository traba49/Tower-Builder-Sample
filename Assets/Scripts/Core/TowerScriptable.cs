using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class TowerScriptable
    {
        public int SaveInt;
        public object AimType;
        public object[] Modules;

        public TowerScriptable(int _moduleSlots)
        {
            AimType = new AimModuleShoot();
            Modules = new object[_moduleSlots];
        }

        public string ModulesToText()
        {
            string _info = AimType.ToString() + "<br> ";
            for (int i = 0; i < Modules.Length; i++)
            {
                if (Modules[i] != null)
                {
                    _info += Modules[i].ToString() + "<br> ";
                }
                else
                {
                    _info += "Empty slot <br> ";
                }
            }

            return _info;
        }
    }
}
