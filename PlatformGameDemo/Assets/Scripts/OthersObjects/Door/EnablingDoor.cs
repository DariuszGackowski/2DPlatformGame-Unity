using UnityEngine;
public class EnablingDoor : MonoBehaviour
{
    public GameObject restartScreen, deathScreen, mainMenuPauseScreen, optionsMenuScreen, house;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<EnablingDoor>());
    }
    private void Update()
    {
        house.GetComponent<DoorExit>().enabled = house.GetComponent<BoxCollider2D>().enabled = restartScreen.activeSelf || deathScreen.activeSelf || mainMenuPauseScreen.activeSelf || optionsMenuScreen.activeSelf ? false : true;
    }
}
