using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoInteractionDetection : MonoBehaviour
{
    public GameObject logoObject;
    private Animator logoAnim;
    public Light light;
    public GameObject[] triggers;
    // Start is called before the first frame update
    void Start()
    {
        logoAnim = logoObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        logoAnim.SetInteger("Clicked", 1);
        light.enabled = true;
        DisableTriggerInteractions();

        var material = logoObject.GetComponent<Renderer>().material;
        material.DisableKeyword("_EMISSION");
        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        material.SetColor("_EmissionColor", Color.white);

        StartCoroutine(StopAnimation());
    }

    public void EnableTriggerInteractions()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void DisableTriggerInteractions()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1);
        light.enabled = false;
        logoAnim.SetInteger("Clicked", 0);
     //   EnableTriggerInteractions();

        var material = logoObject.GetComponent<Renderer>().material;
        material.DisableKeyword("_EMISSION");
        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        material.SetColor("_EmissionColor", Color.black);
    }
}
