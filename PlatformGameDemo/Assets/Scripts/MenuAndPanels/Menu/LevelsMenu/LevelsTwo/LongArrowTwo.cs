using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class LongArrowTwo : MonoBehaviour
{
    public LevelsMenuSelectionTwo levelsMenuSelectionTwo;
    public GameObject selectedArrow;
    public TextMeshProUGUI unlockedInfo;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private void OnMouseEnter()
    {

        LevelsMenuSelectionTwo.selectedOption = 2;
        UnlockLevelTwo.exitFromUnlock = true;
        if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
            buttonSounds.Play();
        eventSystem.SetSelectedGameObject(null);
        levelsMenuSelectionTwo.enabled = false;
        selectedArrow.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (gameObject.activeSelf)
        {
            LevelsMenuSelectionTwo.selectedOption = 2;
            UnlockLevelTwo.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
            eventSystem.SetSelectedGameObject(null);
            levelsMenuSelectionTwo.enabled = false;
            selectedArrow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
