using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LongArrowsSelected : MonoBehaviour
{
    public LevelsMenuSelection levelsMenuSelection;
    public GameObject ordinaryArrow;
    public EventSystem eventSystem;
    private void OnMouseExit()
    {
        levelsMenuSelection.enabled = true;
        ordinaryArrow.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (!ChangingPointsPurple.changingTime)
            SceneManager.LoadScene("NextLevels");
    }
}
