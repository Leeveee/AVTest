using ScriptableObjects;
using UnityEngine;

namespace Components
{
    public  class CharacterBase : MonoBehaviour
    {
        public virtual HealthData  HealthData { get; set; }
        public bool IsAlive { get; set; }
        public virtual void Death()
        {
            IsAlive = false;
            Destroy(gameObject);
        }
    }
}