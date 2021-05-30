using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UnlockLevel : MonoBehaviour
{
    public static bool exitFromUnlock;
    public GameObject areaOfPoints;
    public Button level2, level3;
    public TextMeshProUGUI firstQuestion, secondQuestionLvl2, secondQuestionLvl3, unlockedInfo, moreDiamondsInfo, loadInfo, unlockPreviousInfo;
    private float timeFirstQuestion, timeFirstEnd, timeSecondQuestion, timeSecondEnd,timePrevious;
    private bool firstIsPressed, secondIsPressed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || UnlockLevel.exitFromUnlock)
        {
            if (unlockedInfo.enabled || firstQuestion.enabled || secondQuestionLvl2.enabled || secondQuestionLvl3.enabled || moreDiamondsInfo.enabled || unlockPreviousInfo.enabled)
                firstQuestion.enabled = secondQuestionLvl3.enabled = unlockedInfo.enabled = moreDiamondsInfo.enabled = unlockPreviousInfo.enabled = exitFromUnlock = firstQuestion.enabled = false;
        }
        #region SecondLevel
        if (LevelsMenuSelection.selectedOption == 2 & !level2.interactable & !ChangingPointsPurple.changingTime & !ChangingPointsPurple.resetTime & !moreDiamondsInfo.enabled & timeFirstEnd == 0f & !loadInfo.enabled)
        {
            timeFirstQuestion += Time.deltaTime;
            firstQuestion.enabled = timeFirstQuestion > 1f & !firstQuestion.enabled & !secondQuestionLvl2.enabled & !unlockedInfo.enabled & !moreDiamondsInfo.enabled ? true : firstQuestion.enabled;
            if (Input.GetKey(KeyCode.Y) & firstQuestion.enabled)
            {
                secondQuestionLvl2.enabled = firstIsPressed = true;
                firstQuestion.enabled = false;
            }
            else if (Input.GetKey(KeyCode.N) & firstQuestion.enabled)
            {
                timeFirstQuestion = 0f;
                firstQuestion.enabled = false;
            }
            firstIsPressed = Input.GetKeyUp(KeyCode.Y) & !firstQuestion.enabled & firstIsPressed ? false : firstIsPressed;
            if (timeFirstQuestion > 1f & Input.GetKey(KeyCode.Y) & !firstIsPressed & MainValuesContainer.scorePurple >= 10)
            {
                secondQuestionLvl2.enabled = false;
                areaOfPoints.GetComponent<ChangingPointsPurple>().valueToChange = 10;
                areaOfPoints.GetComponent<ChangingPointsPurple>().chosenButton = level2;
                MainValuesContainer.unlockedLevel = 2;
                unlockedInfo.enabled = level2.interactable = ChangingPointsPurple.changingTime = true;
            }
            else if (timeFirstQuestion > 1f & Input.GetKey(KeyCode.Y) & !firstIsPressed & MainValuesContainer.scorePurple < 10)
            {
                secondQuestionLvl2.enabled = false;
                moreDiamondsInfo.enabled = true;
            }
            else if (Input.GetKey(KeyCode.N) & secondQuestionLvl2.enabled)
            {
                timeFirstQuestion = 0f;
                secondQuestionLvl2.enabled = false;
            }
        }
        else if (LevelsMenuSelection.selectedOption == 2 & level2.interactable & unlockedInfo.enabled || moreDiamondsInfo.enabled & timeFirstQuestion > 1f)
        {
            timeFirstEnd += Time.deltaTime;
            if (timeFirstEnd > 2f & unlockedInfo.enabled)
                unlockedInfo.enabled = false;
            else if (timeFirstEnd > 2.5f & moreDiamondsInfo.enabled)
                moreDiamondsInfo.enabled = false;
        }
        else if (LevelsMenuSelection.selectedOption == 2 & !moreDiamondsInfo.enabled & timeFirstEnd > 0f)
            timeFirstEnd = timeFirstQuestion = 0f;
        else if (LevelsMenuSelection.selectedOption != 2 & !level2.interactable)
            timeFirstQuestion = timePrevious = 0f;
        #endregion
        #region ThirdLevel
        if (LevelsMenuSelection.selectedOption == 3 & MainValuesContainer.unlockedLevel < 2)
        {
            timePrevious += Time.deltaTime;
            unlockPreviousInfo.enabled = timePrevious > 1f ? true : unlockPreviousInfo.enabled;
        }
        else if (LevelsMenuSelection.selectedOption == 3 & !level3.interactable & !ChangingPointsPurple.changingTime & !ChangingPointsPurple.resetTime & !moreDiamondsInfo.enabled & timeSecondEnd == 0f & !loadInfo.enabled)
        {
            timeSecondQuestion += Time.deltaTime;
            firstQuestion.enabled = timeSecondQuestion > 1f & !firstQuestion.enabled & !secondQuestionLvl3.enabled & !unlockedInfo.enabled & !moreDiamondsInfo.enabled ? true : firstQuestion.enabled;
            if (Input.GetKey(KeyCode.Y) & firstQuestion.enabled)
            {
                secondIsPressed = secondQuestionLvl3.enabled = true;
                firstQuestion.enabled = false;
            }
            else if (Input.GetKey(KeyCode.N) & firstQuestion.enabled)
            {
                timeSecondQuestion = 0f;
                firstQuestion.enabled = false;
            }
            secondIsPressed = Input.GetKeyUp(KeyCode.Y) & !firstQuestion.enabled & secondIsPressed ? false : secondIsPressed;
            if (timeSecondQuestion > 1f & Input.GetKey(KeyCode.Y) & !secondIsPressed & MainValuesContainer.scorePurple >= 15)
            {
                secondQuestionLvl3.enabled = false;
                areaOfPoints.GetComponent<ChangingPointsPurple>().valueToChange = 15;
                areaOfPoints.GetComponent<ChangingPointsPurple>().chosenButton = level3;
                MainValuesContainer.unlockedLevel = 3;
                unlockedInfo.enabled = level3.interactable = ChangingPointsPurple.changingTime = true;
            }
            else if (timeSecondQuestion > 1f & Input.GetKey(KeyCode.Y) & !secondIsPressed & MainValuesContainer.scorePurple < 15)
            {
                secondQuestionLvl3.enabled = false;
                moreDiamondsInfo.enabled = true;
            }
            else if (Input.GetKey(KeyCode.N) & secondQuestionLvl3.enabled)
            {
                timeSecondQuestion = 0f;
                secondQuestionLvl3.enabled = false;
            }
        }
        else if (LevelsMenuSelection.selectedOption == 3 & level3.interactable & unlockedInfo.enabled || moreDiamondsInfo.enabled & timeSecondQuestion > 1f)
        {
            timeSecondEnd += Time.deltaTime;
            if (timeSecondEnd > 2f & unlockedInfo.enabled)
                unlockedInfo.enabled = false;
            else if (timeSecondEnd > 2.5f & moreDiamondsInfo.enabled)
                moreDiamondsInfo.enabled = false;
        }
        else if (LevelsMenuSelection.selectedOption == 3 & !moreDiamondsInfo.enabled & timeSecondEnd > 0f)
            timeSecondEnd = timeSecondQuestion = 0f;
        else if (LevelsMenuSelection.selectedOption != 3 & !level3.interactable)
            timePrevious = timeSecondQuestion = 0f;
        #endregion
    }
}
