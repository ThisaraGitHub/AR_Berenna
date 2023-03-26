using ARSupportCheck;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ARSupport : MonoBehaviour
{
    // This script use to check the AR compatibility. Based on the compatibility diffrent scene will load when AR button clicks
    // Used AR Support Checker plugin for check the compatibility. Located under plugins folder

    public Button arButton;
    public LevelLoader levelLoader;
    public GameObject levelLoadingPanel;

    // Start is called before the first frame update
    void Start()
    {
        arButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (ARSupportChecker.IsSupported())
            {
                levelLoader.LoadLevel(1);
                levelLoadingPanel.SetActive(true);
                //debugText.text = "Supported".ToString();
            }
            else
            {
                levelLoader.LoadLevel(3);
                levelLoadingPanel.SetActive(true);
                //debugText.text = "Unsupported".ToString();
            }
        });
    }
}
