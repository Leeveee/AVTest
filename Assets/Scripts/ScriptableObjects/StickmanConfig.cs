using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "StickmanConfig", menuName = "Configs/StickmanConfig")]
    public class StickmanConfig : ScriptableObject
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private HealthData _healthData;
        
        public int Damage =>_damage;
        public HealthData HealthData => _healthData;
    }
}