using System.Collections.Generic;
using UnityEngine;
using System;

namespace TowerCreatorNS
{
    public class ModuleHolder : MonoBehaviour
    {
        public ModuleTypes Types;
        public static readonly Dictionary<ModuleTypes, Type> EffectTypeMap = new Dictionary<ModuleTypes, Type>
        {
            { ModuleTypes.damage, typeof(EffectModuleDamage) },
            { ModuleTypes.HP_up, typeof(EffectModuleHpUp) },
            { ModuleTypes.slowdown, typeof(EffectModuleSlowdown) }
        };

        public object ReturnType()
        {
            if (EffectTypeMap.TryGetValue(Types, out Type effectType))
            {
                return effectType;
            }
            return null;
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