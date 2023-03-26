using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAT : MonoBehaviour
{
    //public Transform _Camera;

    public GameObject target;

    // Update is called once per frame
    void Update()
    {

        //transform.LookAt(_Camera);
        //transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.right);

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);

    }
}
