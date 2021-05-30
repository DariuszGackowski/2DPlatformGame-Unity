using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ControlsMenuSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public GameObject back;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 1;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (ControlsMenuSelection.selectedOption == -1)
                ControlsMenuSelection.selectedOption = 1;
            else
            {
                ControlsMenuSelection.selectedOption += 1;
                ControlsMenuSelection.selectedOption = ControlsMenuSelection.selectedOption > numberOfOptions ? 1 : ControlsMenuSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (ControlsMenuSelection.selectedOption == -1)
                ControlsMenuSelection.selectedOption = 1;
            else
            {
                ControlsMenuSelection.selectedOption -= 1;
                ControlsMenuSelection.selectedOption = ControlsMenuSelection.selectedOption <= 0 ? numberOfOptions : ControlsMenuSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) & ControlsMenuSelection.selectedOption == 1)
            SceneManager.LoadScene("MainMenu");
        if (ControlsMenuSelection.selectedOption == 1)
            eventSystem.SetSelectedGameObject(back);
    }
}
