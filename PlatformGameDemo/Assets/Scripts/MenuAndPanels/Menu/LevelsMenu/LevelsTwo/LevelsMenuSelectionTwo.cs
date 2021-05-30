using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelsMenuSelectionTwo : MonoBehaviour
{
    public static int selectedOption = -1, numberOfLevel;
    public GameObject level4, back, selectedArrow, ordinaryArrow;
    public TextMeshProUGUI unlockedInfo;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 5;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (LevelsMenuSelectionTwo.selectedOption == -1)
                LevelsMenuSelectionTwo.selectedOption = 1;
            else
            {
                LevelsMenuSelectionTwo.selectedOption += 1;
                LevelsMenuSelectionTwo.selectedOption = LevelsMenuSelectionTwo.selectedOption > numberOfOptions ? 1 : LevelsMenuSelectionTwo.selectedOption;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (LevelsMenuSelectionTwo.selectedOption == -1)
                LevelsMenuSelectionTwo.selectedOption = 1;
            else
            {
                LevelsMenuSelectionTwo.selectedOption -= 1;
                LevelsMenuSelectionTwo.selectedOption = LevelsMenuSelectionTwo.selectedOption <= 0 ? numberOfOptions : LevelsMenuSelectionTwo.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        if (LevelsMenuSelectionTwo.selectedOption == 2 & Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("Levels");
        switch (LevelsMenuSelectionTwo.selectedOption)
        {
            case 1:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(level4);
                break;
            case 2:
                ordinaryArrow.SetActive(false);
                selectedArrow.SetActive(true);
                break;
            case 3:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
