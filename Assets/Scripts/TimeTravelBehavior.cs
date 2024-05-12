using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

// Jack's Awful Script

public class TimeTravelBehavior : MonoBehaviour {
    public int game_era = 1;        // 0 = past, 1 = present, 2 = future
    public bool changed_future = false; // determines future board used
    [SerializeField] GameObject board_past;
    [SerializeField] GameObject board_present;
    [SerializeField] GameObject board_future;
    [SerializeField] GameObject good_future;

    [SerializeField] GameObject past_objects;
    [SerializeField] GameObject present_objects;
    [SerializeField] GameObject future_objects;
    [SerializeField] GameObject goodfuture_objects;

    [SerializeField] GameObject travel_pad;
    [SerializeField] TMP_Text eratext;

    void Start() {
        game_era = 1;
        board_past.SetActive(false);
        board_present.SetActive(true);
        board_future.SetActive(false);
        good_future.SetActive(false);

        past_objects.SetActive(false);
        present_objects.SetActive(true);
        future_objects.SetActive(false);
        goodfuture_objects.SetActive(false);
    }

    public void gotopast() {
        board_past.SetActive(true);
        board_present.SetActive(false);
        board_future.SetActive(false);
        good_future.SetActive(false);

        past_objects.SetActive(true);
        present_objects.SetActive(false);
        future_objects.SetActive(false);
        goodfuture_objects.SetActive(false);
    }
    public void gotopresent() {
        board_past.SetActive(false);
        board_present.SetActive(true);
        board_future.SetActive(false);
        good_future.SetActive(false);

        past_objects.SetActive(false);
        present_objects.SetActive(true);
        future_objects.SetActive(false);
        goodfuture_objects.SetActive(false);
    }
    public void gotobadf(){
        board_past.SetActive(false);
        board_present.SetActive(false);
        board_future.SetActive(true);
        good_future.SetActive(false);

        past_objects.SetActive(false);
        present_objects.SetActive(false);
        future_objects.SetActive(true);
        goodfuture_objects.SetActive(false);
    }
    public void gotogoodf(){
        board_past.SetActive(false);
        board_present.SetActive(false);
        board_future.SetActive(false);
        good_future.SetActive(true);

        past_objects.SetActive(false);
        present_objects.SetActive(false);
        future_objects.SetActive(false);
        goodfuture_objects.SetActive(true);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) { // past
            if (game_era != 0) {
                game_era = 0;
                Debug.Log("PAST");
                eratext.text = "Target: Past";
            }
        }

        /*if (Input.GetKey(KeyCode.W)) { // present
            if (game_era != 1) {
                game_era = 1;
                Debug.Log("PRESENT");
                eratext.text = "Present";
            }
        }*/

        if (Input.GetKey(KeyCode.E)) { // future
            if (game_era != 2) {
                game_era = 2;
                eratext.text = "Target: Future";
            }
        }
    }
}
