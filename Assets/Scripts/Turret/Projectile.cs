using Components;
using UnityEngine;

namespace Turret
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private int _damage;
        
        public Rigidbody Rigidbody =>_rigidbody;

        private void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.TryGetComponent( out IDamageable damageable))
            {
                damageable.GetDamage(_damage);
                DisposeProjectile();
            }
        }

        private void DisposeProjectile()
        {
            Destroy(gameObject);
        }
    }
}