using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionsMenuSelection : MonoBehaviour
{
    public static int selectedOption = -1;
    public GameObject volume, music, sounds, back;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    public Slider volumeSlider, musicSlider, soundsSlider;
    private readonly int numberOfOptions = 4;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (OptionsMenuSelection.selectedOption == -1)
                OptionsMenuSelection.selectedOption = 1;
            else
            {
                OptionsMenuSelection.selectedOption += 1;
                OptionsMenuSelection.selectedOption = OptionsMenuSelection.selectedOption > numberOfOptions ? 1 : OptionsMenuSelection.selectedOption;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!buttonSounds.isPlaying)
                buttonSounds.Play();
            if (OptionsMenuSelection.selectedOption == -1)
                OptionsMenuSelection.selectedOption = 1;
            else
            {
                OptionsMenuSelection.selectedOption -= 1;
                OptionsMenuSelection.selectedOption = OptionsMenuSelection.selectedOption <= 0 ? numberOfOptions : OptionsMenuSelection.selectedOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        switch (OptionsMenuSelection.selectedOption)
        {
            case 1:
                eventSystem.SetSelectedGameObject(volume);
                if (Input.GetKey(KeyCode.D))
                    volumeSlider.value += 0.01f;
                else if (Input.GetKey(KeyCode.A))
                    volumeSlider.value -= 0.01f;
                break;
            case 2:
                eventSystem.SetSelectedGameObject(music);
                if (Input.GetKey(KeyCode.D))
                    musicSlider.value += 0.01f;
                else if (Input.GetKey(KeyCode.A))
                    musicSlider.value -= 0.01f;
                break;
            case 3:
                eventSystem.SetSelectedGameObject(sounds);
                if (Input.GetKey(KeyCode.D))
                    soundsSlider.value += 0.01f;
                else if (Input.GetKey(KeyCode.A))
                    soundsSlider.value -= 0.01f;
                break;
            case 4:
                eventSystem.SetSelectedGameObject(back);
                break;
        }
    }
}
