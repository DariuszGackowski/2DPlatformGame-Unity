using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelsMenuSelection : MonoBehaviour
{
    public static int selectedOption = -1, numberOfLevel;
    public GameObject level1, level2, level3, back, selectedArrow, ordinaryArrow;
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
            if (LevelsMenuSelection.selectedOption == -1)
                LevelsMenuSelection.selectedOption = 1;
            else
            {
                LevelsMenuSelection.selectedOption += 1;
                LevelsMenuSelection.selectedOption = LevelsMenuSelection.selectedOption > numberOfOptions ? 1 : LevelsMenuSelection.selectedOption;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (LevelsMenuSelection.selectedOption == -1)
                LevelsMenuSelection.selectedOption = 1;
            else
            {
                LevelsMenuSelection.selectedOption -= 1;
                LevelsMenuSelection.selectedOption = LevelsMenuSelection.selectedOption <= 0 ? numberOfOptions : LevelsMenuSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        if (LevelsMenuSelection.selectedOption == 4 & Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("NextLevels");
        switch (LevelsMenuSelection.selectedOption)
        {
            case 1:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(level1);
                break;
            case 2:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(level2);
                break;
            case 3:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(level3);
                break;
            case 4:
                ordinaryArrow.SetActive(false);
                selectedArrow.SetActive(true);
                break;
            case 5:
                ordinaryArrow.SetActive(true);
                selectedArrow.SetActive(false);
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
