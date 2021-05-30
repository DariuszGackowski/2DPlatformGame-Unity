using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ReadPointsTwo : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple;
    public GameObject[] cherries = new GameObject[5];
    public Button level4;
    private void Start()
    {
        MainValuesContainer.CheckingGemPoints(textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple);
        ScoreManager.SetLifePointsCount(cherries, MainValuesContainer.health);
        level4.interactable = MainValuesContainer.unlockedLevel == 4 ? true : level4.interactable;
    }
}
