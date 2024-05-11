using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {
    Vector3 spawn = new Vector3(8.00f, 0.3f, 5.05f);
    private bool isStunned = false;
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Death")) {
            Debug.Log("You Died");
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.SetPositionAndRotation(spawn, Quaternion.identity);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Stun(float duration)
    {
        if (!isStunned)
        {
            StartCoroutine(StunRoutine(duration));
        }
    }

    private IEnumerator StunRoutine(float duration)
    {
        isStunned = true;
        Vector3 currentVelocity = rb.velocity;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        yield return new WaitForSeconds(duration);

        rb.isKinematic = false;
        rb.velocity = currentVelocity;
        isStunned = false;
    }

    public bool IsStunned { get { return isStunned; } }
}
