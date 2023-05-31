using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;  
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
            //Vector2 screenCenterPos = main.ViewportToScreenPoint(touch.position);
            //if (arRaycastManager.Raycast(screenCenterPos, hits, TrackableType.PlaneWithinPolygon))
            //{
            //    if (hits.Count > 0)
            //    {
            //        // compare object
            //        Debug.Log($"{hits[0].trackable}");
            //        temptext.text = $"{hits[0].trackable}\n{hits[0].pose.position}\n{transform.position}\nName:{hits[0].trackable.name}";
            //    }
            //}

            Vector3 touchPos;
            Ray ray;
            RaycastHit hit;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector3 touchPosToVector3 = new Vector3(touch.position.x, touch.position.y, 100);
                    touchPos = Camera.main.ScreenToWorldPoint(touchPosToVector3);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector3);

                    if (Physics.Raycast(ray,out hit, 100))
                    {
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            temptext.text = $"Name : {hit.transform.name}";
                            hit.transform.TryGetComponent(out EnemyObject enemy);
                            enemy.hitEvent.Invoke();
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }
    }
}