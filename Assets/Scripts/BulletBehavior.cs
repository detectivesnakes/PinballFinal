using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void initialize(Vector3 targetPosition)
    {
        Vector3 firingDirection = (targetPosition - transform.position).normalized;
        rb.velocity = firingDirection * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Entity"))
            Destroy(gameObject);
    }
}
