using UnityEngine;
using UnityEngine.EventSystems;
public class BackControlsMenu : MonoBehaviour
{
    public ControlsMenuSelection controlsMenuSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? ControlsMenuSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 1)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            ControlsMenuSelection.selectedOption = 1;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        controlsMenuSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        controlsMenuSelection.enabled = true;
        mouseOnButton = false;
    }
}
