using Assets.Scripts.Important;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ExchangeRates : MonoBehaviour
{
    public static bool timeToUpdate;
    public TextMeshProUGUI orangeToBlue, orangeToPurple, blueToPurple;
    private void Update()
    {
        if (timeToUpdate)
        { 
            LocalUpdate();
        }
    }
    private void LocalUpdate()
    {
        
    }
    private void OrangeUpdate()
    {

    }
    public static float GetNumberOfGems(List<TwoValues> mainList)
    {
        float standardNumber = 0f, bossNumber = 0f, caveNumber = 0f, fallenNumber = 0f, numberOfAllGem = 118f;
        bool standardWasChecked = false, bossWasChecked = false, caveWasChecked = false, fallenWasChecked = false;
        int numberOfReadyLevels = 0;
        foreach (TwoValues objectGem in mainList)
        {                             
            switch (objectGem.NameOfLevel.ToString())
            {
                case "Standard":
                    standardNumber++;
                    if (!standardWasChecked)
                    {
                        numberOfReadyLevels++;
                        standardWasChecked = true;
                    }
                    break;
                case "Boss'sOffice":
                    bossNumber++;
                    if (!bossWasChecked)
                    {
                        numberOfReadyLevels++;
                        bossWasChecked = true;
                    }
                    break;
                case "CaveOfExtinction":
                    caveNumber++;
                    if (!caveWasChecked)
                    {
                        numberOfReadyLevels++;
                        caveWasChecked = true;
                    }
                    break;
                case "FallenBridges":
                    fallenNumber++;
                    if (!fallenWasChecked)
                    {
                        numberOfReadyLevels++;
                        fallenWasChecked = true;
                    }
                    break;
            }
        }
        float rate = (19 / standardNumber + 26 / bossNumber + 30 / caveNumber + 43 / fallenNumber) / numberOfReadyLevels;
        if (standardWasChecked)
        {
            numberOfAllGem -= 19;
            standardWasChecked = false;
        }
        if (bossWasChecked)
        {
            numberOfAllGem -= 26;
            bossWasChecked = false;
        }
        if (caveWasChecked)
        {
            numberOfAllGem -= 30;
            caveWasChecked = false;
        }
        if (fallenWasChecked)
        {
            numberOfAllGem -= 43;
            fallenWasChecked = false;
        }
        return 0f;
    }
}
