using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AddingOrangePrize : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIOrangePoints;
    public Image imageOrange;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, additionTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (AddingOrangePrize.changingTime)
        {
            if (!valueIsPublic)
            {
                partValue = valueToChange;
                valueIsPublic = true;
            }
            animator.gameObject.SetActive(true);
            animator.enabled = animator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            imageOrange.enabled = false;
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                textMeshProUGUIOrangePoints.enabled = true;
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                textMeshProUGUIOrangePoints.enabled = false;
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIOrangePoints.enabled = true;
                enabledTime = 0;
            }
            additionTime += Time.deltaTime;
            if (additionTime > 0f & !smallChangingPartOne)
            {
                int valueToAdd = 1;
                partValue -= valueToAdd;
                MainValuesContainer.scoreOrange += valueToAdd;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartOne = true;
            }
            if (additionTime > 1f & !smallChangingPartTwo)
            {
                int valueToAdd = partValue / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scoreOrange += valueToAdd;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartTwo = true;
            }
            if (additionTime > 2f & !smallChangingPartThree)
            {
                int valueToAdd = partValue * 2 / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scoreOrange += valueToAdd;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartThree = true;
            }
            if (additionTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scoreOrange += partValue;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                AddingOrangePrize.resetTime = smallChangingPartFour = true;
                AddingOrangePrize.changingTime = false;
            }
        }
        else if (!AddingOrangePrize.changingTime & AddingOrangePrize.resetTime)
        {
            textMeshProUGUIOrangePoints.enabled = imageOrange.enabled = true;
            additionTime = enabledTime = 0f;
            animator.gameObject.SetActive(false);
            AddingOrangePrize.resetTime = animator.gameObject.GetComponent<SpriteRenderer>().enabled = animator.enabled = valueIsPublic = smallChangingPartFour = smallChangingPartThree = smallChangingPartTwo = smallChangingPartOne = false;
        }
    }
}
