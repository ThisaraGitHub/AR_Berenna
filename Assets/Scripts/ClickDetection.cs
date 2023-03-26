using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    public enum Locations { Location1, Location2, Location3, Location4, Location5, Location6, Location7, Location8, Location9, Location10, Location11, Logo }
    [Header("--Locations Number References--")]
    public Locations mapLocationNumber;

    [Header("--JSON TEXT References--")]
    public TextAsset textJSON;

    [Header("--Info Panel Tittle Color References--")]
    public Color blackColor;
    public Color whiteColor;

    [Header("--UI References--")]
    public Text tittleUIText;
    public Image descriptionUIImage;
    public Text descriptionUIText;
    public Button locationButton;

    [Header("--Relavent Informations--")]
    public Sprite image;
    public string link;

    [Header("--Other--")]
    public GameObject informativePanel;
    public UIManager uiManager;
    public GameObject logoInfoPanel;
    public GameObject refreshButton;
    public bool isLogoInfoPanelEnabled = false;




    [System.Serializable]
    public class LocationDetails
    {
        public string tittle;
        public string description;
    }

    [System.Serializable]
    public class LocationList
    {
        public LocationDetails[] locationDetails;
    }

    private LocationList myLocationList = new LocationList();

    // Start is called before the first frame update
    void Start()
    {
        myLocationList = JsonUtility.FromJson<LocationList>(textJSON.text);
    }

    // Update is called once per frame
    void Update()
    {
        // print("--------" + mapLocationNumber);
    }
    void OnMouseDown()
    {
        switch (mapLocationNumber)
        {
            case Locations.Location1:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location1");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[0].tittle;
                descriptionUIText.text = myLocationList.locationDetails[0].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location2:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location2");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[1].tittle;
                descriptionUIText.text = myLocationList.locationDetails[1].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location3:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location3");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[2].tittle;
                descriptionUIText.text = myLocationList.locationDetails[2].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location4:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location4");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[3].tittle;
                descriptionUIText.text = myLocationList.locationDetails[3].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location5:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location5");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[4].tittle;
                descriptionUIText.text = myLocationList.locationDetails[4].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location6:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location6");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[5].tittle;
                descriptionUIText.text = myLocationList.locationDetails[5].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location7:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location7");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[6].tittle;
                descriptionUIText.text = myLocationList.locationDetails[6].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location8:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location8");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[7].tittle;
                descriptionUIText.text = myLocationList.locationDetails[7].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location9:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location9");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[8].tittle;
                descriptionUIText.text = myLocationList.locationDetails[8].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location10:
                uiManager.InformativePanelEnabled();
                Debug.Log("Location10");
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[9].tittle;
                descriptionUIText.text = myLocationList.locationDetails[9].description;
                tittleUIText.color = whiteColor;
                break;
            case Locations.Location11:
                uiManager.InformativePanelEnabled();
                AsignDetails();
                tittleUIText.text = myLocationList.locationDetails[10].tittle;
                descriptionUIText.text = myLocationList.locationDetails[10].description;
                tittleUIText.color = whiteColor;
                Debug.Log("Location11");
                break;
            case Locations.Logo:
                ActivateLogoInfoPanel();
                Debug.Log("Location11");
                break;


        }
    }

    public void ActivateLogoInfoPanel()
    {
        // FindObjectOfType<SoundManager>().Play("Click");
        StartCoroutine(LoadLogoMenu());
        // print("--------"+ isLogoInfoPanelEnabled);
    }

    IEnumerator LoadLogoMenu()
    {
        yield return new WaitForSeconds(1);
        isLogoInfoPanelEnabled = true;
        logoInfoPanel.SetActive(true);
        refreshButton.SetActive(false);
        locationButton.gameObject.SetActive(true);
        locationButton.onClick.AddListener(() => { Application.OpenURL("https://www.google.com/maps/place/49%C2%B040'05.5%22N+18%C2%B056'11.2%22E/@49.6681531,18.9353371,373m/data=!3m1!1e3!4m5!3m4!1s0x0:0x7ab8969f3c3e05cc!8m2!3d49.668205!4d18.9364415"); });
    }

    public void AsignDetails()
    {
        descriptionUIImage.GetComponent<Image>().sprite = image;
        locationButton.onClick.AddListener(() => { Application.OpenURL(link); });

        tittleUIText.text = myLocationList.locationDetails[10].tittle;
        descriptionUIText.text = myLocationList.locationDetails[10].description;
    }
}
