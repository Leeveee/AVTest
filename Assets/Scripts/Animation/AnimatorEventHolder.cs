using System;
using UnityEngine;

namespace Animation
{
  [RequireComponent(typeof(Animator))]
  public class AnimatorEventHolder : MonoBehaviour
  {
    public event Action TakeDamage;

    private void OnTakeDamage()
    {
      TakeDamage?.Invoke();
    }
  }
}