using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    /// <summary>
    // This script handles the AR object placement of the application //
    /// </summary>
    /// 
    public GameObject landingAnimationPanel;                                    // Reference to the landing animation panel
    public GameObject objectToPlace;                                            // Reference to the 3D object
    public GameObject placementIndicator;                                       // Reference to the placement indicator
    public ARPlaneManager arPlaneManager;                                       // Reference to the AR plane

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool objectIsPlaced = false;
    private Animator landingAnim;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();                          // Asigning objects
        landingAnim = landingAnimationPanel.GetComponent<Animator>();             // Asigning objects 

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // Touch status check before placement 
        {
            if (objectIsPlaced == false)
            {
                objectIsPlaced = true;
                PlaceObject();
            }
        }
    }

    public void AfterTrackingPlaceObject()
    {
        if (objectIsPlaced == false)
        {
            objectIsPlaced = true;
            PlaceObject();
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arOrigin.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {

        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            if (objectIsPlaced)
            {
                placementIndicator.SetActive(false);
            }
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        // Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        landingAnim.SetTrigger("ScanCompleate");
        objectToPlace.SetActive(true);
        objectToPlace.transform.position = placementPose.position;
        objectToPlace.transform.rotation = placementPose.rotation;

        foreach (var plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        arPlaneManager.enabled = false;
    }


}
