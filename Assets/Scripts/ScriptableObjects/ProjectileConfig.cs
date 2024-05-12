using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Configs/ProjectileConfig")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField]
        private int _damage;
        
        public int Damage =>_damage;
    }
}