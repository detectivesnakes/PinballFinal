using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {
    [SerializeField] AudioClip deathsound;
    [SerializeField] AudioClip primesound;

    Vector3 spawn = new Vector3(8.00f, 0.3f, 5.05f);
    public AudioSource ambience;
    public float sfxvol = 0.18f;
    public int score = 0;

    private bool isStunned = false;
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Death")) {
            score = 0;
            StartCoroutine(DeathDelay());
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

    private IEnumerator DeathDelay(){
        Debug.Log("You Died!");
        ambience.PlayOneShot(deathsound, sfxvol);
        yield return new WaitForSeconds(2.4f);

        Debug.Log("Respawning");
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.SetPositionAndRotation(spawn, Quaternion.identity);
        //yield return new WaitForSeconds(0.2f);
        ambience.PlayOneShot(primesound, sfxvol);
    }

    public bool IsStunned { get { return isStunned; } }
}
