using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaunchArrowScript : MonoBehaviour
{
    private float delay = 0.1f;
    [SerializeField] GameObject arrow0;
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;

    private void Awake()
    {
        arrow0.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("High Speed Launch");
            StartCoroutine(waitforme());
        }

        arrow0.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
    }

    IEnumerator waitforme()
    {
        for (int i = 0; i < 3; i++)
        {
            arrow2.SetActive(false);
            arrow0.SetActive(true);
            yield return new WaitForSeconds(delay);

            arrow0.SetActive(false);
            arrow1.SetActive(true);
            yield return new WaitForSeconds(delay);

            arrow1.SetActive(false);
            arrow2.SetActive(true);
            yield return new WaitForSeconds(delay);
            
            if (i == 2)
            {
                arrow0.SetActive(false);
                arrow1.SetActive(false);
                arrow2.SetActive(false);
                yield break;
            }
        }
    }
}
