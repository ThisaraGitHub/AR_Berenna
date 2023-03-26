using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    public float rotateSpeed = 0.5f;
    public GameObject landingAnimationPanel;
    public bool IsNoARScene = false;

    private Animator landingAnim;

    private void Start()
    {
        landingAnim = landingAnimationPanel.GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsNoARScene)
        {
            if (Input.GetMouseButtonDown(0))
            {

                DisableScanningPanel();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                DisableScanningPanel();
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotateSpeed, 0f);
                    transform.rotation = rotationY * transform.rotation;
                }

            }
        }

    }
    public void DisableScanningPanel()
    {
        landingAnim.SetTrigger("ScanCompleate");
    }
}