using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InfoController : MonoBehaviour
{
    public static bool blockDecisions;
    public GameObject areaOfPoints;
    public TextMeshProUGUI newCherry, noCherry, moreInfo, endedDrawing;
    private float buyingTime;
    private bool newInfo, prizeIsAdded;
    void Update()
    {
        if (endedDrawing.enabled)
        {
            if (!prizeIsAdded)
                PrizeAdding();
        }
        else
            prizeIsAdded = false;
        if (noCherry.enabled || newCherry.enabled || moreInfo.enabled || endedDrawing.enabled)
        {
            buyingTime += Time.deltaTime;
            InfoController.blockDecisions = true;
            if (buyingTime > 2.5f)
                newInfo = true;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || newInfo)
        {
            if (noCherry.enabled || newCherry.enabled || moreInfo.enabled || endedDrawing.enabled)
            {
                buyingTime = 0f;
                InfoController.blockDecisions = endedDrawing.enabled = moreInfo.enabled = newCherry.enabled = noCherry.enabled = false;
            }
            newInfo = false;
        }
    }
    private void PrizeAdding()
    {
        switch (Drawing.randomNumber)
        {
            case 0:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 3;
                AddingPurplePrize.changingTime = true;
                break;
            case 1:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 10;
                AddingPurplePrize.changingTime = true;
                break;
            case 2:
                areaOfPoints.GetComponent<AddingOrangePrize>().valueToChange = 1;
                AddingOrangePrize.changingTime = true;
                break;
            case 3:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 8;
                AddingPurplePrize.changingTime = true;
                break;
            case 4:
                areaOfPoints.GetComponent<AddingBluePrize>().valueToChange = 1;
                AddingBluePrize.changingTime = true;
                break;
            case 5:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 1;
                AddingPurplePrize.changingTime = true;
                break;
            case 6:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 5;
                AddingPurplePrize.changingTime = true;
                break;
            case 7:
                areaOfPoints.GetComponent<AddingPurplePrize>().valueToChange = 7;
                AddingPurplePrize.changingTime = true;
                break;
            case 8:
                if (MainValuesContainer.health < 5)
                {
                    switch (MainValuesContainer.health)
                    {
                        case 1:
                            areaOfPoints.GetComponent<AddingCherryPrize>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[2];
                            break;
                        case 2:
                            areaOfPoints.GetComponent<AddingCherryPrize>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[3];
                            break;
                        case 3:
                            areaOfPoints.GetComponent<AddingCherryPrize>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[4];
                            break;
                        case 4:
                            areaOfPoints.GetComponent<AddingCherryPrize>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[5];
                            break;
                    }
                    AddingCherryPrize.changingTime = true;
                }
                break;
            case 9:
                areaOfPoints.GetComponent<AddingBluePrize>().valueToChange = 2;
                AddingBluePrize.changingTime = true;
                break;
        }
        prizeIsAdded = true;
    }
}
