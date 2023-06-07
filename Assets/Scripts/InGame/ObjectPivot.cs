using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPivot : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = cameraTransform.position;
    }
}
