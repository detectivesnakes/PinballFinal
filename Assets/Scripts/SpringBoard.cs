using UnityEngine;

public class Springboard : MonoBehaviour
{
    [SerializeField] private float forceMagnitude = 1500f;  // Adjust the force magnitude as needed
    [SerializeField] private Vector3 forceDirection = Vector3.up;  // Default direction is upward

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))  // Ensure your ball has the tag "Ball"
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                // Apply the force
                ballRigidbody.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
