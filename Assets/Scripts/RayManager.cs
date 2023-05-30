using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class RayManager : MonoBehaviour
{
    public ARRaycastManager arRaycastManager = null;
    public ARPlaneManager arPlaneManager = null;

    Camera main;
    public Vector2 centerPos = new Vector2(.5f, .5f);
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public TextMeshProUGUI temptext;
    void Start()
    {
        main = Camera.main;
    }

    void Update()
    {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 screenCenterPos = main.ViewportToScreenPoint(touch.position);
            if (arRaycastManager.Raycast(screenCenterPos, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                if (hits.Count > 0)
                {
                    // compare object
                    Debug.Log($"{hits[0].trackable}");
                    temptext.text = $"{hits[0].trackable}\n{hits[0].pose.position}\n{transform.position}";
                }
            }
        }
    }
}
