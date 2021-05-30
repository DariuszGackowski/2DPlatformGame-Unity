using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GemMarktSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public GameObject buyCherry, illegalExchange, drawLots, back, areaOfPoints;
    public TextMeshProUGUI newCherry, noCherry, moreInfo, endedDrawing;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (GemMarktSelection.selectedOption == -1)
                GemMarktSelection.selectedOption = 1;
            else
            {
                GemMarktSelection.selectedOption += 1;
                GemMarktSelection.selectedOption = GemMarktSelection.selectedOption > numberOfOptions ? 1 : GemMarktSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (GemMarktSelection.selectedOption == -1)
                GemMarktSelection.selectedOption = 1;
            else
            {
                GemMarktSelection.selectedOption -= 1;
                GemMarktSelection.selectedOption = GemMarktSelection.selectedOption <= 0 ? numberOfOptions : GemMarktSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("BaseOfLevels");
        switch (GemMarktSelection.selectedOption)
        {
            case 1:
                eventSystem.SetSelectedGameObject(buyCherry);
                break;
            case 2:
                eventSystem.SetSelectedGameObject(illegalExchange);
                break;
            case 3:
                eventSystem.SetSelectedGameObject(drawLots);
                break;
            case 4:
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
