using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBuild : MonoBehaviour
{
    public Vector3 corePosition;

    public void ActiveWindow(Vector3 position)
    {
        corePosition = position;
        gameObject.SetActive(true);
    }

    public void ButtonYesClick()
    {
        InGameManager.Instance.CoreBuild(corePosition);
        gameObject.SetActive(false);
    }

    public void ButtonNoClick()
    {
        gameObject.SetActive(false);
    }
}
