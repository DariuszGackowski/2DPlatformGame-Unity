using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public LevelsMenuSelection levelsMenuSelection;
    public GameObject selectedArrow, ordinaryArrow;
    public Texture2D padlockTexture, cursoreTexture;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int beforeSelectedOption;
    private bool mouseOnButton, changeWasMade;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LevelsMenuSelection.selectedOption : beforeSelectedOption;
        if (gameObject.GetComponent<Button>().interactable & !changeWasMade)
        {
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
            changeWasMade = true;
        }
    }
    private void OnMouseEnter()
    {
        mouseOnButton = true;
        selectedArrow.SetActive(false);
        ordinaryArrow.SetActive(true);
        if (beforeSelectedOption != 2)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            LevelsMenuSelection.selectedOption = 2;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        levelsMenuSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        if (!gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
        levelsMenuSelection.enabled = true;
        mouseOnButton = false;
    }
    private void OnMouseOver()
    {
        if (!gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(padlockTexture, Vector2.zero, CursorMode.Auto);
        else if (gameObject.GetComponent<Button>().interactable)
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
    }
}
