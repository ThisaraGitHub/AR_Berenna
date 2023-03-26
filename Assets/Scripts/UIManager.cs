using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject refereshButton;
    public Button locationButton;
    public GameObject informationPanel;
    public GameObject domkiInformationPanel;
    public GameObject loadingPanel;
    public GameObject mapaText;
    public LevelLoader levelLoader;
    public GameObject informationButton;
    public GameObject interactiveObject;
    public GameObject logoInformationPanel;

    public bool isInformationPanelDisabled = false;
    private bool isDOMKIInformationPanelDisabled = false;
    public bool isARMode = false;
    public ClickDetection clickDetection;
    // Start is called before the first frame update
    void Start()
    {
        //  InformativePanelEnabled();
        if (isARMode)
        {

            ARModeEnabled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // print(clickDetection.isLogoInfoPanelEnabled);
    }

    public void InformativePanelEnabled()
    {
        // FindObjectOfType<SoundManager>().Play("Click");
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu() 
    {
        yield return new WaitForSeconds(1);
        refereshButton.SetActive(false);
        locationButton.gameObject.SetActive(true);
        informationPanel.SetActive(true);
        mapaText.SetActive(false);
        isInformationPanelDisabled = true;
    }

    public void ARModeEnabled()
    {
        refereshButton.SetActive(true);
        locationButton.gameObject.SetActive(false);
        informationPanel.SetActive(false);
        mapaText.SetActive(true);
        isInformationPanelDisabled = false;
    }

    public void Enable3DModeInformaitionPanel()
    {
        //FindObjectOfType<SoundManager>().Play("Click");
        domkiInformationPanel.SetActive(true);
        informationButton.SetActive(false);
        interactiveObject.SetActive(false);
        isDOMKIInformationPanelDisabled = true;

        locationButton.gameObject.SetActive(true);
        locationButton.onClick.AddListener(() => { Application.OpenURL("https://www.google.com/maps/place/49%C2%B040'05.5%22N+18%C2%B056'11.2%22E/@49.6681531,18.9353371,373m/data=!3m1!1e3!4m5!3m4!1s0x0:0x7ab8969f3c3e05cc!8m2!3d49.668205!4d18.9364415"); });
    }

    public void Disable3DModeInformaitionPanel()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        domkiInformationPanel.SetActive(false);
        locationButton.gameObject.SetActive(false);
        informationButton.SetActive(true);
        interactiveObject.SetActive(true);
        isDOMKIInformationPanelDisabled = false;
    }

    public void BackButtonHandler(string Mode)
    {
       // FindObjectOfType<SoundManager>().Play("Click");
        if (Mode == "MAPA")
        {
            if (isInformationPanelDisabled == false)
            {


                if (clickDetection.isLogoInfoPanelEnabled == true)
                {
                    logoInformationPanel.SetActive(false);
                    clickDetection.isLogoInfoPanelEnabled = false;
                }
                else
                {
                    loadingPanel.SetActive(true);
                    levelLoader.LoadLevel(0);
                    PlayerPrefs.SetFloat("backValue", 1);
                }
            }
            else
            {
                ARModeEnabled();
            }


            //if (clickDetection.isLogoInfoPanelEnabled == true)
            //{
            //    print(clickDetection.isLogoInfoPanelEnabled);
            //    logoInformationPanel.SetActive(false);
            //}
        }


        if (Mode == "DOMKI")
        {
            if (isDOMKIInformationPanelDisabled == false)
            {
                loadingPanel.SetActive(true);
                levelLoader.LoadLevel(0);
                PlayerPrefs.SetFloat("backValue", 1);
            }
            else
            {
                Disable3DModeInformaitionPanel();
            }
        }

    }
}
