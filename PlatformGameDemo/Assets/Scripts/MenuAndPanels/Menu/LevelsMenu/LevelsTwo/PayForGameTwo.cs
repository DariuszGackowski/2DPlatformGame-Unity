using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PayForGameTwo : MonoBehaviour
{
    public static bool enterToFour;
    public Button lvl4;
    public TextMeshProUGUI  textMeshProUGUILvl4, textMeshProUGUIInfo, textMeshProUGUIUnlockedInfo;
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
        if (LevelsMenuSelectionTwo.selectedOption < 2 & !textMeshProUGUIInfo.enabled)
        {
            switch (LevelsMenuSelectionTwo.selectedOption)
            {
                case 1:
                    textMeshProUGUILvl4.enabled = lvl4.interactable & !textMeshProUGUIUnlockedInfo.enabled ? true : textMeshProUGUILvl4.enabled;
                    if (enterToFour)
                    {
                        if (lvl4.interactable)
                            if (MainValuesContainer.scoreBlue < 15)
                            {
                                textMeshProUGUILvl4.enabled = false;
                                textMeshProUGUIInfo.enabled = true;
                            }
                            else
                                MainValuesContainer.scoreBlue -= 15;
                        enterToFour = false;
                    }
                    break;
                case 2:
                    textMeshProUGUILvl4.enabled = false;
                    break;
                case 3:
                    textMeshProUGUILvl4.enabled = false;
                    break;
            }
        }
        else
            textMeshProUGUILvl4.enabled = false;
    }
}
