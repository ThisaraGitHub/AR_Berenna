using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float percentThreshold = 0.2f;
    public Color selectedColor;
    public Color unSelectedColor;
    public Image dotImage1;
    public Image dotImage2;
    public Image dotImage3;
    public Image dotImage4;
    public Image dotImage5;


    private Vector3 panelLocation;
    public float easing = 0.5f;
    public int totalPages = 1;
    private int currentPage = 1;


    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    private void Update()
    {
        print(currentPage);
        switch (currentPage)
        {
            case 1:
                dotImage1.color = selectedColor;
                dotImage2.color = unSelectedColor;
                dotImage3.color = unSelectedColor;
                dotImage4.color = unSelectedColor;
                dotImage5.color = unSelectedColor;
                break;
            case 2:
                dotImage1.color = unSelectedColor;
                dotImage2.color = selectedColor;
                dotImage3.color = unSelectedColor;
                dotImage4.color = unSelectedColor;
                dotImage5.color = unSelectedColor;
                break;
            case 3:
                dotImage1.color = unSelectedColor;
                dotImage2.color = unSelectedColor;
                dotImage3.color = selectedColor;
                dotImage4.color = unSelectedColor;
                dotImage5.color = unSelectedColor;
                break;
            case 4:
                dotImage1.color = unSelectedColor;
                dotImage2.color = unSelectedColor;
                dotImage3.color = unSelectedColor;
                dotImage4.color = selectedColor;
                dotImage5.color = unSelectedColor;
                break;
            case 5:
                dotImage1.color = unSelectedColor;
                dotImage2.color = unSelectedColor;
                dotImage3.color = unSelectedColor;
                dotImage4.color = unSelectedColor;
                dotImage5.color = selectedColor;
                break;
        }
    }


    public void OnDrag(PointerEventData data)
    {
        
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
                FindObjectOfType<SoundManager>().Play("Click");
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
                FindObjectOfType<SoundManager>().Play("Click");
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
