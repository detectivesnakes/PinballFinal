using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelBehavior : MonoBehaviour {
    public int game_era; // 0 = past, 1 = present, 2 = future
    [SerializeField] GameObject board_past;
    [SerializeField] GameObject board_present;
    [SerializeField] GameObject board_future;

    void Start() {
        game_era = 1;
        board_past.SetActive(false);
        board_present.SetActive(true);
        board_future.SetActive(false);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) { // past
            if (game_era != 0) {
                game_era = 0;
                board_past.SetActive(true);
                board_present.SetActive(false);
                board_future.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.W)) { // present
            if (game_era != 1) {
                game_era = 1;
                board_past.SetActive(false);
                board_present.SetActive(true);
                board_future.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.E)) { // future
            if (game_era != 2) {
                game_era = 2;
                board_past.SetActive(false);
                board_present.SetActive(false);
                board_future.SetActive(true);
            }
        }
    }
}
