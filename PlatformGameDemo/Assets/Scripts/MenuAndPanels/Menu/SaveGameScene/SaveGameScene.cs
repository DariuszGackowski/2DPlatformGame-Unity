using UnityEngine;
using Assets.Scripts.Important;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveGameScene : MonoBehaviour
{
    public GameObject emptyOne, emptyTwo, emptyThree;
    public TextMeshProUGUI textMeshProUGUIInfo;
    public void SaveOne() 
    {
        ChangingTextInButton.onSave = true;
        GameSaveSerialization.SaveToFile(MainValuesContainer.scoreOrange, MainValuesContainer.scoreBlue, MainValuesContainer.scorePurple, MainValuesContainer.unlockedLevel, MainValuesContainer.health, MainValuesContainer.listOfReadyLevels, MainValuesContainer.orangeGems, MainValuesContainer.blueGems, MainValuesContainer.purpleGems, emptyOne.name.ToString());
        textMeshProUGUIInfo.enabled = true;
    }
    public void SaveTwo()
    {
        ChangingTextInButton.onSave = true;
        GameSaveSerialization.SaveToFile(MainValuesContainer.scoreOrange, MainValuesContainer.scoreBlue, MainValuesContainer.scorePurple, MainValuesContainer.unlockedLevel, MainValuesContainer.health, MainValuesContainer.listOfReadyLevels, MainValuesContainer.orangeGems, MainValuesContainer.blueGems, MainValuesContainer.purpleGems, emptyTwo.name.ToString());
        textMeshProUGUIInfo.enabled = true;
    }
    public void SaveThree()
    {
        ChangingTextInButton.onSave = true;
        GameSaveSerialization.SaveToFile(MainValuesContainer.scoreOrange, MainValuesContainer.scoreBlue, MainValuesContainer.scorePurple, MainValuesContainer.unlockedLevel, MainValuesContainer.health, MainValuesContainer.listOfReadyLevels, MainValuesContainer.orangeGems, MainValuesContainer.blueGems, MainValuesContainer.purpleGems, emptyThree.name.ToString());
        textMeshProUGUIInfo.enabled = true;
    }
    public void BackToBaseOfLevels() 
    {
        SceneManager.LoadScene("BaseOfLevels");
    }
}
