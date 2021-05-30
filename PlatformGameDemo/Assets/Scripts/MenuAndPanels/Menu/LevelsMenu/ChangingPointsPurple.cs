using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChangingPointsPurple : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIPurplePoints;
    public Button chosenButton;
    public Image imagePurple;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, subtractTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (ChangingPointsPurple.changingTime)
        {
            if (!valueIsPublic)
            {
                partValue = valueToChange;
                valueIsPublic = true;
            }
            animator.gameObject.SetActive(true);
            animator.gameObject.GetComponent<SpriteRenderer>().enabled = animator.enabled = true;
            imagePurple.enabled = false;
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                textMeshProUGUIPurplePoints.enabled = chosenButton.interactable = true;
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                textMeshProUGUIPurplePoints.enabled = chosenButton.interactable = false;
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIPurplePoints.enabled = chosenButton.interactable = true;
                enabledTime = 0;
            }
            subtractTime += Time.deltaTime;
            if (subtractTime > 0f & !smallChangingPartOne)
            {
                int valueToSubtract = 1;
                partValue -= valueToSubtract;
                MainValuesContainer.scorePurple -= valueToSubtract;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartOne = true;
            }
            if (subtractTime > 1f & !smallChangingPartTwo)
            {
                int valueToSubtract = partValue / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scorePurple -= valueToSubtract;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartTwo = true;
            }
            if (subtractTime > 2f & !smallChangingPartThree)
            {
                int valueToSubtract = partValue * 2 / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scorePurple -= valueToSubtract;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartThree = true;
            }
            if (subtractTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scorePurple -= partValue;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartFour = true;
                ChangingPointsPurple.resetTime = true;
                ChangingPointsPurple.changingTime = false;
            }
        }
        else if (!ChangingPointsPurple.changingTime & ChangingPointsPurple.resetTime)
        {
            textMeshProUGUIPurplePoints.enabled = chosenButton.interactable = imagePurple.enabled = true; 
            enabledTime = subtractTime = 0f;
            animator.gameObject.SetActive(false);
            ChangingPointsPurple.resetTime = smallChangingPartOne = smallChangingPartTwo = smallChangingPartThree = smallChangingPartFour = valueIsPublic = animator.enabled = animator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
