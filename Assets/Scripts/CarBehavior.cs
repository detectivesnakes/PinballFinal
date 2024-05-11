using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float travelDistance = 10f;
    [SerializeField] private Vector3 moveDirection = Vector3.right;
    [SerializeField] private float impactForce = 500f;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, startingPosition) < travelDistance)
        {
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = startingPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
                ballRigidbody.AddForce(forceDirection * impactForce, ForceMode.Impulse);
            }
        }
    }
}
