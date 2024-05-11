using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerBehavior : MonoBehaviour {
    public float maxpull = 950.0f;
    public float minpull = 0.0f;
    private Light plungerlight;
    //bool ballready;

    List<Rigidbody> balls;
    [SerializeField] float power;

    private void Awake() {
        plungerlight = GetComponent<Light>();
    }

    void Start() {
        balls = new List<Rigidbody>();
    }

    void Update() {
        if (balls.Count > 0) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                if (power <= maxpull) {
                    power += 625*Time.deltaTime;
                }
            } if (Input.GetKeyUp(KeyCode.LeftShift)) {
                foreach (Rigidbody e in balls) {
                    e.AddForce(power*Vector3.left);
                }
                StartCoroutine(flashlight());
            }
        } else {
            power = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            balls.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            balls.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0.0f;
        }
    }

    IEnumerator flashlight() {
        plungerlight.intensity = 0.0f;
        plungerlight.enabled = true;
        
        for (int i=0; i<6; i++){
            plungerlight.intensity += 0.5f;
            yield return new WaitForSeconds(0.01f);
        }

        for(int i = 0; i < 6; i++){
            plungerlight.intensity -= 0.5f;
            yield return new WaitForSeconds(0.01f);
        }

        plungerlight.enabled = false;
    }
}
