using UnityEngine;
using UnityEngine.EventSystems;
public class GemMarket : MonoBehaviour
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
        if (beforeSelectedOption != 2)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            BaseOfLevelsSelection.selectedOption = 2;
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
