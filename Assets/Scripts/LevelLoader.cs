using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    /// <summary>
    // This script handles the level loading //
    /// </summary>
    public GameObject animationPannel;
    public Slider slider;                                    // Reference to the UI loading slider
                                                             // public Text progressText;                                // Reference to the progress text
    private Animator anim;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        anim = animationPannel.GetComponent<Animator>();
    }
    public void LoadLevel(int sceneIndex)                    // A public method to call when a level needs to load
    {
        slider.gameObject.SetActive(true);
        anim.SetTrigger("PlayLodingAnim");
        
        StartCoroutine(LoadAsynchronously(sceneIndex));
        FindObjectOfType<SoundManager>().Play("Click");
    }

    IEnumerator LoadAsynchronously(int sceneIndex)           // Handeling async opration when loading the scene
    {
        AsyncOperation oparation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!oparation.isDone)
        {
            float progress = Mathf.Clamp01(oparation.progress / 0.9f);
            slider.value = progress;
            //   progressText.text = $"{progress * 100f}%";
            yield return null;
        }
    }

    public void LoadError()                                   // Play error sound if there is no scene to load
    {
        //FindObjectOfType<SoundManager>().Play("Error");
    }
}
