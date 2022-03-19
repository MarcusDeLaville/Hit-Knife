using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class KnifeAnimation : Animation
    {
        //todo: Согласен что реализация может быть странной, но я решил что было классно выделить слой под работу с анимациями и прописывать их в Handler
        
        [SerializeField] private Transform _knifeSpawnPoint;
        [SerializeField] private Vector2 _fightPosition;
        [SerializeField] private Vector2 _homePosition;

        public override void Animate(int variant)
        {
            switch (variant)
            {
                case 1:
                    _knifeSpawnPoint.DOMove(_fightPosition, _duration);
                    break;
                case 2:
                    _knifeSpawnPoint.DOMove(_homePosition, _duration);
                    break;
            }
        }
    }
}