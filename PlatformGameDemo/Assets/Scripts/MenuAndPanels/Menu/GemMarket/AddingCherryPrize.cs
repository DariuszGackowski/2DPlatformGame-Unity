using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AddingCherryPrize : MonoBehaviour
{
    public static bool changingTime, resetTime;
    public GameObject newCherry;
    private float enabledTime, subtractTime;
    void Update()
    {
        if (AddingCherryPrize.changingTime)
        {
            enabledTime += Time.deltaTime;
            if (enabledTime <= 0.25f)
                newCherry.SetActive(true);
            else if (enabledTime > 0.25f & enabledTime <= 0.5f)
                newCherry.SetActive(false);
            else if (enabledTime > 0.5f)
            {
                newCherry.SetActive(true);
                enabledTime = 0;
            }
            subtractTime += Time.deltaTime;
            if (subtractTime > 2.5f)
            {
                AddingCherryPrize.resetTime = true;
                AddingCherryPrize.changingTime = false;
            }
        }
        else if (!AddingCherryPrize.changingTime & AddingCherryPrize.resetTime)
        {
            subtractTime = enabledTime = 0f;
            newCherry.SetActive(true);
            MainValuesContainer.health += 1;
            AddingCherryPrize.resetTime = false;
        }
    }
}
