using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level4 : MonoBehaviour
{
    public LevelsMenuSelectionTwo levelsMenuSelectionTwo;
    public GameObject selectedArrow, ordinaryArrow;
    public Texture2D padlockTexture, cursoreTexture;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton, changeWasMade;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LevelsMenuSelectionTwo.selectedOption : beforeSelectedOption;
        if (gameObject.GetComponent<Button>().interactable & !changeWasMade)
        {
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
            changeWasMade = true;
        }
    }
    private void OnMouseEnter()
    {
        UnlockLevelTwo.exitFromUnlock = mouseOnButton = true;
        selectedArrow.SetActive(false);
        ordinaryArrow.SetActive(true);
        if (beforeSelectedOption != 1)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            UnlockLevelTwo.exitFromUnlock = true;
            LevelsMenuSelectionTwo.selectedOption = 1;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        levelsMenuSelectionTwo.enabled = false;
    }
    private void OnMouseExit()
    {
        if (!gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
        levelsMenuSelectionTwo.enabled = true;
        mouseOnButton = false;
    }
    private void OnMouseOver()
    {
        if (!gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(padlockTexture, Vector2.zero, CursorMode.Auto);
        else if(gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
    }
}
