using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuSelection : MonoBehaviour
{
    public static bool restartScreenIsOpened;
    public GameObject volume, music, sounds, back, pauseMusicScreen, resume, changeOfLevel, baseOfLevels, options, quit, pauseMainScreen, deathScreen, restartScreen;
    public Button optionsButton;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    public Slider volumeSlider, musicSlider, soundsSlider;
    private int selectedMusicOption = -1, selectedPauseMenuOption = -1, whichPanelIsBetterVote;
    private float time;
    private bool nothingIsPressed;
    private readonly int numberOfMusicOptions = 4, numberOfPauseMenuOptions = 5;
    private void Update()
    {
        if (!restartScreen.activeSelf & !deathScreen.activeSelf & !pauseMainScreen.activeSelf & !pauseMusicScreen.activeSelf & nothingIsPressed & !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            time += Time.deltaTime;
            if (time > 10f)
            {
                whichPanelIsBetterVote = 1;
                ScoreManager.TakeBreak();
            }
        }
        else
            time = 0f;
        switch (whichPanelIsBetterVote)
        {
            case 0:
                pauseMainScreen.SetActive(false);
                pauseMusicScreen.SetActive(false);
                selectedPauseMenuOption = -1;
                break;
            case 1:
                pauseMusicScreen.SetActive(false);
                pauseMainScreen.SetActive(true);
                if (selectedMusicOption != -1 & selectedPauseMenuOption == 4)
                {
                    eventSystem.SetSelectedGameObject(null);
                    eventSystem.SetSelectedGameObject(options);
                }
                selectedMusicOption = -1;
                break;
            case 2:
                pauseMainScreen.SetActive(false);
                pauseMusicScreen.SetActive(true);
                break;
        }
        #region PauseMusicScreen
        if (pauseMusicScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                if (selectedMusicOption == -1)
                    selectedMusicOption = 1;
                else
                {
                    selectedMusicOption += 1;
                    selectedMusicOption = selectedMusicOption > numberOfMusicOptions ? 1 : selectedMusicOption;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                if (selectedMusicOption == -1)
                    selectedMusicOption = 1;
                else
                {
                    selectedMusicOption -= 1;
                    selectedMusicOption = selectedMusicOption <= 0 ? numberOfMusicOptions : selectedMusicOption;
                }
            }
            whichPanelIsBetterVote = Input.GetKeyDown(KeyCode.Return) & selectedMusicOption == 4 ? 1 : whichPanelIsBetterVote;
            if (Input.GetKeyDown(KeyCode.Escape) & whichPanelIsBetterVote == 2)
            {
                whichPanelIsBetterVote = 1;
                selectedMusicOption = -1;
            }
            switch (selectedMusicOption)
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
        #endregion
        #region PauseMainScreen
        if (pauseMainScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                if (selectedPauseMenuOption == -1)
                    selectedPauseMenuOption = 1;
                else
                {
                    selectedPauseMenuOption += 1;
                    selectedPauseMenuOption = selectedPauseMenuOption > numberOfPauseMenuOptions ? 1 : selectedPauseMenuOption;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                if (selectedPauseMenuOption == -1)
                    selectedPauseMenuOption = 1;
                else
                {
                    selectedPauseMenuOption -= 1;
                    selectedPauseMenuOption = selectedPauseMenuOption <= 0 ? numberOfPauseMenuOptions : selectedPauseMenuOption;
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
                switch (selectedPauseMenuOption)
                {
                    case 1:
                        whichPanelIsBetterVote = 0;
                        ScoreManager.TakeReBreak();
                        break;
                    case 2:
                        ScoreManager.scoreOrangeCurrentScene = ScoreManager.scoreBlueCurrentScene = ScoreManager.scorePurpleCurrentScene = 0;
                        switch (MainValuesContainer.chosenScene)
                        {
                            case 1:
                                SceneManager.LoadScene("Levels");
                                break;
                            case 2:
                                SceneManager.LoadScene("NextLevels");
                                break;
                        }
                        break;
                    case 3:
                        ScoreManager.scoreOrangeCurrentScene = ScoreManager.scoreBlueCurrentScene = ScoreManager.scorePurpleCurrentScene = 0;
                        SceneManager.LoadScene("BaseOfLevels");
                        break;
                    case 4:
                        whichPanelIsBetterVote = 2;
                        break;
                    case 5:
                        Application.Quit();
                        break;
                }
            if (Input.GetKeyDown(KeyCode.Escape) & whichPanelIsBetterVote == 1)
            {
                whichPanelIsBetterVote = 0;
                selectedPauseMenuOption = -1;
                ScoreManager.TakeReBreak();
            }
            switch (selectedPauseMenuOption)
            {
                case 1:
                    eventSystem.SetSelectedGameObject(null);
                    eventSystem.SetSelectedGameObject(resume);
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(changeOfLevel);
                    break;
                case 3:
                    eventSystem.SetSelectedGameObject(baseOfLevels);
                    break;
                case 4:
                    eventSystem.SetSelectedGameObject(options);
                    break;
                case 5:
                    eventSystem.SetSelectedGameObject(quit);
                    break;
            }
        }
        else if (!pauseMainScreen.activeSelf & Input.GetKeyDown(KeyCode.Escape) & whichPanelIsBetterVote == 0 & !restartScreen.activeSelf & !deathScreen.activeSelf & !restartScreenIsOpened)
        {
            ScoreManager.TakeBreak();
            whichPanelIsBetterVote = 1;
        }
    }
    #endregion
    private void OnGUI()
    {
        nothingIsPressed = !Event.current.isKey ? true : false;
    }
}
