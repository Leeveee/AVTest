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

        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private float _hpBarPositionOffset;

        private CharacterBase _owner;
        private float _timeSinceLastHeal;
        private int _health;

        public Vector3 Position => Owner.transform.position;
        public Vector3 HpBarPosition => Owner.transform.position.AddY(_hpBarPositionOffset);
        public bool IsAlive => Owner.IsAlive;
        public CharacterBase Owner => _owner;

        public int Health => _health;

        private void Awake()
        {
            _owner = gameObject.GetComponent<CharacterBase>();
            _health = _maxHealth;
        }

        public void GetDamage (int amount)
        {
            if (!Owner.IsAlive)
            {
                return;
            }

            int newHealth = _health - amount;
            _health = Mathf.Max(0, newHealth);

            HealthInfo damageInfo = new HealthInfo
            {
                CurrentHealth = _health,
                MaxHealth = _maxHealth,
            };

            OnGetDamage?.Invoke(damageInfo, amount);

            if (_health <= 0)
            {
                Owner.Death();
            }
        }
    }
}