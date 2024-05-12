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
            PlayEffect();
            IsAlive = false;
            Destroy(gameObject, 0.1f);
        }

        private void PlayEffect()
        {
            Instantiate(HealthData.ParticleSystem, transform.position, transform.rotation).Play();
        }
    }
}