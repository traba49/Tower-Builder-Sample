using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerCreatorNS
{
    public class AimHolder : MonoBehaviour
    {
        public AimType Types;

        public object ReturnType()
        {
            switch (Types)
            {
                case AimType.shoot:
                    AimModuleShoot e = new AimModuleShoot();
                    return e;
                case AimType.AoE:
                    AimModuleAoE r = new AimModuleAoE();
                    return r;
                default:
                    return null;
            }
        }
    }

    public enum AimType
    {
        shoot,
        AoE
    }
}
