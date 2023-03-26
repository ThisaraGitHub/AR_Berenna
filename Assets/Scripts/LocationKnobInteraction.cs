using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationKnobInteraction : MonoBehaviour
{

    //[Header("--Knob Colors--")]
    //public Color normalColor;
    //public Color selectedColor;
    public GameObject[] knobTriggers;
    public GameObject knobMesh;
    public Light light;

    public GameObject interactiveObject;
    private Animator interactiveObjAnim;
    // Start is called before the first frame update
    void Start()
    {
        interactiveObjAnim = interactiveObject.GetComponent<Animator>();
        //  knobMesh.material.color = normalColor;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        DisableTriggerLocationInteractions();

        interactiveObjAnim.SetInteger("Clicked", 1);
        // knobMesh.material.color = selectedColor;
        light.enabled = true;
        var material = knobMesh.GetComponent<Renderer>().material;
        material.EnableKeyword("_EMISSION");
        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        material.SetColor("_EmissionColor", Color.red * 5);

        StartCoroutine(StopAnimation());


    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1);
        light.enabled = false;
        //   knobMesh.material.color = normalColor;
        interactiveObjAnim.SetInteger("Clicked", 2);

        var material = knobMesh.GetComponent<Renderer>().material;
        material.DisableKeyword("_EMISSION");
        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        material.SetColor("_EmissionColor", Color.black);

    }

    public void EnableTriggerLocationInteractions()
    {
        for (int i = 0; i < knobTriggers.Length; i++)
        {
            knobTriggers[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void DisableTriggerLocationInteractions()
    {
        for (int i = 0; i < knobTriggers.Length; i++)
        {
            knobTriggers[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
