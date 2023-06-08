using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveButton : MonoBehaviour
{
    public void NextWaveActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void ClickButton()
    {
        NextWaveActive(false);
        InGameManager.Instance.nextWave.Invoke();
    }
}
