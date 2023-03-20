using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerCreatorNS
{
    public class AimHolder : MonoBehaviour
    {
        public AimType Types;
        public static readonly Dictionary<AimType, Type> EffectTypeMap = new Dictionary<AimType, Type>
        {
            { AimType.shoot, typeof(AimModuleShoot) },
            { AimType.AoE, typeof(AimModuleAoE) }
        };

        public object ReturnType()
        {
            if (EffectTypeMap.TryGetValue(Types, out Type effectType))
            {
                return effectType;
            }
            return null;
        }
    }

    public enum AimType
    {
        shoot,
        AoE
    }
}
