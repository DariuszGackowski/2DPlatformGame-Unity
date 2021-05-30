using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class RestartScreenSelection : MonoBehaviour
{
    public GameObject maybeICan, iMadeMistake, restartScreen, pauseMainScreen, deathScreen, pauseMusicScreen;
    public Animator playerAnimator;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private int healthOnStart;
    private void Start()
    {
        healthOnStart = MainValuesContainer.health;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R) & !deathScreen.activeSelf & !pauseMainScreen.activeSelf & !pauseMusicScreen.activeSelf & !restartScreen.activeSelf)
        {
            ScoreManager.TakeBreak();
            restartScreen.SetActive(true);
        }
        if (restartScreen.activeSelf)
        {
            if (MainValuesContainer.selectedOptionRestartScreen == 1)
            {
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(maybeICan);
            }
            else
            {
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(iMadeMistake);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenuSelection.restartScreenIsOpened = true;
                ScoreManager.TakeReBreak();
                restartScreen.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                MainValuesContainer.selectedOptionRestartScreen = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                MainValuesContainer.selectedOptionRestartScreen = 2;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (MainValuesContainer.selectedOptionRestartScreen)
                {
                    case 1:
                        MainValuesContainer.health = healthOnStart == 0 ? 3 : healthOnStart;
                        ScoreManager.scoreOrangeCurrentScene = ScoreManager.scoreBlueCurrentScene = ScoreManager.scorePurpleCurrentScene = 0;
                        MainValuesContainer.checkLifePoints = MainValuesContainer.unfrozeGame = LadderRebaseDetector.topEnterLadder = true;
                        DetectorEnemy.inCorridor = ClimbingDetector.playerOnLadder = LadderTopDetector.topOfLadder = LadderGroundDetector.baseOfLadder = LadderRebaseDetector.enterLadder = false;
                        playerAnimator.SetBool("AboveLadder", false);
                        playerAnimator.SetBool("UnderLadder", false);
                        MainValuesContainerConnection.EnoughConnexion();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        break;
                    case 2:
                        ScoreManager.TakeReBreak();
                        restartScreen.SetActive(false);
                        break;
                }
            }
            switch (MainValuesContainer.selectedOptionRestartScreen)
            {
                case 1:
                    eventSystem.SetSelectedGameObject(maybeICan);
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(iMadeMistake);
                    break;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
            PauseMenuSelection.restartScreenIsOpened = false;
    }
}
