using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsMenuTwo : MonoBehaviour
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
    public void Level4()
    {
        if (!ChangingPointsBlue.changingTime)
        {
            ChoosenLevelContainer.choiceNumber = 4;
            MainValuesContainer.chosenScene = 2;
            SceneManager.LoadScene("LoadingBar");
        }
    }
    public void Back()
    {
        if (!ChangingPointsBlue.changingTime)
            SceneManager.LoadScene("BaseOfLevels");
    }
}
