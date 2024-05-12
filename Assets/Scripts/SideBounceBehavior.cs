using System.Collections;
using TMPro;
using UnityEngine;

public class SideBounceBehavior : MonoBehaviour {
    [SerializeField] AudioSource newsource;
    [SerializeField] AudioClip bounce;
    [SerializeField] GameObject theball;
    private BallBehavior bbeh;
    private Light myLight;

    private void Awake() {
        myLight = GetComponent<Light>();
        bbeh = theball.GetComponent<BallBehavior>();
    }

    private void OnCollisionEnter(Collision touch) {
        if (touch.gameObject.CompareTag("Ball")) {
            bbeh.score += 500;
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