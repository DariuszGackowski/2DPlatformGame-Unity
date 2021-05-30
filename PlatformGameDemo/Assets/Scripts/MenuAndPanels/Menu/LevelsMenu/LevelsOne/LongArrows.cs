using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class LongArrows : MonoBehaviour
{
    public LevelsMenuSelection levelsMenuSelection;
    public GameObject selectedArrow;
    public TextMeshProUGUI unlockedInfo;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private void OnMouseEnter()
    {
            LevelsMenuSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
            eventSystem.SetSelectedGameObject(null);
            levelsMenuSelection.enabled = false;
            selectedArrow.SetActive(true);
            gameObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (gameObject.activeSelf)
        {
            LevelsMenuSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
            eventSystem.SetSelectedGameObject(null);
            levelsMenuSelection.enabled = false;
            selectedArrow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
