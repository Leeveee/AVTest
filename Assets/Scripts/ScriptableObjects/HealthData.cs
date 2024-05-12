using System;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class HealthData 
    {
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private float _hpBarPositionOffset;
        [SerializeField]
        private ParticleSystem _DieParticle;
        
        public int MaxHealth =>_maxHealth;
        public float HpBarPositionOffset => _hpBarPositionOffset;
        public ParticleSystem ParticleSystem => _DieParticle;
    }
}