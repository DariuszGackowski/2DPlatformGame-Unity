using UnityEngine;
using UnityEngine.EventSystems;
public class BackOptionsMenu : MonoBehaviour
{
    public OptionsMenuSelection optionsMenuSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? OptionsMenuSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 4)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            OptionsMenuSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        optionsMenuSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        optionsMenuSelection.enabled = true;
        mouseOnButton = false;
    }
}
