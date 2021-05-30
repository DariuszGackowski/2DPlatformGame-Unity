using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LongArrowSelectedTwo : MonoBehaviour
{
    public LevelsMenuSelectionTwo levelsMenuSelectionTwo;
    public GameObject ordinaryArrow;
    public EventSystem eventSystem;
    private void OnMouseExit()
    {
        levelsMenuSelectionTwo.enabled = true;
        ordinaryArrow.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (!ChangingPointsBlue.changingTime)
            SceneManager.LoadScene("Levels");
    }
}
