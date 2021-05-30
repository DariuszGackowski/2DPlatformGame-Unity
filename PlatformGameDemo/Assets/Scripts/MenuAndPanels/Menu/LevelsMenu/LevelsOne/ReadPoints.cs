using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ReadPoints : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple;
    public GameObject[] cherries = new GameObject[5];
    public Button level2, level3;
    private void Start()
    {
        MainValuesContainer.CheckingGemPoints(textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple);
        ScoreManager.SetLifePointsCount(cherries, MainValuesContainer.health);
        if (MainValuesContainer.unlockedLevel==2)
            level2.interactable = true;
        else if (MainValuesContainer.unlockedLevel > 2)
            level3.interactable = level2.interactable = true;
    }
}
