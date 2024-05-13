using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "StickmanConfig", menuName = "Configs/StickmanConfig")]
    public class StickmanConfig : ScriptableObject
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private  float _rotationSpeed;
        [SerializeField]
        private  float _moveSpeed;
        [SerializeField]
        private HealthData _healthData;
        
        public int Damage =>_damage;
        public float RotationSpeed => _rotationSpeed;
        public float MoveSpeed => _moveSpeed;
        public HealthData HealthData => _healthData;
    }
}