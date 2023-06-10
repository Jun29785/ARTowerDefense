using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScrolling : MonoBehaviour
{
    public Image background;

    private void Start()
    {
        background = GetComponent<Image>();
    }

    void Update()
    {
        Vector2 move = new Vector2(1, 1) * Time.deltaTime * 0.12f;
        background.material.mainTextureOffset += move;
    }
}
