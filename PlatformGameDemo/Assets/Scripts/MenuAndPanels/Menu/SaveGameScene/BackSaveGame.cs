using UnityEngine;
using UnityEngine.EventSystems;
public class BackSaveGame : MonoBehaviour
{
    public SaveGameSelection saveGameSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? SaveGameSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 4)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            SaveGameSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        saveGameSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        saveGameSelection.enabled = true;
        mouseOnButton = false;
    }
}

