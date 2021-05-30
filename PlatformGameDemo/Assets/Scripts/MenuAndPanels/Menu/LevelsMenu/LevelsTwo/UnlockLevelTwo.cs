using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UnlockLevelTwo : MonoBehaviour
{
    public static bool exitFromUnlock;
    public GameObject areaOfPoints;
    public Button level4;
    public TextMeshProUGUI firstQuestion, secondQuestionLvl4, unlockedInfo, moreDiamondsInfo, unlockPreviousInfo;
    private float timeFirstQuestion, timeFirstEnd, timePrevious;
    private bool firstIsPressed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || exitFromUnlock)
            if (unlockedInfo.enabled || firstQuestion.enabled || secondQuestionLvl4.enabled || moreDiamondsInfo.enabled || unlockPreviousInfo.enabled)
                unlockPreviousInfo.enabled = firstQuestion.enabled = secondQuestionLvl4.enabled = unlockedInfo.enabled = moreDiamondsInfo.enabled = exitFromUnlock = false;
        #region FourthLevel
        if (LevelsMenuSelectionTwo.selectedOption == 1 & MainValuesContainer.unlockedLevel < 3)
        {
            timePrevious += Time.deltaTime;
            unlockPreviousInfo.enabled = timePrevious > 1f ? true : unlockPreviousInfo.enabled;
        }
        else if (LevelsMenuSelectionTwo.selectedOption == 1 & !level4.interactable & !ChangingPointsPurple.changingTime & !ChangingPointsPurple.resetTime & !moreDiamondsInfo.enabled & timeFirstEnd == 0f)
        {
            timeFirstQuestion += Time.deltaTime;
            firstQuestion.enabled = timeFirstQuestion > 1f & !firstQuestion.enabled & !secondQuestionLvl4.enabled & !unlockedInfo.enabled & !moreDiamondsInfo.enabled ? true : firstQuestion.enabled;
            if (Input.GetKey(KeyCode.Y) & firstQuestion.enabled)
            {
                secondQuestionLvl4.enabled = firstIsPressed = true;
                firstQuestion.enabled = false;
            }
            else if (Input.GetKey(KeyCode.N) & firstQuestion.enabled)
            {
                timeFirstQuestion = 0f;
                firstQuestion.enabled = false;
            }
            firstIsPressed = Input.GetKeyUp(KeyCode.Y) & !firstQuestion.enabled & firstIsPressed ? false : firstIsPressed;
            if (timeFirstQuestion > 1f & Input.GetKey(KeyCode.Y) & !firstIsPressed & MainValuesContainer.scoreBlue >= 20)
            {
                secondQuestionLvl4.enabled = false;
                areaOfPoints.GetComponent<ChangingPointsBlue>().valueToChange = 20;
                areaOfPoints.GetComponent<ChangingPointsBlue>().chosenButton = level4;
                ChangingPointsBlue.changingTime = level4.interactable = unlockedInfo.enabled = true;
                MainValuesContainer.unlockedLevel = 4;
            }
            else if (timeFirstQuestion > 1f & Input.GetKey(KeyCode.Y) & !firstIsPressed & MainValuesContainer.scoreBlue < 20)
            {
                secondQuestionLvl4.enabled = false;
                moreDiamondsInfo.enabled = true;
            }
            else if (Input.GetKey(KeyCode.N) & secondQuestionLvl4.enabled)
            {
                timeFirstQuestion = 0f;
                secondQuestionLvl4.enabled = false;
            }
        }
        else if (LevelsMenuSelectionTwo.selectedOption == 1 & level4.interactable & unlockedInfo.enabled || moreDiamondsInfo.enabled & timeFirstQuestion > 1f)
        {
            timeFirstEnd += Time.deltaTime;
            if (timeFirstEnd > 2f & unlockedInfo.enabled)
                unlockedInfo.enabled = false;
            else if (timeFirstEnd > 2.5f & moreDiamondsInfo.enabled)
                moreDiamondsInfo.enabled = false;
        }
        else if (LevelsMenuSelectionTwo.selectedOption == 1 & !moreDiamondsInfo.enabled & timeFirstEnd > 0f)
            timeFirstEnd = timeFirstQuestion = 0f;
        else if (LevelsMenuSelectionTwo.selectedOption != 1 & !level4.interactable)
            timeFirstQuestion = timePrevious = 0f;
        #endregion
    }
}
