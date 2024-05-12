using System.Collections;
using UnityEngine;

public class SideBounceBehavior : MonoBehaviour {
    [SerializeField] AudioSource newsource;
    [SerializeField] AudioClip bounce;
    private Light myLight;

    private void Awake() {
        myLight = GetComponent<Light>();
    }

    private void OnCollisionEnter(Collision touch) {
        if (touch.gameObject.CompareTag("Ball")) {
            StartCoroutine(bounceBehavior());
        }
    }
    IEnumerator bounceBehavior() {
        newsource.PlayOneShot(bounce, 0.45f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        myLight.enabled = false;
    }
}