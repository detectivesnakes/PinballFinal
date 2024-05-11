using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehavior : MonoBehaviour {

    [SerializeField] AudioSource mysource;
    [SerializeField] AudioClip flippernoise;

    public float idlea = 0f;
    public float press = 45f;
    public float power = 10200f;
    public float dampr = 0f;

    public string uinput;
    public string dinput;
    HingeJoint hinge;

    void Start() {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    private void Update() {
        JointSpring spring = new JointSpring();
        spring.spring = power;

        if (Input.GetAxis(uinput) == 1 || Input.GetAxis(dinput) == 1) {
            mysource.PlayOneShot(flippernoise, 0.01f);
            spring.targetPosition = press;
        } else {
            spring.targetPosition = idlea;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
