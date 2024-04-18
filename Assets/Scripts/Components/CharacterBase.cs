using UnityEngine;

namespace Components
{
    public class CharacterBase : MonoBehaviour
    {
        public bool IsAlive { get; set; }
        public virtual void Death()
        {
            IsAlive = false;
            Destroy(gameObject);
        }
    }
}