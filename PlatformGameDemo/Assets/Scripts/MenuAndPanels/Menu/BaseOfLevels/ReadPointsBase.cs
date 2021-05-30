using TMPro;
using UnityEngine;
public class ReadPointsBase : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple;
    public GameObject[] cherries = new GameObject[5];
    private void Start()
    {
        MainValuesContainer.CheckingGemPoints(textMeshProUGUIOrange, textMeshProUGUIBlue, textMeshProUGUIPurple);
        ScoreManager.SetLifePointsCount(cherries, MainValuesContainer.health);
    }
}
