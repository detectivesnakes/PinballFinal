using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadBehavior : MonoBehaviour
{
    [SerializeField] GameObject holder;
    private TimeTravelBehavior referee;

    private void Start()
    {
        referee = holder.GetComponent<TimeTravelBehavior>();
    }

    private void Update()
    {
        // hello
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("WARPING");
            if (referee.game_era == 0)
            { // past
                referee.gotopast();
            }
            else if (referee.game_era == 1)
            {
                referee.gotopresent();
            } else if (referee.game_era == 2 && referee.changed_future == false)
            {
                referee.gotobadf();
            } else if (referee.game_era == 2 && referee.changed_future == true)
            {
                referee.gotogoodf();
            }
        }
        gameObject.SetActive(false);
    }
}