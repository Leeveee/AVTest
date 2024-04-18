using UnityEngine;

namespace Animation
{
    public static class AnimatorHash
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Run = Animator.StringToHash("Run");
        public static readonly int Attack = Animator.StringToHash("Attack");
    }
}