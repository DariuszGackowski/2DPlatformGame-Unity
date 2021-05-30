using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Assets.Scripts.Important;
using TMPro;
public class LoadSceneSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public GameObject emptyOne, emptyTwo, emptyThree, back;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private readonly int numberOfOptions = 4;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (LoadSceneSelection.selectedOption == -1)
                LoadSceneSelection.selectedOption = 1;
            else
            {
                LoadSceneSelection.selectedOption += 1;
                LoadSceneSelection.selectedOption = LoadSceneSelection.selectedOption > numberOfOptions ? 1 : LoadSceneSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (LoadSceneSelection.selectedOption == -1)
                LoadSceneSelection.selectedOption = 1;
            else
            {
                LoadSceneSelection.selectedOption -= 1;
                LoadSceneSelection.selectedOption = LoadSceneSelection.selectedOption <= 0 ? numberOfOptions : LoadSceneSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        switch (LoadSceneSelection.selectedOption)
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
