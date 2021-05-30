using UnityEngine;
using UnityEngine.SceneManagement;
public class BaseOfLevelsMenu : MonoBehaviour
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
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SaveGame()
    {
        SceneManager.LoadScene("SaveGameScene");
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void GemMarket()
    {
        SceneManager.LoadScene("GemMarket");
    }
}
