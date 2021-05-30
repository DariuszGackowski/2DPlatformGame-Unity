using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
public class SaveGameSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public static bool onMouseExit;
    public GameObject emptyOne, emptyTwo, emptyThree, back;
    public TextMeshProUGUI textMeshProUGUIInfo;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 4;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (SaveGameSelection.selectedOption == -1)
                SaveGameSelection.selectedOption = 1;
            else
            {
                SaveGameSelection.selectedOption += 1;
                SaveGameSelection.selectedOption = SaveGameSelection.selectedOption > numberOfOptions ? 1 : SaveGameSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (SaveGameSelection.selectedOption == -1)
                SaveGameSelection.selectedOption = 1;
            else
            {
                SaveGameSelection.selectedOption -= 1;
                SaveGameSelection.selectedOption = SaveGameSelection.selectedOption <= 0 ? numberOfOptions: SaveGameSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        switch (SaveGameSelection.selectedOption)
        {
            case 1:
                eventSystem.SetSelectedGameObject(emptyOne);
                break;
            case 2:
                eventSystem.SetSelectedGameObject(emptyTwo);
                break;
            case 3:
                eventSystem.SetSelectedGameObject(emptyThree);
                break;
            case 4:
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
