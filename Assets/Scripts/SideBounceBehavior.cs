using System.Collections;
using UnityEngine;

public class SideBounceBehavior : MonoBehaviour {
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
        myLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        myLight.enabled = false;
    }
}