using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHandler : MonoBehaviour {
    [SerializeField] GameObject objtoggleL;
    [SerializeField] GameObject objtoggleR;
    [SerializeField] GameObject movingbumper;
    [SerializeField] GameObject timetravelpad;
    private ToggleL locall;
    private ToggleR localr;

    private void Start() {
        locall = objtoggleL.GetComponent<ToggleL>();
        localr = objtoggleR.GetComponent<ToggleR>();
    }
    private void Update(){
        if (locall.L_PRESSED == true && localr.R_PRESSED == true){
            locall.L_PRESSED = false;
            localr.R_PRESSED = false;
            opengates();
        }
    }

    private IEnumerator movebumperdown() {
        for (int i = 0; i < 10; i++) {
            movingbumper.transform.position -= new Vector3(0, 0.2f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void opengates() {
        Debug.Log("Both toggles active\nTIME MACHINE OPENING");
        StartCoroutine(movebumperdown());
        timetravelpad.SetActive(true);
    }
}
