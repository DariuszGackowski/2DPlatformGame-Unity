using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChangingPointsBlue : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIBluePoints;
    public Button chosenButton;
    public Image imageBlue;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, subtractTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (ChangingPointsBlue.changingTime)
        {
            if (!valueIsPublic)
            {
                partValue = valueToChange;
                valueIsPublic = true;
            }
            animator.gameObject.SetActive(true);
            animator.gameObject.GetComponent<SpriteRenderer>().enabled = animator.enabled = true;
            imageBlue.enabled = false;
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                textMeshProUGUIBluePoints.enabled = chosenButton.interactable = true;
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                textMeshProUGUIBluePoints.enabled = chosenButton.interactable = false;
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIBluePoints.enabled = chosenButton.interactable = true;
                enabledTime = 0;
            }
            subtractTime += Time.deltaTime;
            if (subtractTime > 0f & !smallChangingPartOne)
            {
                int valueToSubtract = 1;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreBlue -= valueToSubtract;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartOne = true;
            }
            if (subtractTime > 1f & !smallChangingPartTwo)
            {
                int valueToSubtract = partValue / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreBlue -= valueToSubtract;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartTwo = true;
            }
            if (subtractTime > 2f & !smallChangingPartThree)
            {
                int valueToSubtract = partValue * 2 / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreBlue -= valueToSubtract;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartThree = true;
            }
            if (subtractTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scoreBlue -= partValue;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartFour = true;
                ChangingPointsBlue.resetTime = true;
                ChangingPointsBlue.changingTime = false;
            }
        }
        else if (!ChangingPointsBlue.changingTime & ChangingPointsBlue.resetTime)
        {
            textMeshProUGUIBluePoints.enabled = chosenButton.interactable = imageBlue.enabled = true;
            enabledTime = subtractTime = 0f;
            animator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            animator.gameObject.SetActive(false);
            ChangingPointsBlue.resetTime = smallChangingPartOne = smallChangingPartTwo = smallChangingPartThree = smallChangingPartFour = valueIsPublic = animator.enabled = false;
        }
    }
}
