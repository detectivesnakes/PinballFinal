using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleR : MonoBehaviour
{
    private Vector3 oldpos = new Vector3(-0.024f, -0.191f, -1.226f);
    private Vector3 newpos = new Vector3(0.09f, -0.191f, -1.15f);

    [SerializeField] Renderer ledrender;
    [SerializeField] Material lit_up;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public bool R_PRESSED = false;
    private IEnumerator toggle()
    {
        R_PRESSED = true;
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
            if (R_PRESSED == false)
            {
                StartCoroutine(toggle());
            }
        }
    }
}
