using UnityEngine;
using UnityEngine.EventSystems;
public class BackLoadGame : MonoBehaviour
{
    public LoadSceneSelection loadSceneSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LoadSceneSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 4)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            LoadSceneSelection.selectedOption = 4;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        loadSceneSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        loadSceneSelection.enabled = true;
        mouseOnButton = false;
    }
}
