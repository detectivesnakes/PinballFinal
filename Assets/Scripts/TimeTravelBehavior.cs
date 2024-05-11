using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jack's Awful Script

public class TimeTravelBehavior : MonoBehaviour {
    public int game_era = 1;        // 0 = past, 1 = present, 2 = future
    public bool changed_future = false; // determines future board used
    [SerializeField] GameObject board_past;
    [SerializeField] GameObject board_present;
    [SerializeField] GameObject board_future;
    [SerializeField] GameObject good_future;

    [SerializeField] GameObject Soldier0;
    [SerializeField] GameObject Soldier1;
    [SerializeField] GameObject Space0;
    [SerializeField] GameObject Space1;

    void Start() {
        game_era = 1;
        board_past.SetActive(false);
        board_present.SetActive(true);
        board_future.SetActive(false);
        good_future.SetActive(false);

        Soldier0.SetActive(false);
        Soldier1.SetActive(false);
        Space0.SetActive(false);
        Space1.SetActive(false);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Q)) { // past
            if (game_era != 0) {
                game_era = 0;
                board_past.SetActive(true);
                board_present.SetActive(false);
                board_future.SetActive(false);
                good_future.SetActive(false);

                Soldier0.SetActive(false);
                Soldier1.SetActive(false);
                Space0.SetActive(false);
                Space1.SetActive(false);
                Debug.Log("PAST");
            }
        }

        if (Input.GetKey(KeyCode.W)) { // present
            if (game_era != 1) {
                game_era = 1;
                board_past.SetActive(false);
                board_present.SetActive(true);
                board_future.SetActive(false);
                good_future.SetActive(false);

                Soldier0.SetActive(false);
                Soldier1.SetActive(false);
                Space0.SetActive(false);
                Space1.SetActive(false);
                Debug.Log("PRESENT");
            }
        }

        if (Input.GetKey(KeyCode.E)) { // future
            if (game_era != 2) {
                game_era = 2;
                board_past.SetActive(false);
                board_present.SetActive(false);
                if (changed_future == false) {
                    board_future.SetActive(true);
                    good_future.SetActive(false);

                    Soldier0.SetActive(true);
                    Soldier1.SetActive(true);
                    Space0.SetActive(true);
                    Space1.SetActive(true);
                    Debug.Log("BAD FUTURE");
                } else {
                    board_future.SetActive(false);
                    good_future.SetActive(true);

                    Soldier0.SetActive(false);
                    Soldier1.SetActive(false);
                    Space0.SetActive(false);
                    Space1.SetActive(false);
                    Debug.Log("GOOD FUTURE");
                }
            }
        }
    }
}
