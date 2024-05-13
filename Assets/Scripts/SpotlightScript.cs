using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour {
    [SerializeField] Light gamespotlight;

    private float min = 2.1f;
    private float max = 2.4f;

    private float last = 0;
    private int round = 45;
    Queue<float> rounding;

    public void Reset() {
        rounding.Clear();
        last = 0;
    }

    void Start() {
        rounding = new Queue<float>(round);
        if (gamespotlight == null) {
            gamespotlight = GetComponent<Light>();
        }
    }

    void Update() {
        if (gamespotlight == null) return;

        while (rounding.Count >= round) {
            last -= rounding.Dequeue();
        }

        float temps = Random.Range(min, max);
        rounding.Enqueue(temps);
        last += temps;
        gamespotlight.intensity = last / (float)rounding.Count;
    }
}
