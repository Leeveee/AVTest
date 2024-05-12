using DamageHandler;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Turret
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        private ProjectileConfig _projectileConfig;

        [Inject]
        private void Construct(GameConfig gameConfig)
        {
            _projectileConfig = gameConfig.ProjectileConfig;
        }
        
        public Rigidbody Rigidbody =>_rigidbody;

        private void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.TryGetComponent( out IDamageable damageable))
            {
                damageable.GetDamage(_projectileConfig.Damage);
                DisposeProjectile();
            }
        }

        private void DisposeProjectile()
        {
            Destroy(gameObject);
        }
    }
}