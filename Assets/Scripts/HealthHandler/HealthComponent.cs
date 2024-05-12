using System;
using Components;
using DamageHandler;
using Extensions;
using UnityEngine;

namespace HealthHandler
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        public event Action<HealthInfo, int> OnGetDamage;
        
        private CharacterBase _owner;
        private int _health;

        public Vector3 HpBarPosition => _owner.transform.position.AddY(_owner.HealthData.HpBarPositionOffset);
        public int Health => _health;

        private void Awake()
        {
            _owner = gameObject.GetComponent<CharacterBase>();
            _health = _owner.HealthData.MaxHealth;
        }

        public void GetDamage (int amount)
        {
            if (!_owner.IsAlive)
            {
                return;
            }

            int newHealth = _health - amount;
            _health = Mathf.Max(0, newHealth);

            HealthInfo damageInfo = new HealthInfo
            {
                CurrentHealth = _health,
                MaxHealth = _owner.HealthData.MaxHealth,
            };

            OnGetDamage?.Invoke(damageInfo, amount);

            if (_health <= 0)
            {
                _owner.Death();
            }
        }
    }
}