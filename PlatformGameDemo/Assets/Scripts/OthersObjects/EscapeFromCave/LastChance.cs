using UnityEngine;
public class LastChance : MonoBehaviour
{
    public static bool gateIsUnlock = false;
    private int nummberOfCombination;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<LastChance>());
        nummberOfCombination = nummberOfCombination == 0 ? Random.Range(1, 3) : nummberOfCombination;
        if (nummberOfCombination == 1)
            nummberOfCombination = Random.Range(2, 3);
        else if (nummberOfCombination == 2)
        {
            nummberOfCombination = Random.Range(3, 4);
            if (nummberOfCombination == 4)
                nummberOfCombination = 1;
        }
        else if (nummberOfCombination == 3)
            nummberOfCombination = Random.Range(1, 2);
    }
    private void Update()
    {
        CheckingCombination(nummberOfCombination);
    }
    private void CheckingCombination(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                LastChance.gateIsUnlock = HeaverOne.heaverOneIsReady & HeaverTwo.heaverTwoIsReady & !HeaverThree.heaverThreeIsReady ? true : false;
                break;
            case 2:
                LastChance.gateIsUnlock = HeaverOne.heaverOneIsReady & !HeaverTwo.heaverTwoIsReady & HeaverThree.heaverThreeIsReady ? true : false;
                break;
            case 3:
                LastChance.gateIsUnlock = !HeaverOne.heaverOneIsReady & HeaverTwo.heaverTwoIsReady & HeaverThree.heaverThreeIsReady ? true : false;
                break;
        }
    }
}