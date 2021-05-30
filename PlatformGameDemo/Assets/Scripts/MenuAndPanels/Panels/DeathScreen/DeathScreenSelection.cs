using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class DeathScreenSelection : MonoBehaviour
{
    public GameObject neverSurrender, imDone, deathScreen;
    public Animator playerAnimator;
    public EventSystem eventSystem;
    public AudioSource buttonSounds;
    private void Update()
    {
        if (deathScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                MainValuesContainer.selectedOptionDeathScreen = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (!buttonSounds.isPlaying)
                    buttonSounds.Play();
                MainValuesContainer.selectedOptionDeathScreen = 2;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (MainValuesContainer.selectedOptionDeathScreen)
                {
                    case 1:
                        MainValuesContainer.health = 3;
                        ScoreManager.scoreOrangeCurrentScene = ScoreManager.scoreBlueCurrentScene = ScoreManager.scorePurpleCurrentScene = 0;
                        MainValuesContainer.checkLifePoints = MainValuesContainer.unfrozeGame = LadderRebaseDetector.topEnterLadder = true;
                        DetectorEnemy.inCorridor = ClimbingDetector.playerOnLadder = LadderTopDetector.topOfLadder = LadderGroundDetector.baseOfLadder = LadderRebaseDetector.enterLadder = false;
                        playerAnimator.SetBool("AboveLadder", false);
                        playerAnimator.SetBool("UnderLadder", false);
                        MainValuesContainerConnection.EnoughConnexion();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
                }
            }
            switch (MainValuesContainer.selectedOptionDeathScreen)
            {
                case 1:
                    eventSystem.SetSelectedGameObject(neverSurrender);
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(imDone);
                    break;
            }
        }
    }
}
