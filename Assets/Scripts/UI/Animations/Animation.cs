using UnityEngine;

namespace UI
{
    public abstract class Animation : MonoBehaviour
    {
        [SerializeField] protected float _duration;
        
        public abstract void Animate(int variant);
    }
}