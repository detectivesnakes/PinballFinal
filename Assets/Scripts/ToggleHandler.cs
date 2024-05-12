using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleHandler : MonoBehaviour {
    [SerializeField] GameObject objtoggleL;
    [SerializeField] GameObject objtoggleR;
    [SerializeField] GameObject movingbumper;
    [SerializeField] GameObject timetravelpad;
    [SerializeField] GameObject guardL;
    [SerializeField] GameObject guardR;
    [SerializeField] GameObject ball;
    private BallBehavior bbh;
    private ToggleL locall;
    private ToggleR localr;

    //private Vector3 lguardpos = new Vector3(3.44f, 0.1f, -3.34f);
    //private Vector3 rguardpos = new Vector3(3.44f, 0.1f, 3.34f);

    private void Start() {
        locall = objtoggleL.GetComponent<ToggleL>();
        localr = objtoggleR.GetComponent<ToggleR>();
        bbh = ball.GetComponent<BallBehavior>();
    }
    private void Update(){
        if (locall.L_PRESSED == true && localr.R_PRESSED == true){
            locall.L_PRESSED = false;
            localr.R_PRESSED = false;
            opengates();
        }
    }

    public void setGuards() {
        guardL.SetActive(false);
        guardR.SetActive(false);
    }

    public void resetGuards() {
        guardL.SetActive(true);
        guardR.SetActive(true);
    }

    private IEnumerator movebumperdown() {
        for (int i = 0; i < 10; i++) {
            movingbumper.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForEndOfFrame();
    }

    private void opengates() {
        bbh.score += 5000;
        Debug.Log("Both toggles active\nTIME MACHINE OPENING");
        timetravelpad.SetActive(true);
        Debug.Log("Time machine OPEN");
        setGuards();
        StartCoroutine(movebumperdown());
    }
}
