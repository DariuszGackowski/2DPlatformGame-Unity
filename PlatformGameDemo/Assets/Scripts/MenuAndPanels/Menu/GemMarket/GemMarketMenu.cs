using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GemMarketMenu : MonoBehaviour
{
    public GameObject areaOfPoints;
    public TextMeshProUGUI newCherry, noCherry, moreInfo;
    public void BuyCherry()
    {
        if (!InfoController.blockDecisions & !Drawing.startDraw)
            if (MainValuesContainer.scoreOrange >= 10 & MainValuesContainer.health < 5)
            {
                areaOfPoints.GetComponent<ChangingLifePoints>().valueToChange = 5;
                switch (MainValuesContainer.health)
                {
                    case 1:
                        areaOfPoints.GetComponent<ChangingLifePoints>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[1];
                        break;
                    case 2:
                        areaOfPoints.GetComponent<ChangingLifePoints>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[2];
                        break;
                    case 3:
                        areaOfPoints.GetComponent<ChangingLifePoints>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[3];
                        break;
                    case 4:
                        areaOfPoints.GetComponent<ChangingLifePoints>().newCherry = GameObject.Find("AreaOfPoints").GetComponent<ReadPointsBase>().cherries[4];
                        break;
                }
                newCherry.enabled = ChangingLifePoints.changingTime = true;
            }
            else if (MainValuesContainer.health == 5)
                noCherry.enabled = true;
            else if (MainValuesContainer.scoreOrange < 10)
                moreInfo.enabled = true;
    }
    public void GemExchange()
    {
        if (!InfoController.blockDecisions & !Drawing.startDraw)
            SceneManager.LoadScene("GemExchange");
    }
    public void DrawLots()
    {
        if (!InfoController.blockDecisions & !Drawing.startDraw)
            if (MainValuesContainer.scorePurple >= 5)
            {
                areaOfPoints.GetComponent<ChangingDrawPoints>().valueToChange = 5;
                Drawing.startDraw = ChangingDrawPoints.changingTime = true;
            }
            else if (MainValuesContainer.scorePurple < 5)
                moreInfo.enabled = true;
    }
    public void BackToBase()
    {
        if (!InfoController.blockDecisions & !Drawing.startDraw)
            SceneManager.LoadScene("BaseOfLevels");
    }
}
