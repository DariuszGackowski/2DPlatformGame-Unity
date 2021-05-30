using UnityEngine;
using UnityEngine.EventSystems;
public class DrawLotsFor : MonoBehaviour
{
    public GemMarktSelection gemMarktSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? GemMarktSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        if (beforeSelectedOption != 3)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            GemMarktSelection.selectedOption = 3;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        gemMarktSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        gemMarktSelection.enabled = true;
        mouseOnButton = false;
    }
}
