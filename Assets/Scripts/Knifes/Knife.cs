using System;
using Stumps;
using UnityEngine;
using Random = UnityEngine.Random;

public class Knife : MonoBehaviour
{
    public Action Miss;
    
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private bool _stuckAtStart;
    
    public Rigidbody2D Rigidbody { get; private set; }
    public Collider2D Collider { get; private set; }
    public bool Stucked { get; private set; } = false;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();

        if (_stuckAtStart == true)
        {
            Stuck(null, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Knife knife) && knife.Stucked == true)
        {
            Collider.enabled = false;
            Rigidbody.freezeRotation = false;
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.angularVelocity = Random.Range(20f, 50f) * 15f;
            Rigidbody.AddForce (new Vector2 (Random.Range (-5f, 5f), -10f), ForceMode2D.Impulse);
            Miss?.Invoke();
            return;
        }

        if (other.transform.TryGetComponent(out StumpEndurance stump) && Stucked == false)
        {
            Stuck(other.transform, false);
            stump.Hit(other.contacts[0].point);
        }
    }

    private void Stuck(Transform stackTarget, bool atStart)
    {
        _trail.gameObject.SetActive(false);
        Rigidbody.isKinematic = true;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.freezeRotation = true;
        Stucked = true;
        if (atStart == false)
        {
            transform.SetParent(stackTarget);
        }
    }
}
