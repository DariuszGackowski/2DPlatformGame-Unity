using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorExit : MonoBehaviour
{
    private bool openDoor;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DoorExit>());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) & openDoor)
        {
            MainValuesContainer.scoreOrange = ScoreManager.scoreOrangeAll;
            MainValuesContainer.scoreBlue = ScoreManager.scoreBlueAll;
            MainValuesContainer.scorePurple = ScoreManager.scorePurpleAll;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        openDoor = collision.gameObject.CompareTag("Player") ? true : openDoor;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        openDoor = collision.gameObject.CompareTag("Player") ? true : openDoor;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        openDoor = collision.gameObject.CompareTag("Player") ? false : openDoor;
    }
}
