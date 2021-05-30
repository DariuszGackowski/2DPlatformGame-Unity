using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class LoadThree : MonoBehaviour
{
    public LoadSceneSelection loadSceneSelection;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    public Texture2D banTexture, cursoreTexture;
    private int beforeSelectedOption;
    private bool mouseOnButton;
    private void Update()
    {
        beforeSelectedOption = !mouseOnButton ? LoadSceneSelection.selectedOption : beforeSelectedOption;
    }
    private void OnMouseEnter()
    {
        if (gameObject.GetComponent<TextMeshProUGUI>().text == "Empty")
            Cursor.SetCursor(banTexture, Vector2.zero, CursorMode.Auto);
        mouseOnButton = true;
        if (beforeSelectedOption != 3)
        {
            eventSystem.SetSelectedGameObject(gameObject);
            LoadSceneSelection.selectedOption = 3;
            UnlockLevel.exitFromUnlock = true;
            if (!buttonSounds.isPlaying & Time.timeSinceLevelLoad > 0.1f)
                buttonSounds.Play();
        }
        loadSceneSelection.enabled = false;
    }
    private void OnMouseExit()
    {
        if (gameObject.GetComponent<TextMeshProUGUI>().text == "Empty")
            Cursor.SetCursor(cursoreTexture, Vector2.zero, CursorMode.Auto);
        loadSceneSelection.enabled = true;
        mouseOnButton = false;
    }
}
