using DamageHandler;
using UnityEngine;

namespace HealthBar
{
    public class HealthBarCanvas : MonoBehaviour
    {
        [SerializeField]
        private HealthBar _healthBar;

        public void SpawnHealthBar (IDamageable damageable)
        {
            HealthBar healthBar = Instantiate(_healthBar, transform);
            healthBar.InitCharacterTakeDamage(damageable);
        }
    }
}