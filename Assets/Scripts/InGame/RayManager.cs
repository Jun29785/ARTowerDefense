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

    void Start()
    {
        main = Camera.main;
    }

    void Update()
    {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            //Vector2 screenCenterPos = main.ViewportToScreenPoint(touch.position);
            if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                if (hits.Count > 0)
                {
                    if (!InGameManager.Instance.canvas.coreBuild.gameObject.activeSelf && !InGameManager.Instance.isCoreBuild)
                    {
                        InGameManager.Instance.canvas.coreBuild.ActiveWindow(hits[0].pose.position);
                    }
                    else if (!InGameManager.Instance.isWave && InGameManager.Instance.isCoreBuild)
                    {

                    }
                }
            }

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
                        if (hit.collider.CompareTag("Enemy") && InGameManager.Instance.isWave)
                        {
                            //temptext.text = $"Name : {hit.transform.name}";
                            hit.transform.TryGetComponent(out EnemyObject enemy);
                            enemy.hitEvent.Invoke();
                        }
                        else if (hit.collider.CompareTag("Core") && !InGameManager.Instance.isWave)
                        {
                            // Open Core Tower Upgrade Menu
                            
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
