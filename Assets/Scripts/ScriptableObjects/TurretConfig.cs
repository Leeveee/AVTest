using Turret;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TurretConfig", menuName = "Configs/TurretConfig")]
    public class TurretConfig : ScriptableObject
    {
        [SerializeField]
        private float _rotationSpeed;
        [SerializeField]
        private float _maxRotation;
        [SerializeField]
        private float _fireRate;
        [SerializeField]
        private int _firePower;
        [SerializeField]
        private Projectile _projectile;

        public float RotationSpeed => _rotationSpeed;
        public float MaxRotation => _maxRotation;
        public float FireRate => _fireRate;
        public int FirePower => _firePower;
        public Projectile Projectile => _projectile;
    }
}