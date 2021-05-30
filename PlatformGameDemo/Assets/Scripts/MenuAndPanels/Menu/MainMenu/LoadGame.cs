using UnityEngine;
using UnityEngine.EventSystems;
public class LoadGame : MonoBehaviour
{
    public MainMenuSelection mainMenuSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? MainMenuSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 2)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            MainMenuSelection.selectedOption = 2;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        mainMenuSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        mainMenuSelection.enabled = true;
        mouseOnButton = false;
    }
}
