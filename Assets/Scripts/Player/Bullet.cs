using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float AutoDestroyTime = 5f;
    public float MoveSpeed = 2f;
    public int Damage = 5;
    public Rigidbody2D Rigidbody;
    protected Transform Target;

    protected const string DISABLE_METHOD_NAME = "Disable";

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        CancelInvoke(DISABLE_METHOD_NAME);
        Invoke(DISABLE_METHOD_NAME, AutoDestroyTime);
    }

    public virtual void Spawn(Vector3 Forward, int Damage, Transform Target)
    {
        this.Damage = Damage;
        this.Target = Target;
        Rigidbody.AddForce(Forward * MoveSpeed, ForceMode2D.Force);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        /*IDamageable damageable;

        if (other.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(Damage);
        }
*/
        Disable();
    }

    protected void Disable()
    {
        CancelInvoke(DISABLE_METHOD_NAME);
        Rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}