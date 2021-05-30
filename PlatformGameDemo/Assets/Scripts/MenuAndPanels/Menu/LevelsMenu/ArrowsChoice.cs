using UnityEngine;
using UnityEngine.UI;
public class ArrowsChoice : MonoBehaviour
{
    public GameObject leftArrow, rightArrow, disabledLeftArrow, disabledRightArrow;
    public int numberOfLevel, numberOfSceneLevels;
    private int numberOflevelFromScene;
    private void Update()
    {
        switch (numberOfSceneLevels)
        {
            case 1:
                numberOflevelFromScene = LevelsMenuSelection.selectedOption;
                break;
            case 2:
                numberOflevelFromScene = LevelsMenuSelectionTwo.selectedOption;
                break;
        }
        if (gameObject.GetComponent<Button>().interactable)
        {
            disabledLeftArrow.GetComponent<SpriteRenderer>().enabled = disabledRightArrow.GetComponent<SpriteRenderer>().enabled = disabledRightArrow.GetComponent<SpriteRenderer>().enabled & disabledLeftArrow.GetComponent<SpriteRenderer>().enabled ? false : disabledLeftArrow.GetComponent<SpriteRenderer>().enabled = disabledRightArrow.GetComponent<SpriteRenderer>().enabled;
            leftArrow.GetComponent<SpriteRenderer>().enabled = rightArrow.GetComponent<SpriteRenderer>().enabled = numberOflevelFromScene == numberOfLevel ? true : false;
        }
        else
            disabledLeftArrow.GetComponent<SpriteRenderer>().enabled = disabledRightArrow.GetComponent<SpriteRenderer>().enabled = numberOflevelFromScene == numberOfLevel ? true : false;
    }
}

