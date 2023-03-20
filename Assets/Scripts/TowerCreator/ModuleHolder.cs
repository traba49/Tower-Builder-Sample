using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerCreatorNS
{
    public class ModuleHolder : MonoBehaviour
    {
        public ModuleTypes Types;

        public object ReturnType()
        {
            switch (Types)
            {
                case ModuleTypes.damage:
                    EffectModuleDamage e = new EffectModuleDamage();
                    return e;
                case ModuleTypes.HP_up:
                    EffectModuleHpUp r = new EffectModuleHpUp();
                    return r;
                case ModuleTypes.slowdown:
                    EffectModuleSlowdown t = new EffectModuleSlowdown();
                    return t;
                default:
                    return null;
            }
        }

        private void OnDisable()
        {
            Destroy(gameObject);
        }
    }
    public enum ModuleTypes
    {
        damage,
        HP_up,
        slowdown
    }
}