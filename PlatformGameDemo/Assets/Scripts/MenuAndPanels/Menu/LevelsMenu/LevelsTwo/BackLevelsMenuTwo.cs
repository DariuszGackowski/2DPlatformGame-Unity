using UnityEngine;
using UnityEngine.EventSystems;
public class BackLevelsMenuTwo : MonoBehaviour
{
    public LevelsMenuSelectionTwo levelsMenuSelectionTwo;
    public GameObject selectedArrow, ordinaryArrow;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LevelsMenuSelectionTwo.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        UnlockLevelTwo.exitFromUnlock = mouseOnButton = true;
        selectedArrow.SetActive(false);
        ordinaryArrow.SetActive(true);
        if (beforeSelectedOption != 3)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            LevelsMenuSelectionTwo.selectedOption = 3;
            UnlockLevelTwo.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        levelsMenuSelectionTwo.enabled = false;
    }
    private void OnMouseExit()
    {
        levelsMenuSelectionTwo.enabled = true;
        mouseOnButton = false;
    }
}
