using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Assets.Scripts.Important;
public class GeneratingColors : MonoBehaviour
{
    public List<int> listOfGemAreas, orangeGemsPrivateList, blueGemsPrivateList, purpleGemsPrivateList;
    public GameObject[] listOfAllGems, listOfBounceGems, listOfOrdinaryGems;
    public Color orange, blue, purple;
    private Color NewColor()
    {
        int numberOfColor = Random.Range(1, 9);
        if (numberOfColor == 1)
            return orange;
        else if (numberOfColor == 2)
            return blue;
        else if (numberOfColor == 3)
            return blue;
        else if (numberOfColor == 4)
            return purple;
        else if (numberOfColor == 5)
            return purple;
        else if (numberOfColor == 6)
            return purple;
        else if (numberOfColor == 7)
            return purple;
        else
            return purple;
    }
    private void FindingAllAreas()
    {
        foreach (GameObject gameObject in listOfAllGems)
        {
            int numberOfArea = gameObject.GetComponent<Gem>().numberOfArea;
            bool areaWasAdded = false;
            foreach (int item in listOfGemAreas)
                areaWasAdded = numberOfArea == item ? true : areaWasAdded;
            if (!areaWasAdded)
                listOfGemAreas.Add(numberOfArea);
        }
    }
    private void Start()
    {
        listOfOrdinaryGems = GameObject.FindGameObjectsWithTag("Gem");
        listOfBounceGems = GameObject.FindGameObjectsWithTag("GemBounce");
        listOfAllGems = listOfOrdinaryGems.Concat(listOfBounceGems).ToArray();
        FindingAllAreas();
        #region ProceduralGenerateColorsOfGem
        if (!MainValuesContainer.CheckMyList(SceneManager.GetActiveScene().name))
        {
            foreach (int value in listOfGemAreas)
            {
                List<GameObject> gameObjectsList = new List<GameObject>();
                foreach (GameObject gameObject in listOfAllGems)
                    if (value == gameObject.GetComponent<Gem>().numberOfArea)
                        gameObjectsList.Add(gameObject);
                Color color = NewColor();
                foreach (GameObject gameObject in gameObjectsList)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = color;
                    if (Gem.ColorCode(color) == "1001")
                    {
                        if (!orangeGemsPrivateList.Contains(value))
                            orangeGemsPrivateList.Add(value);
                    }
                    else if (Gem.ColorCode(color) == "0011")
                    {
                        if (!blueGemsPrivateList.Contains(value))
                            blueGemsPrivateList.Add(value);
                    }
                    else if (Gem.ColorCode(color) == "0001")
                    {
                        if (!purpleGemsPrivateList.Contains(value))
                            purpleGemsPrivateList.Add(value);
                    }
                }
            }
            MainValuesContainer.listOfReadyLevels.Add(SceneManager.GetActiveScene().name);
            MainValuesContainer.selectedNumbersForLifePoints = false;
        }
    }
    #endregion
    private void Update()
    {
        if (!MainValuesContainer.selectedNumbersForLifePoints)
        {
            TwoValues.InscribeToMainList(MainValuesContainer.orangeGems, orangeGemsPrivateList, SceneManager.GetActiveScene().name);
            TwoValues.InscribeToMainList(MainValuesContainer.blueGems, blueGemsPrivateList, SceneManager.GetActiveScene().name);
            TwoValues.InscribeToMainList(MainValuesContainer.purpleGems, purpleGemsPrivateList, SceneManager.GetActiveScene().name);
            MainValuesContainer.selectedNumbersForLifePoints = true;
        }
    }
}

