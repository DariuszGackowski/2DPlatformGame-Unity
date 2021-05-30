using UnityEngine;
using TMPro;
using System.Linq;
using Assets.Scripts.Important;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static List<MonoBehaviour> listAllScripts = new List<MonoBehaviour>();
    public static List<VelocitiesOfGameObjects> velocitiesOfGameObjects = new List<VelocitiesOfGameObjects>();
    public static List<VelocitiesOfGameObjectsWithParent> velocitiesOfGameObjectsWithParent = new List<VelocitiesOfGameObjectsWithParent>();
    public static GameObject[] listAllEnemies, listAllStaticObjects, listAllBounceGems, listAllPlatforms, listAllCherries, listAllOrdinaryGems, listAllQuestionMarks, playerList, listAllCharacters, listAllBridges, listAllSpikes, listCherries = new GameObject[5];
    public static MainValuesContainerConnection MainValuesContainerConnection;
    public static GameObject staticAreaOfPoints, staticMinimap;
    public static TextMeshProUGUI staticTextMeshProUGUIGemOrange, staticTextMeshProUGUIGemBlue, staticTextMeshProUGUIGemPurple;
    public static Animator animatorPlayer;
    public static RigidbodyConstraints2D playerRigidbodyConstraints2D;
    public static float speedOfAnimator = 1f;
    public static int scoreOrangeCurrentScene, scoreBlueCurrentScene, scorePurpleCurrentScene, scoreOrangeAll, scoreBlueAll, scorePurpleAll;
    public static bool connectionDone, scoreManagerConnectionIsReady, invokeSent, scriptIsFinded;
    public DeathScreenSelection deathScreenSelection;
    public TextMeshProUGUI textMeshProUGUIGemOrange, textMeshProUGUIGemBlue, textMeshProUGUIGemPurple;
    public GameObject[] cherries = new GameObject[5];
    public GameObject deathScreenObject, player, areaOfPoints, minimap;
    private GameObject backgroundMusic;
    private bool objectIsFinded;
    private readonly bool inDungeon = true;
    private void Start()
    {
        ScoreManager.invokeSent = ScoreManager.connectionDone = false;
        #region ConvertingPublicToStatic
        for (int i = 0; i <= 4; i++)
            ScoreManager.listCherries[i] = cherries[i];
        ScoreManager.staticTextMeshProUGUIGemOrange = textMeshProUGUIGemOrange;
        ScoreManager.staticTextMeshProUGUIGemBlue = textMeshProUGUIGemBlue;
        ScoreManager.staticTextMeshProUGUIGemPurple = textMeshProUGUIGemPurple;
        ScoreManager.animatorPlayer = player.GetComponent<Animator>();
        ScoreManager.staticAreaOfPoints = areaOfPoints;
        ScoreManager.staticMinimap = minimap;
        #endregion
        Destroy(GameObject.Find("ChoosenLevelContainer"));
        ScoreManager.SetLifePointsCount(ScoreManager.listCherries, MainValuesContainer.health);
        if (!inDungeon)
            SendingInvoke();
        if (!objectIsFinded)
        {
            backgroundMusic = GameObject.Find("BackgroundMusic");
            if (backgroundMusic == null)
            {
                BackgroundMusic.muting = false;
                objectIsFinded = true;
            }
            else
                BackgroundMusic.muting = true;
        }
    }
    private void Update()
    {
        #region ConnectionRegion
        if (!ScoreManager.connectionDone)
        {
            MainValuesContainerConnection.MainValuesContainerConnectionIsReady = true;
            if (MainValuesContainerConnection.MainValuesContainerConnectionIsReady)
                if (ScoreManager.scoreManagerConnectionIsReady)
                {
                    ScoreManager.MainValuesContainerConnection = GameObject.Find("MainValuesContainer").GetComponent<MainValuesContainerConnection>();
                    ScoreManager.scriptIsFinded = true;
                }
        }
        if (player.activeSelf & !ScoreManager.invokeSent)
        {
            player.GetComponent<PlayerMove>().Invoke("FirstMove", 0f);
            ScoreManager.invokeSent = true;
        }
        #endregion
        if (!objectIsFinded)
        {
            backgroundMusic = GameObject.Find("BackgroundMusic");
            if (backgroundMusic == null)
            {
                BackgroundMusic.muting = false;
                objectIsFinded = true;
            }
        }
        if (MainValuesContainer.checkLifePoints)
        {
            if (MainValuesContainer.health <= 0)
            {
                TakeBreak();
                deathScreenObject.SetActive(true);
                deathScreenSelection.enabled = true;
                MainValuesContainer.checkLifePoints = false;
            }
            else if (MainValuesContainer.health > 0)
            {
                if (deathScreenObject.activeSelf)
                {
                    deathScreenSelection.enabled = false;
                    deathScreenObject.SetActive(false);
                }
                if (MainValuesContainer.unfrozeGame)
                {
                    TakeReBreak();
                    MainValuesContainer.unfrozeGame = false;
                }
            }
        }
    }
    private void SendingInvoke()
    {
        MainValuesContainerConnection.Invoke("CheckingPoints", 0f);
    }
    #region ScoreRegion
    public static TextMeshProUGUI ChooseTextMesh(string colorCode)
    {
        if (colorCode == "1001")
            return ScoreManager.staticTextMeshProUGUIGemOrange;
        else if (colorCode == "0011")
            return ScoreManager.staticTextMeshProUGUIGemBlue;
        else
            return ScoreManager.staticTextMeshProUGUIGemPurple;
    }
    public static int AddScore(string colorCode)
    {
        if (colorCode == "1001")
            return ScoreManager.scoreOrangeAll = MainValuesContainer.scoreOrange + ScoreManager.scoreOrangeCurrentScene;
        else if (colorCode == "0011")
            return ScoreManager.scoreBlueAll = MainValuesContainer.scoreBlue + ScoreManager.scoreBlueCurrentScene;
        else
            return ScoreManager.scorePurpleAll = MainValuesContainer.scorePurple + ScoreManager.scorePurpleCurrentScene;
    }
    public static void CheckGemScore(string colorCode)
    {
        ScoreManager.ChooseTextMesh(colorCode).text = "x" + ScoreManager.AddScore(colorCode).ToString();
    }
    public static void ChangeScore(string colorCode)
    {
        if (colorCode == "1001")
        {
            ScoreManager.scoreOrangeCurrentScene += 1;
            ScoreManager.CheckGemScore(colorCode);
        }
        else if (colorCode == "0011")
        {
            ScoreManager.scoreBlueCurrentScene += 1;
            ScoreManager.CheckGemScore(colorCode);
        }
        else if (colorCode == "0001")
        {
            ScoreManager.scorePurpleCurrentScene += 1;
            ScoreManager.CheckGemScore(colorCode);
        }
    }
    #endregion
    #region LifePointsRegion
    public static void ChangeLifePoints(int healthValue)
    {
        MainValuesContainer.health += healthValue;
        SetLifePointsCount(ScoreManager.listCherries, MainValuesContainer.health);
    }
    public static void SetLifePointsCount(GameObject[] cherries, int health)
    {
        for (int i = 0; i < 4; i++)
            if (cherries[i].activeSelf)
                cherries[i].SetActive(false);
        for (int i = 0; i < health; i++)
            cherries[i].SetActive(true);
    }
    #endregion
    #region PauseRegion
    public static void TotalPousing(GameObject gameObject)
    {
        char[] charArray = gameObject.name.ToString().ToCharArray();
        if (charArray[0].ToString() == "F")
            VelocitiesOfGameObjects.AddToList(gameObject, ScoreManager.velocitiesOfGameObjects);
        else if (charArray[0].ToString() == "P")
        {
            VelocitiesOfGameObjects.AddToList(gameObject, ScoreManager.velocitiesOfGameObjects);
            ScoreManager.playerRigidbodyConstraints2D = gameObject.GetComponent<Rigidbody2D>().constraints;
        }
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public static void PartPousing(GameObject gemOrCherry)
    {
        gemOrCherry.GetComponent<Animator>().enabled = false;
    }
    public static void ChapterOfPousing(GameObject gameObject)
    {
        VelocitiesOfGameObjectsWithParent.AddToList(gameObject, ScoreManager.velocitiesOfGameObjectsWithParent);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public static void ChapterOfRePousing(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        VelocitiesOfGameObjectsWithParent.ReadFromList(gameObject, ScoreManager.velocitiesOfGameObjectsWithParent);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }
    public static void TotalRePousing(GameObject gameObject)
    {
        char[] array = gameObject.name.ToString().ToCharArray();
        if (array[0].ToString() == "E" || array[0].ToString() == "G")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
        else if (array[0].ToString() == "O")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (array[0].ToString() == "F")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            VelocitiesOfGameObjects.ReadFromList(gameObject, ScoreManager.velocitiesOfGameObjects);
        }
        else if (array[0].ToString() == "P")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = ScoreManager.playerRigidbodyConstraints2D;
            VelocitiesOfGameObjectsWithParent.ReadFromList(gameObject, ScoreManager.velocitiesOfGameObjects);
        }
    }
    public static void PartRePousing(GameObject gemOrCherry)
    {
        gemOrCherry.GetComponent<Animator>().enabled = true;
    }
    public static void PlatformPousing(GameObject platform)
    {
        platform.transform.Find("MainPlatform").gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled = platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled == true ? false : platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled;
    }
    public static void PlatformRePousing(GameObject platform)
    {
        platform.transform.Find("MainPlatform").gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        platform.transform.Find("MainPlatform").gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled = platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled == false ? true : platform.transform.Find("MainPlatform").gameObject.GetComponent<MovingPlatform>().enabled;
    }
    public static void TakeBreak()
    {
        foreach (MonoBehaviour script in ScoreManager.listAllScripts)
            if (script != null)
                script.enabled = false;
        ScoreManager.listAllSpikes = GameObject.FindGameObjectsWithTag("CeilingSpike");
        foreach (GameObject item in listAllSpikes)
        {
            if (item != null)
                ScoreManager.ChapterOfPousing(item);
        }
        ScoreManager.listAllBridges = GameObject.FindGameObjectsWithTag("FallenBridge");
        foreach (GameObject item in listAllBridges)
        {
            if (item != null)
            {
                int count = 0;
                while (count < item.transform.childCount)
                {
                    ScoreManager.ChapterOfPousing(item.transform.GetChild(count).gameObject);
                    count++;
                }
            }
        }
        ScoreManager.playerList = GameObject.FindGameObjectsWithTag("Player");
        ScoreManager.listAllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        ScoreManager.listAllCharacters = listAllEnemies.Concat(playerList).ToArray();
        foreach (GameObject gameObject in ScoreManager.listAllCharacters)
        {
            if (gameObject != null)
                ScoreManager.TotalPousing(gameObject);
        }
        ScoreManager.listAllCherries = GameObject.FindGameObjectsWithTag("Cherry");
        ScoreManager.listAllQuestionMarks = GameObject.FindGameObjectsWithTag("QuestionMark");
        ScoreManager.listAllOrdinaryGems = GameObject.FindGameObjectsWithTag("Gem");
        ScoreManager.listAllStaticObjects = ScoreManager.listAllQuestionMarks.Concat(ScoreManager.listAllOrdinaryGems.Concat(ScoreManager.listAllCherries)).ToArray();
        foreach (GameObject gemOrCherry in ScoreManager.listAllStaticObjects)
        {
            if (gemOrCherry != null)
            {
                if (gemOrCherry.tag != "QuestionMark")
                    ScoreManager.PartPousing(gemOrCherry);
                else
                    ScoreManager.PartPousing(gemOrCherry.transform.Find("QuestionMark").gameObject);
            }
        }
        ScoreManager.listAllBounceGems = GameObject.FindGameObjectsWithTag("GemBounce");
        foreach (GameObject gemBounce in ScoreManager.listAllBounceGems)
        {
            if (gemBounce != null)
                ScoreManager.TotalPousing(gemBounce);
        }
        ScoreManager.listAllPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in ScoreManager.listAllPlatforms)
        {
            if (platform != null)
                ScoreManager.PlatformPousing(platform);
        }
        ScoreManager.staticAreaOfPoints.SetActive(false);
        ScoreManager.staticMinimap.SetActive(false);
        ScoreManager.speedOfAnimator = ScoreManager.animatorPlayer.speed;
        ScoreManager.animatorPlayer.speed = 0f;
    }
    public static void TakeReBreak()
    {
        if (staticAreaOfPoints.activeSelf == false)
            staticAreaOfPoints.SetActive(true);
        if (staticMinimap.activeSelf == false)
            staticMinimap.SetActive(true);
        ScoreManager.animatorPlayer.speed = ScoreManager.animatorPlayer.speed == 0f ? ScoreManager.speedOfAnimator : ScoreManager.animatorPlayer.speed;
        foreach (MonoBehaviour script in ScoreManager.listAllScripts)
            if (script != null)
                script.enabled = true;
        foreach (GameObject item in listAllSpikes)
        {
            if (item != null)
                ScoreManager.ChapterOfRePousing(item);
        }
        foreach (GameObject item in listAllBridges)
        {
            if (item != null)
            {
                int count = 0;
                while (count < item.transform.childCount)
                {
                    ScoreManager.ChapterOfRePousing(item.transform.GetChild(count).gameObject);
                    count++;
                }
            }
        }
        foreach (GameObject gameObject in ScoreManager.listAllCharacters)
        {
            if (gameObject != null)
                ScoreManager.TotalRePousing(gameObject);
        }
        foreach (GameObject gemOrCherry in ScoreManager.listAllStaticObjects)
        {
            if (gemOrCherry != null)
            {
                if (gemOrCherry.tag != "QuestionMark")
                    ScoreManager.PartRePousing(gemOrCherry);
                else
                    ScoreManager.PartRePousing(gemOrCherry.transform.Find("QuestionMark").gameObject);
            }
        }
        foreach (GameObject gemBounce in ScoreManager.listAllBounceGems)
        {
            if (gemBounce != null)
                ScoreManager.TotalRePousing(gemBounce);
        }
        foreach (GameObject platform in ScoreManager.listAllPlatforms)
        {
            if (platform != null)
                ScoreManager.PlatformRePousing(platform);
        }
    }
    #endregion
}
