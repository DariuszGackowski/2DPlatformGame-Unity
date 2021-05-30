using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AddingPurplePrize : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIPurplePoints;
    public Image imagePurple;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, additionTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (AddingPurplePrize.changingTime)
        {
            if (!valueIsPublic)
            {
                partValue = valueToChange;
                valueIsPublic = true;
            }
            animator.gameObject.SetActive(true);
            animator.enabled = animator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            imagePurple.enabled = false;
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                textMeshProUGUIPurplePoints.enabled = true;
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                textMeshProUGUIPurplePoints.enabled = false;
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIPurplePoints.enabled = true;
                enabledTime = 0;
            }
            additionTime += Time.deltaTime;
            if (additionTime > 0f & !smallChangingPartOne)
            {
                int valueToAdd = 1;
                partValue -= valueToAdd;
                MainValuesContainer.scorePurple += valueToAdd;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartOne = true;
            }
            if (additionTime > 1f & !smallChangingPartTwo)
            {
                int valueToAdd = partValue / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scorePurple += valueToAdd;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartTwo = true;
            }
            if (additionTime > 2f & !smallChangingPartThree)
            {
                int valueToAdd = partValue * 2 / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scorePurple += valueToAdd;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                smallChangingPartThree = true;
            }
            if (additionTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scorePurple += partValue;
                textMeshProUGUIPurplePoints.text = "x" + MainValuesContainer.scorePurple.ToString();
                AddingPurplePrize.resetTime = smallChangingPartFour = true;
                AddingPurplePrize.changingTime = false;
            }
        }
        else if (!AddingPurplePrize.changingTime & AddingPurplePrize.resetTime)
        {
            imagePurple.enabled = textMeshProUGUIPurplePoints.enabled = true;
            additionTime = enabledTime = 0f;
            animator.gameObject.SetActive(false);
            AddingPurplePrize.resetTime = animator.gameObject.GetComponent<SpriteRenderer>().enabled = animator.enabled = valueIsPublic = smallChangingPartFour = smallChangingPartThree = smallChangingPartTwo = smallChangingPartOne = false;
        }
    }
}
