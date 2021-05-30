using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AddingBluePrize : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIBluePoints;
    public Image imageBlue;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, additionTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (AddingBluePrize.changingTime)
        {
            if (!valueIsPublic)
            {
                partValue = valueToChange;
                valueIsPublic = true;
            }
            animator.gameObject.SetActive(true);
            animator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            imageBlue.enabled = false;
            animator.enabled = true;
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                textMeshProUGUIBluePoints.enabled = true;
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                textMeshProUGUIBluePoints.enabled = false;
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIBluePoints.enabled = true;
                enabledTime = 0;
            }
            additionTime += Time.deltaTime;
            if (additionTime > 0f & !smallChangingPartOne)
            {
                int valueToAdd = 1;
                partValue -= valueToAdd;
                MainValuesContainer.scoreBlue += valueToAdd;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartOne = true;
            }
            if (additionTime > 1f & !smallChangingPartTwo)
            {
                int valueToAdd = partValue / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scoreBlue += valueToAdd;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartTwo = true;
            }
            if (additionTime > 2f & !smallChangingPartThree)
            {
                int valueToAdd = partValue * 2 / 5;
                partValue -= valueToAdd;
                MainValuesContainer.scoreBlue += valueToAdd;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                smallChangingPartThree = true;
            }
            if (additionTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scoreBlue += partValue;
                textMeshProUGUIBluePoints.text = "x" + MainValuesContainer.scoreBlue.ToString();
                AddingBluePrize.resetTime = smallChangingPartFour = true;
                AddingBluePrize.changingTime = false;
            }
        }
        else if (!AddingBluePrize.changingTime & AddingBluePrize.resetTime)
        {
            textMeshProUGUIBluePoints.enabled = imageBlue.enabled = true;
            enabledTime = additionTime = 0f;
            animator.gameObject.SetActive(false);
            AddingBluePrize.resetTime = animator.gameObject.GetComponent<SpriteRenderer>().enabled = animator.enabled = valueIsPublic = smallChangingPartFour = smallChangingPartThree = smallChangingPartTwo = smallChangingPartOne = false;
        }
    }
}