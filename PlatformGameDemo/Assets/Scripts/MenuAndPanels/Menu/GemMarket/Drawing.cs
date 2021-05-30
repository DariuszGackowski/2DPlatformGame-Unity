using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public static bool startDraw;
    public static int randomNumber;
    public List<GameObject> middleListOfObjects = new List<GameObject>();
    public List<GameObject> endListOfObjects = new List<GameObject>();
    public List<GameObject> listOfMohicans = new List<GameObject>();
    public GameObject[] gameObjectsArray, numbersArray;
    public GameObject questionMarkFirstPrefab, questionMarkSecondPrefab, questionMarkFirst, questionMarkSecond, lastMohican;
    public Transform destroyPositionFirst, instantiatePositionFirst, middlePositionFirst, destroyPositionSecnond, instantiatePositionSecond, middlePositionSecond;
    public TextMeshProUGUI endedDrawing;
    private GameObject[] mainArray;
    private GameObject questionMark;
    private Transform destroyPosition, middlePosition, instantiatePosition;
    private float mainVelocity, parttimeToEndHurtAnimationVelocity;
    private int i, j, k;
    private bool firstMove, nextMove, nextSitting = true, nextRound = true, infoIsEnabled, startDrawing;
    private readonly float firstVelocity = 15f, secondVelocity = 12f, thirdVelocity = 9f, fourthVelocity = 6f, fifthVelocity = 3f, endVelocity = 1f;
    private void Update()
    {
        if (lastMohican != null && lastMohican.transform.position.y > middlePosition.position.y)
        {
            lastMohican.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            k++;
            i = j = 0;
            mainVelocity = 15f;
            nextMove = firstMove = false;
            middleListOfObjects.Clear();
            endListOfObjects.Clear();
            Drawing.startDraw = nextSitting = nextRound = true;
            listOfMohicans.Add(lastMohican);
            lastMohican = questionMark = null;
        }
        if (Drawing.startDraw & k < 2)
        {
            if (!startDrawing)
            {
                Drawing.randomNumber = Random.Range(0, 10);
                startDrawing = true;
            }
            if (nextRound)
            {
                switch (k)
                {
                    case 0:
                        mainArray = gameObjectsArray;
                        mainVelocity = firstVelocity;
                        questionMark = questionMarkSecond;
                        destroyPosition = destroyPositionSecnond;
                        middlePosition = middlePositionSecond;
                        instantiatePosition = instantiatePositionSecond;
                        break;
                    case 1:
                        mainArray = numbersArray;
                        mainVelocity = firstVelocity;
                        questionMark = questionMarkFirst;
                        destroyPosition = destroyPositionFirst;
                        middlePosition = middlePositionFirst;
                        instantiatePosition = instantiatePositionFirst;
                        break;
                }
                nextRound = false;
            }
            if (lastMohican != null && lastMohican.transform.position.y > middlePosition.position.y)
                lastMohican.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            if (questionMark != null && questionMark.GetComponent<TextMeshProUGUI>().enabled & questionMark.transform.position.y > destroyPosition.position.y)
                Destroy(questionMark);
            nextMove = IsThisTrue(middleListOfObjects, endListOfObjects, middlePosition) ? false : nextMove;
            Destroy(TimeToDestroy(endListOfObjects, destroyPosition));
            TimeToDestroy(endListOfObjects, destroyPosition);
            if (!firstMove)
            {
                questionMark.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, mainVelocity);
                firstMove = true;
            }
            if (!nextMove)
            {
                if (nextSitting)
                    switch (j)
                    {
                        case 0:
                            parttimeToEndHurtAnimationVelocity = Drawing.randomNumber == 0 ? (firstVelocity - secondVelocity) / 10 : (firstVelocity - secondVelocity) / Drawing.randomNumber;
                            nextSitting = false;
                            break;
                        case 1:
                            parttimeToEndHurtAnimationVelocity = (secondVelocity - thirdVelocity) / 10;
                            nextSitting = false;
                            break;
                        case 2:
                            parttimeToEndHurtAnimationVelocity = (thirdVelocity - fourthVelocity) / 10;
                            nextSitting = false;
                            break;
                        case 3:
                            parttimeToEndHurtAnimationVelocity = (fourthVelocity - fifthVelocity) / 10;
                            nextSitting = false;
                            break;
                        case 4:
                            parttimeToEndHurtAnimationVelocity = (fifthVelocity - endVelocity) / 10;
                            nextSitting = false;
                            break;
                    }
                if (j < 5)
                {
                    if (Drawing.randomNumber != 0 & i == Drawing.randomNumber - 1 || Drawing.randomNumber == 0 & i == 9)
                    {
                        j++;
                        nextSitting = true;
                    }
                    GameObject newGameObject = Instantiate(mainArray[i], instantiatePosition.position, Quaternion.identity);
                    newGameObject.transform.SetParent(GameObject.Find("DrawQuestionMarksCanvas").transform);
                    AddToList(middleListOfObjects, newGameObject);
                    newGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, mainVelocity);
                    mainVelocity -= parttimeToEndHurtAnimationVelocity;
                    i++;
                    i = i > 9 ? 0 : i;
                }
                else if (j == 5 & i != Drawing.randomNumber)
                {
                    GameObject newGameObject = Instantiate(mainArray[i], instantiatePosition.position, Quaternion.identity);
                    newGameObject.transform.SetParent(GameObject.Find("DrawQuestionMarksCanvas").transform);
                    AddToList(middleListOfObjects, newGameObject);
                    newGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, mainVelocity);
                    mainVelocity -= parttimeToEndHurtAnimationVelocity;
                    i++;
                    i = i > 9 ? 0 : i;
                }
                else if (j == 5 & i == Drawing.randomNumber)
                {
                    GameObject newGameObject = Instantiate(mainArray[i], instantiatePosition.position, Quaternion.identity);
                    newGameObject.transform.SetParent(GameObject.Find("DrawQuestionMarksCanvas").transform);
                    AddToList(middleListOfObjects, newGameObject);
                    newGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mainVelocity);
                    lastMohican = newGameObject;
                    j++;
                }
                nextMove = true;
            }
        }
        else if (Drawing.startDraw & k == 2)
        {
            GameObject questionGameObject = Instantiate(questionMarkFirstPrefab, new Vector3(middlePositionFirst.position.x + 0.032f, middlePositionFirst.position.y, 0f), Quaternion.identity);
            questionMarkFirst = questionGameObject;
            questionGameObject.transform.SetParent(GameObject.Find("DrawQuestionMarksCanvas").transform);
            questionGameObject.GetComponent<RectTransform>().position = new Vector3(questionGameObject.GetComponent<RectTransform>().position.x, questionGameObject.GetComponent<RectTransform>().position.y, 7f);
            questionGameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            questionGameObject.SetActive(false);
            questionGameObject = Instantiate(questionMarkSecondPrefab, new Vector3(middlePositionSecond.position.x + 0.032f, middlePositionSecond.position.y, 0f), Quaternion.identity);
            questionMarkSecond = questionGameObject;
            questionGameObject.transform.SetParent(GameObject.Find("DrawQuestionMarksCanvas").transform);
            questionGameObject.GetComponent<RectTransform>().position = new Vector3(questionGameObject.GetComponent<RectTransform>().position.x, questionGameObject.GetComponent<RectTransform>().position.y, 7f);
            questionGameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            questionGameObject.SetActive(false);
            infoIsEnabled = endedDrawing.enabled = true;
            Drawing.startDraw = false;
        }
        if (!endedDrawing.enabled & infoIsEnabled)
        {
            foreach (GameObject gameObject in listOfMohicans)
                Destroy(gameObject);
            listOfMohicans.Clear();
            questionMarkFirst.SetActive(true);
            questionMarkSecond.SetActive(true);
            i = j = k = 0;
            infoIsEnabled = startDrawing = false;
        }
    }
    private bool IsThisTrue(List<GameObject> middleListOfObjects, List<GameObject> endListOfObjects, Transform middlePosition)
    {
        foreach (GameObject gameObject in middleListOfObjects)
            if (gameObject.transform.position.y > middlePosition.position.y)
            {
                AddToList(endListOfObjects, gameObject);
                middleListOfObjects.RemoveAt(middleListOfObjects.Count - 1);
                return true;
            }
        return false;
    }
    private GameObject TimeToDestroy(List<GameObject> endListOfObjects, Transform destroyPosition)
    {
        foreach (GameObject gameObject in endListOfObjects)
            if (gameObject.transform.position.y > destroyPosition.position.y)
            {
                endListOfObjects.RemoveAt(endListOfObjects.Count - 1);
                return gameObject;
            }
        return null;
    }
    private void AddToList(List<GameObject> list, GameObject gameObject)
    {
        List<GameObject> workList = new List<GameObject>();
        for (int i = 0; i < list.Count; i++)
            workList.Add(list[i]);
        list.Clear();
        list.Add(gameObject);
        foreach (GameObject workGameObject in workList)
            list.Add(workGameObject);
    }

}
