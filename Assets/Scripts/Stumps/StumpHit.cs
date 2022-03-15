using DG.Tweening;
using UnityEngine;

public class StumpHit : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private int _emitCount;

    [Space(10)] [SerializeField] private Vector3 _punchForse;
    [SerializeField] private float _punchDuration = 0.3f;
    [SerializeField] private int _punchVibrato = 3;
    
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _hitEffect.transform.position = other.contacts[0].point;
        _transform.DOPunchScale(_punchForse, _punchDuration, _punchVibrato);
        _hitEffect.Emit(_emitCount);
    }
}
