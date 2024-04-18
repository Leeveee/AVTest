﻿using UnityEngine;

namespace Animation
{
  public class AnimationComponent : MonoBehaviour
  {
    public const float NONE = 0;
    public const float VERY_LITTLE_SMOOTH = 0.1f;
    public const float LITTLE_SMOOTH = 0.2f;
    
    [SerializeField]
    private Animator _animator;
    
    public void ChangeAnimation (int animationId, float smooth, int layer = 0)
    {
      _animator.CrossFade(animationId, smooth, layer);
    }
  }
}