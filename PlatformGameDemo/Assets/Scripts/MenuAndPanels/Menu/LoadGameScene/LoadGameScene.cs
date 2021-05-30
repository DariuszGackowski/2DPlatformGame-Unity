using UnityEngine;
using Assets.Scripts.Important;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadGameScene : MonoBehaviour
{
    public GameObject emptyOne, emptyTwo, emptyThree;
    public void LoadGameFromEmptyOne()
    {
        if (emptyOne.GetComponent<TextMeshProUGUI>().text != "Empty") 
        {
            GameSaveSerialization.LoadGame(emptyOne.name.ToString());
            GameLoadedInfo.gameIsLoaded = true;
        }
    }
    public void LoadGameFromEmptyTwo()
    {
        if (emptyTwo.GetComponent<TextMeshProUGUI>().text != "Empty")
        {
            GameSaveSerialization.LoadGame(emptyTwo.name.ToString());
            GameLoadedInfo.gameIsLoaded = true;
        }
    }
    public void LoadGameFromEmptyThree()
    {
        if (emptyThree.GetComponent<TextMeshProUGUI>().text != "Empty") 
        {
            GameSaveSerialization.LoadGame(emptyThree.name.ToString());
            GameLoadedInfo.gameIsLoaded = true;
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
