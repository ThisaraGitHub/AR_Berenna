using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationHandler : MonoBehaviour
{
    public GameObject loadingMenu;
    private Animator loadingAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        loadingAnimation = loadingMenu.GetComponent<Animator>();
        float value = PlayerPrefs.GetFloat("backValue");
        if (value == 1)
        {
            loadingAnimation.SetInteger("ComingFromOtherScenes", 1);
        }
        else 
        {

        }
        print("backValue" + value);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        PlayerPrefs.DeleteAll();
    }
}
