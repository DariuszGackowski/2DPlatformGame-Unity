using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChangingLifePoints : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public TextMeshProUGUI textMeshProUGUIOrangePoints;
    public GameObject newCherry;
    public Image imageOrange;
    public Animator animator;
    public int valueToChange;
    private float enabledTime, subtractTime;
    private int partValue;
    private bool smallChangingPartOne, smallChangingPartTwo, smallChangingPartThree, smallChangingPartFour, valueIsPublic;
    void Update()
    {
        if (ChangingLifePoints.changingTime)
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
            {
                textMeshProUGUIOrangePoints.enabled = true;
                newCherry.SetActive(true);
            }
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
            {
                textMeshProUGUIOrangePoints.enabled = false;
                newCherry.SetActive(false);
            }
            else if (enabledTime > 0.5f)
            {
                textMeshProUGUIOrangePoints.enabled = true;
                newCherry.SetActive(true);
                enabledTime = 0;
            }
            subtractTime += Time.deltaTime;
            if (subtractTime > 0f & !smallChangingPartOne)
            {
                int valueToSubtract = 1;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreOrange -= valueToSubtract;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartOne = true;
            }
            if (subtractTime > 1f & !smallChangingPartTwo)
            {
                int valueToSubtract = partValue / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreOrange -= valueToSubtract;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartTwo = true;
            }
            if (subtractTime > 2f & !smallChangingPartThree)
            {
                int valueToSubtract = partValue * 2 / 5;
                partValue -= valueToSubtract;
                MainValuesContainer.scoreOrange -= valueToSubtract;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                smallChangingPartThree = true;
            }
            if (subtractTime > 2.5f & !smallChangingPartFour)
            {
                MainValuesContainer.scoreOrange -= partValue;
                textMeshProUGUIOrangePoints.text = "x" + MainValuesContainer.scoreOrange.ToString();
                ChangingLifePoints.resetTime = smallChangingPartFour = true;
                ChangingLifePoints.changingTime = false;
            }
        }
        else if (!ChangingLifePoints.changingTime & ChangingLifePoints.resetTime)
        {
            imageOrange.enabled = textMeshProUGUIOrangePoints.enabled = true;
            subtractTime = enabledTime = 0f;
            animator.gameObject.SetActive(false);
            newCherry.SetActive(true);
            MainValuesContainer.health += 1;
            ChangingLifePoints.resetTime = smallChangingPartOne = smallChangingPartTwo = smallChangingPartThree = smallChangingPartFour = valueIsPublic = animator.enabled = animator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
