using UnityEngine;

public class ZeroGravityBehavior : MonoBehaviour
{
    public float hoverDuration = 3.0f;
    public float hoverHeight = 0.5f;
    public float downwardSpeed = 0.1f;
    public float slowDownFactor = 0.5f;

    private bool isHovering = false;
    private float hoverTimer = 0.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                startHover(rb);
            }
        }
    }

    void Update()
    {
        if (isHovering && hoverTimer > 0)
        {
            hoverTimer -= Time.deltaTime;
            if (hoverTimer <= 0)
            {
                endHover();
            }
        }
    }

    private void startHover(Rigidbody ballRB)
    {
        isHovering = true;
        hoverTimer = hoverDuration;

        ballRB.useGravity = false;
        ballRB.velocity = ballRB.velocity * slowDownFactor;

        ballRB.velocity = new Vector3(ballRB.velocity.x, downwardSpeed, ballRB.velocity.z);
    }

    private void endHover()
    {
        GameObject[] pinballs = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var pinball in pinballs)
        {
            Rigidbody rb = pinball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
        isHovering = false;
    }
}
