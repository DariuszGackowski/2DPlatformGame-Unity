using UnityEngine;
using UnityEngine.EventSystems;
public class BackBaseOfLevelsMenu : MonoBehaviour
{
    public BaseOfLevelsSelection baseOfLevelsSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? BaseOfLevelsSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 4)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            BaseOfLevelsSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        baseOfLevelsSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        baseOfLevelsSelection.enabled = true;
        mouseOnButton = false;
    }
}
