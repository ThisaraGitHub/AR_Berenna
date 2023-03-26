using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkModelClick : MonoBehaviour
{
    public string link;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Application.OpenURL(link);
    }
}
