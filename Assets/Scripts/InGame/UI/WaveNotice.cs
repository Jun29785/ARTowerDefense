using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveNotice : MonoBehaviour
{
    public RawImage[] waveLine;
    public TextMeshProUGUI waveText;
    //public float scrollingSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        //MoveLine(waveLine[0]);
        //MoveLine(waveLine[1]);
    }

    public void WaveNoticeActive(bool active)
    {
        gameObject.SetActive(active);
    }

    //void MoveLine(RawImage line)
    //{
    //    line.uvRect = new Rect(line.uvRect.position + new Vector2(-scrollingSpeed, 0) * Time.deltaTime, line.uvRect.size);
    //}

    public void WaveNoticeText(int wave)
    {
        waveText.text = $"¿þÀÌºê {wave}";
    }
}
