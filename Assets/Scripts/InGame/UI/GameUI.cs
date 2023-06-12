using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI remainEnemyText;
    public Slider hpSlider;

    void Start()
    {

    }

    void Update()
    {

    }

    public void GameUIActive(bool active)
    {
        gameObject.SetActive(true);
        hpSlider.gameObject.SetActive(active);
    }

    public void TextUpdate(int wave, int coin, int remainEnemy)
    {
        waveText.text = $"���̺� {wave}";
        coinText.text = $"�� {coin}";
        remainEnemyText.text = $"���� �� : {remainEnemy}";
    }

    public void HPUpdate(int max, int current)
    {
        hpSlider.minValue = 0;
        hpSlider.maxValue = max;
        hpSlider.value = current;
    }
}
