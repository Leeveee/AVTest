using System;
using HealthHandler;
using UnityEngine;

namespace DamageHandler
{
    public interface IDamageable
    {
        public event Action<HealthInfo,int> OnGetDamage;
        public void GetDamage (int amount);
        public Vector3 HpBarPosition { get; }

    }
}