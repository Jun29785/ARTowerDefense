using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveNotice : MonoBehaviour
{
    public RawImage[] waveLine;
    public TextMeshProUGUI waveText;
    public float scrollingSpeed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        MoveLine(waveLine[0]);
        MoveLine(waveLine[1]);
    }

    void MoveLine(RawImage line)
    {
        line.uvRect = new Rect(line.uvRect.position + new Vector2(-scrollingSpeed, 0) * Time.deltaTime, line.uvRect.size);
    }

    public void WaveNoticeText(int wave)
    {
        waveText.text = $"¿þÀÌºê : {wave}";
    }
}
