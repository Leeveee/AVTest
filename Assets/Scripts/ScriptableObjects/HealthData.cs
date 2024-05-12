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
        
        public int MaxHealth =>_maxHealth;
        public float HpBarPositionOffset => _hpBarPositionOffset;
    }
}