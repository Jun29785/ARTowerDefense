using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = InGameManager.Instance.subTowerCount.ToString();
    }
}