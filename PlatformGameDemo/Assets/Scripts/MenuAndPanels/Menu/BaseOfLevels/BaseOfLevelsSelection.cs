using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class BaseOfLevelsSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public GameObject levels, gemMarket, saveGame, back;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (BaseOfLevelsSelection.selectedOption == -1)
                BaseOfLevelsSelection.selectedOption = 1;
            else
            {
                BaseOfLevelsSelection.selectedOption += 1;
                BaseOfLevelsSelection.selectedOption = BaseOfLevelsSelection.selectedOption > numberOfOptions ? 1 : BaseOfLevelsSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (BaseOfLevelsSelection.selectedOption == -1)
                BaseOfLevelsSelection.selectedOption = 1;
            else
            {
                BaseOfLevelsSelection.selectedOption -= 1;
                BaseOfLevelsSelection.selectedOption = BaseOfLevelsSelection.selectedOption <= 0 ? numberOfOptions : BaseOfLevelsSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        switch (BaseOfLevelsSelection.selectedOption)
        {
            case 1:
                eventSystem.SetSelectedGameObject(levels);
                break;
            case 2:
                eventSystem.SetSelectedGameObject(gemMarket);
                break;
            case 3:
                eventSystem.SetSelectedGameObject(saveGame);
                break;
            case 4:
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
