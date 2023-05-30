using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI originTMP;
    [SerializeField] private TextMeshProUGUI cameraTMP;

    [SerializeField] private Transform originPosition;
    [SerializeField] private Transform cameraPosition;

    private void Awake()
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
        originTMP.text = originPosition.position.ToString();
        cameraTMP.text = cameraPosition.position.ToString();
    }

    
}
