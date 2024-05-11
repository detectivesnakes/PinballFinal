using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StunBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;
     private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Destroy(gameObject, 2f);
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Entity"))
        {
            if (collision.gameObject.CompareTag("Ball"))
                {
                BallBehavior ballBehavior = collision.gameObject.GetComponent<BallBehavior>();
                ballBehavior.Stun(2.0f);
            }
                Destroy(gameObject);
        }
    }
}
