using UnityEngine;
public class MainValuesContainerConnection : MonoBehaviour
{
    public static bool MainValuesContainerConnectionIsReady, connectionDone;
    public MainValuesContainerConnection mainValuesContainerConnection;
    public GameObject[] mainValuesContainerObject, cherries = new GameObject[5];
    private bool cherriesAreReady;
    private readonly bool inDungeon = true;
    private void Start()
    {
        cherries[0] = GameObject.Find("/PointsAndScreensSystem/MainCanvas/AreaOfPoints/Cherries/Cherry1");
        cherries[1] = GameObject.Find("/PointsAndScreensSystem/MainCanvas/AreaOfPoints/Cherries/Cherry2");
        cherries[2] = GameObject.Find("/PointsAndScreensSystem/MainCanvas/AreaOfPoints/Cherries/Cherry3");
        cherries[3] = GameObject.Find("/PointsAndScreensSystem/MainCanvas/AreaOfPoints/Cherries/Cherry4");
        cherries[4] = GameObject.Find("/PointsAndScreensSystem/MainCanvas/AreaOfPoints/Cherries/Cherry5");
        cherriesAreReady = true;
        MainValuesContainerConnection.connectionDone = false;
        mainValuesContainerObject = GameObject.FindGameObjectsWithTag("MainValuesContainer");
        if (mainValuesContainerObject.Length > 1)
            for (int i = 1; i < mainValuesContainerObject.Length; i++)
                Destroy(mainValuesContainerObject[i]);
        if (!inDungeon)
            CheckingPoints();
    }
    private void Update()
    {
        if (cherries[0] == null)
            Invoke("Start", 0f);
        #region ConnectionRegion
        if (!MainValuesContainerConnection.connectionDone)
        {
            ScoreManager.scoreManagerConnectionIsReady = true;
            if (ScoreManager.scoreManagerConnectionIsReady == true)
                if (MainValuesContainerConnection.MainValuesContainerConnectionIsReady)
                    if (ScoreManager.scriptIsFinded & cherriesAreReady & ScoreManager.MainValuesContainerConnection != null)
                    {
                        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Invoke("SendingInvoke", 0f);
                        cherriesAreReady = false;
                    }
        }
        #endregion
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void CheckingPoints()
    {
        if (MainValuesContainer.health == 0)
        {
            MainValuesContainer.health = 3;
            ScoreManager.SetLifePointsCount(cherries, MainValuesContainer.health);
        }
        else
            ScoreManager.SetLifePointsCount(cherries,MainValuesContainer.health);
        ScoreManager.CheckGemScore("1001");
        ScoreManager.CheckGemScore("0011");
        ScoreManager.CheckGemScore("0001");
        MainValuesContainer.checkLifePoints = true;
        EnoughConnexion();
    }
    public static void EnoughConnexion()
    {
        MainValuesContainerConnection.connectionDone = ScoreManager.connectionDone = true;
        PlayerMove.contactWithGround = DetectorGround.onSkewGround = MainValuesContainerConnection.MainValuesContainerConnectionIsReady = ScoreManager.scoreManagerConnectionIsReady = false;
        ScoreManager.MainValuesContainerConnection = null;
    }
}
