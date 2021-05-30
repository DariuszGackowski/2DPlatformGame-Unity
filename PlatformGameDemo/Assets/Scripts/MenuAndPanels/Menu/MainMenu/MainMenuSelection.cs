using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MainMenuSelection : MonoBehaviour
{
    public GameObject newGame, loadGame, options, controls, exit;
    public EventSystem eventSystem;
    private readonly int numberOfOptions = 5;
    public static int selectedOption = -1;
    public AudioSource buttonSounds;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (MainMenuSelection.selectedOption == -1)
                MainMenuSelection.selectedOption = 1;
            else
            {
                MainMenuSelection.selectedOption += 1;
                MainMenuSelection.selectedOption = MainMenuSelection.selectedOption > numberOfOptions ? 1 : MainMenuSelection.selectedOption;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (MainMenuSelection.selectedOption == -1)
                MainMenuSelection.selectedOption = 1;
            else
            {
                MainMenuSelection.selectedOption -= 1;
                MainMenuSelection.selectedOption = MainMenuSelection.selectedOption <= 0 ? numberOfOptions : MainMenuSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        switch (MainMenuSelection.selectedOption)
        {
            case 1:
                eventSystem.SetSelectedGameObject(newGame);
                break;
            case 2:
                eventSystem.SetSelectedGameObject(loadGame);
                break;
            case 3:
                eventSystem.SetSelectedGameObject(options);
                break;
            case 4:
                eventSystem.SetSelectedGameObject(controls);
                break;
            case 5:
                eventSystem.SetSelectedGameObject(exit);
                break;
        }
    }
}
