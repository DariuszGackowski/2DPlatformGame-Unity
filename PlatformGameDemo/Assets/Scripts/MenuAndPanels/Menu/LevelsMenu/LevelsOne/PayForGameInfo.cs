using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PayForGameInfo : MonoBehaviour
{
    public static bool enterToTwo, enterToThree;
    public Button lvl2, lvl3;
    public TextMeshProUGUI textMeshProUGUILvl1, textMeshProUGUILvl2, textMeshProUGUILvl3, textMeshProUGUIInfo, textMeshProUGUIUnlockedInfo, loadInfo;
    private float infoTime;
    void Update()
    {
        if (textMeshProUGUIInfo.enabled)
        {
            infoTime += Time.deltaTime;
            textMeshProUGUIInfo.enabled = infoTime > 2f ? false : textMeshProUGUIInfo.enabled;
        }
        else if (!textMeshProUGUIInfo.enabled & infoTime != 0)
            infoTime = 0;
        if (LevelsMenuSelection.selectedOption < 4 & !loadInfo.enabled & !textMeshProUGUIInfo.enabled)
        {
            switch (LevelsMenuSelection.selectedOption)
            {
                case 1:
                    textMeshProUGUILvl3.enabled = textMeshProUGUILvl2.enabled = false;
                    textMeshProUGUILvl1.enabled = true;
                    break;
                case 2:
                    textMeshProUGUILvl3.enabled = textMeshProUGUILvl1.enabled = false;
                    textMeshProUGUILvl2.enabled = lvl2.interactable & !textMeshProUGUIUnlockedInfo.enabled ? true : textMeshProUGUILvl2.enabled;
                    if (enterToTwo)
                    {
                        if (lvl2.interactable)
                            if (MainValuesContainer.scorePurple < 5)
                            {
                                textMeshProUGUILvl2.enabled = false;
                                textMeshProUGUIInfo.enabled = true;
                            }
                            else
                                MainValuesContainer.scorePurple -= 5;
                        enterToTwo = false;
                    }
                    break;
                case 3:
                    textMeshProUGUILvl2.enabled = textMeshProUGUILvl1.enabled = false;
                    textMeshProUGUILvl3.enabled = lvl3.interactable & !textMeshProUGUIUnlockedInfo.enabled ? true : textMeshProUGUILvl3.enabled;
                    if (enterToThree)
                    {
                        if (lvl3.interactable)
                            if (MainValuesContainer.scorePurple < 10)
                            {
                                textMeshProUGUILvl3.enabled = false;
                                textMeshProUGUIInfo.enabled = true;
                            }
                            else
                                MainValuesContainer.scorePurple -= 10;
                        enterToThree = false;
                    }
                    break;
                case 4:
                    textMeshProUGUILvl3.enabled = textMeshProUGUILvl2.enabled = textMeshProUGUILvl1.enabled = false;
                    break;
                case 5:
                    textMeshProUGUILvl3.enabled = textMeshProUGUILvl2.enabled = textMeshProUGUILvl1.enabled = false;
                    break;
            }
        }
        else if (LevelsMenuSelection.selectedOption >= 4)
            textMeshProUGUILvl1.enabled = textMeshProUGUILvl3.enabled = textMeshProUGUILvl2.enabled = false;
    }
}
