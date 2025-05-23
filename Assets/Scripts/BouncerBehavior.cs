using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerBehavior : MonoBehaviour {
    [SerializeField] Vector3 newscale = new Vector3(1.6f, 1.6f, 1.45f);
    [SerializeField] Vector3 oldscale = new Vector3(1.6f, 1.6f, 1.6f);
    [SerializeField] AudioSource soundsource;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject theball;
    private BallBehavior bbeh;
    private Light myLight;

    private void Awake() {
        myLight = GetComponent<Light>();
        bbeh = theball.GetComponent<BallBehavior>();
    }

    private void OnCollisionEnter(Collision touch) {
        if (touch.gameObject.CompareTag("Ball")) {
            bbeh.score += 1500;
            StartCoroutine(bounceBehavior());
        }
    }
    IEnumerator bounceBehavior() {
        soundsource.PlayOneShot(clip, 0.5f);
        transform.localScale = newscale;
        myLight.enabled = true;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = oldscale;
        myLight.enabled = false;
    }
}