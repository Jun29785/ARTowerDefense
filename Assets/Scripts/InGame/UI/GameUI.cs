using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI remainEnemyText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameUIActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void TextUpdate(int wave, int coin, int remainEnemy)
    {
        waveText.text = $"Wave {wave}";
        coinText.text = $"¨Ï {coin}";
        remainEnemyText.text = $"³²Àº Àû : {remainEnemy}";
    }
}
