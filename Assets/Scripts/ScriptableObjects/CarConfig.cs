using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CarConfig", menuName = "Configs/CarConfig")]
    public class CarConfig : ScriptableObject
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private HealthData _healthData;

        public float Speed => _speed;
        public HealthData HealthData => _healthData;
    }
}