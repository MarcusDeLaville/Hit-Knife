using System;
using UnityEngine;

namespace Apples
{
    public class Apple : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _brokeEffect;
        [SerializeField] private SpriteRenderer _appleSprite;
        
        private bool _isBroken = false;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isBroken == false)
            {
                Broke();
            }
        }

        private void Broke()
        {
            transform.SetParent(null);
            _isBroken = true;
            _appleSprite.enabled = false;
            _brokeEffect.Play();
        }
    }
}