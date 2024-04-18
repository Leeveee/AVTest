using UnityEngine;

namespace Animation
{
    public class AnimationComponent : MonoBehaviour
    {
        public const float NONE = 0;
        public const float LITTLE_SMOOTH = 0.1f;

        [SerializeField]
        private Animator _animator;

        public void ChangeAnimation (int animationId, float smooth, int layer = 0)
        {
            _animator.CrossFade(animationId, smooth, layer);
        }
    }
}