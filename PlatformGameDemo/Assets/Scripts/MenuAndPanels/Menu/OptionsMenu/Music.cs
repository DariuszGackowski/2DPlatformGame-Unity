using UnityEngine;
using UnityEngine.EventSystems;
public class Music : MonoBehaviour
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
        if (beforeSelectedOption != 2)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            OptionsMenuSelection.selectedOption = 2;
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
