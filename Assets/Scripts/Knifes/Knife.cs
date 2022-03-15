using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;
    
    public Rigidbody2D Rigidbody { get; private set; }
    public Collider2D Collider { get; private set; }
    public bool Stucked { get; private set; } = false;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
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
            return;
        }

        if (Stucked == false)
        {
            _trail.enabled = false;
            Rigidbody.isKinematic = true;
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.freezeRotation = true;
            Stucked = true;
            transform.SetParent(other.transform);
        }
    }
}
