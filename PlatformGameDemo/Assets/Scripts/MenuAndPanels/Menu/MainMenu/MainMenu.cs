using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Texture2D cursorTexture;
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("BaseOfLevels");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGameScene");
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void Contorls()
    {
        SceneManager.LoadScene("ControlsMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
