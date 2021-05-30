using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsMenu : MonoBehaviour
{
    private bool firstReadMouse;
    private void Update()
    {
        if (!firstReadMouse)
        {
            Cursor.lockState = CursorLockMode.None;
            firstReadMouse = Cursor.visible = true;
        }
    }
    public void Level1()
    {
        if (!ChangingPointsPurple.changingTime)
        {
            MainValuesContainer.chosenScene = ChoosenLevelContainer.choiceNumber = 1;
            SceneManager.LoadScene("LoadingBar");
        }
    }
    public void Level2()
    {
        if (!ChangingPointsPurple.changingTime)
        {
            ChoosenLevelContainer.choiceNumber = 2;
            MainValuesContainer.chosenScene = 1;
            SceneManager.LoadScene("LoadingBar");
        }
    }
    public void Level3()
    {
        if (!ChangingPointsPurple.changingTime)
        {
            ChoosenLevelContainer.choiceNumber = 3;
            MainValuesContainer.chosenScene = 1;
            SceneManager.LoadScene("LoadingBar");
        }
    }
    public void Back()
    {
        if (!ChangingPointsPurple.changingTime)
            SceneManager.LoadScene("BaseOfLevels");
    }
}
