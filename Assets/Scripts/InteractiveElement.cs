using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveElement : MonoBehaviour
{
    [Header("--Balls Colors--")]
    public Color normalColor;
    public Color alphaColor;

    [Header("--Balls References--")]
    public Renderer ballMesh1;
    public Renderer ballMesh2;
    public Renderer ballMesh3;
    public Renderer ballMesh4;
    public Renderer ballMesh5;
    public Renderer ballMesh6;

    public enum ElementNumber { Number1, Number2, Number3, Number4, Number5, Number6 }
    [Header("--Element Number--")]
    public ElementNumber elementNumber;
    public GameObject canvas;
    public MeshRenderer mesh;

    [Header("--Descriptive Menu--")]
    public GameObject descriptiveMenu;
    public Text IEtittle;
    public Text IEdescription;
    public string tittle;
    public string description;

    [Header("--JSON TEXT References--")]
    public TextAsset textJSON;

    [Header("--Other References--")]
    public Slider timeSlider;
    public GameObject interactiveObject;
    private Animator interactiveObjAnim;
    public float waitTime = 5;
    public bool IscountdownBegun = false;
    public Button moreInfoButton;

    //[System.Serializable]
    //public class LocationDetails
    //{
    //    public string tittle;
    //    public string description;
    //}

    //[System.Serializable]
    //public class LocationList
    //{
    //    public LocationDetails[] locationDetails;
    //}
    //private LocationList myLocationList = new LocationList();
    // Start is called before the first frame update
    void Start()
    {
        //myLocationList = JsonUtility.FromJson<LocationList>(textJSON.text);
        canvas.SetActive(false);
        interactiveObjAnim = interactiveObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IscountdownBegun)
        {
            if (waitTime > 0)
            {
                waitTime -= 1f * Time.deltaTime;
                timeSlider.value = waitTime;
            }

        }
    }

    void OnMouseDown()
    {
        moreInfoButton.interactable = false;
        switch (elementNumber)
        {
            case ElementNumber.Number1:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = normalColor;
                ballMesh2.material.color = alphaColor;
                ballMesh3.material.color = alphaColor;
                ballMesh4.material.color = alphaColor;
                ballMesh5.material.color = alphaColor;
                ballMesh6.material.color = alphaColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = true;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(EnableMesh());
                break;
            case ElementNumber.Number2:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = alphaColor;
                ballMesh2.material.color = normalColor;
                ballMesh3.material.color = alphaColor;
                ballMesh4.material.color = alphaColor;
                ballMesh5.material.color = alphaColor;
                ballMesh6.material.color = alphaColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = true;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(EnableMesh());
                break;
            case ElementNumber.Number3:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = alphaColor;
                ballMesh2.material.color = alphaColor;
                ballMesh3.material.color = normalColor;
                ballMesh4.material.color = alphaColor;
                ballMesh5.material.color = alphaColor;
                ballMesh6.material.color = alphaColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = true;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(EnableMesh());
                break;
            case ElementNumber.Number4:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = alphaColor;
                ballMesh2.material.color = alphaColor;
                ballMesh3.material.color = alphaColor;
                ballMesh4.material.color = normalColor;
                ballMesh5.material.color = alphaColor;
                ballMesh6.material.color = alphaColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = true;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(EnableMesh());
                break;
            case ElementNumber.Number5:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = alphaColor;
                ballMesh2.material.color = alphaColor;
                ballMesh3.material.color = alphaColor;
                ballMesh4.material.color = alphaColor;
                ballMesh5.material.color = normalColor;
                ballMesh6.material.color = alphaColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = true;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = false;
                StartCoroutine(EnableMesh());
                break;
            case ElementNumber.Number6:
                print(name);
                IscountdownBegun = true;
                //   canvas.SetActive(true);
                //mesh.enabled = false;
                descriptiveMenu.SetActive(true);
                IEtittle.text = tittle; //myLocationList.locationDetails[11].tittle;
                IEdescription.text = description; //myLocationList.locationDetails[11].description;
                interactiveObjAnim.SetInteger("Clicked", 1);
                ballMesh1.material.color = alphaColor;
                ballMesh2.material.color = alphaColor;
                ballMesh3.material.color = alphaColor;
                ballMesh4.material.color = alphaColor;
                ballMesh5.material.color = alphaColor;
                ballMesh6.material.color = normalColor;

                ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = false;
                ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = true;
                StartCoroutine(EnableMesh());
                break;
        }
    }

    IEnumerator EnableMesh()
    {
        yield return new WaitForSeconds(5);
        moreInfoButton.interactable = true;
        interactiveObjAnim.SetInteger("Clicked", 0);
        IscountdownBegun = false;
        canvas.SetActive(false);
        descriptiveMenu.SetActive(false);
        mesh.enabled = true;
        waitTime = 5;

        ballMesh1.material.color = normalColor;
        ballMesh2.material.color = normalColor;
        ballMesh3.material.color = normalColor;
        ballMesh4.material.color = normalColor;
        ballMesh5.material.color = normalColor;
        ballMesh6.material.color = normalColor;

        ballMesh1.gameObject.GetComponent<SphereCollider>().enabled = true;
        ballMesh2.gameObject.GetComponent<SphereCollider>().enabled = true;
        ballMesh3.gameObject.GetComponent<SphereCollider>().enabled = true;
        ballMesh4.gameObject.GetComponent<SphereCollider>().enabled = true;
        ballMesh5.gameObject.GetComponent<SphereCollider>().enabled = true;
        ballMesh6.gameObject.GetComponent<SphereCollider>().enabled = true;

    }
}
