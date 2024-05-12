using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField]
        private CarConfig _carConfig;
        [SerializeField]
        private TurretConfig _turretConfig;
        [SerializeField]
        private StickmanConfig _stickmanConfig;
        [SerializeField]
        private ProjectileConfig _projectileConfig;

        public CarConfig CarConfig => _carConfig;
        public TurretConfig TurretConfig => _turretConfig;
        public StickmanConfig StickmanConfig => _stickmanConfig;
        public ProjectileConfig ProjectileConfig => _projectileConfig;
    }
}