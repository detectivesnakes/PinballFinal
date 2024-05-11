using UnityEngine;

public class MinionBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 20.0f;
    public float pushForce = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Entity"))
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                collision.rigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

}
