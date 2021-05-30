using UnityEngine;
using UnityEngine.EventSystems;
public class BackLevelsMenu : MonoBehaviour
{
    public LevelsMenuSelection levelsMenuSelection;
    public GameObject selectedArrow, ordinaryArrow;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LevelsMenuSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        selectedArrow.SetActive(false);
        ordinaryArrow.SetActive(true);
        if (beforeSelectedOption != 5)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            LevelsMenuSelection.selectedOption = 5;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        levelsMenuSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        levelsMenuSelection.enabled = true;
        mouseOnButton = false;
    }
}
