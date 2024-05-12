using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleL : MonoBehaviour
{
    private Vector3 oldpos = new Vector3(-0.044f, -0.191f, -8.787f);
    private Vector3 newpos = new Vector3(0.06f, -0.191f, -8.86f);

    [SerializeField] Renderer ledrender;
    [SerializeField] Material lit_up;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public bool L_PRESSED = false;

    private IEnumerator toggle()
    {
        L_PRESSED = true;
        Debug.Log("Toggled Left!");
        audioSource.PlayOneShot(clip, 0.5f);
        yield return new WaitForSeconds(.5f);
        ledrender.material = lit_up;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (L_PRESSED == false)
            { 
                StartCoroutine(toggle());
            }
        }
    }
}
