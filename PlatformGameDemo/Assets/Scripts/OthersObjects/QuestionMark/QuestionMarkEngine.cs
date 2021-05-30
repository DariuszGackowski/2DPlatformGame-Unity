using UnityEngine;
public class QuestionMarkEngine : MonoBehaviour
{
    public GameObject newGemOrange, newGemBlue, newGemPurple, newCherry;
    private float randomNumber;
    private bool firstMessage, playerIsHere;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<QuestionMarkEngine>());
        randomNumber = Random.Range(1f, 16f);
    }
    private void Update()
    {
        if (playerIsHere & !firstMessage)
        {
            switch ((int)randomNumber)
            {
                case 2:
                    Instantiate(AddNewObject(newGemPurple), gameObject.transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(AddNewObject(newGemPurple), gameObject.transform.position, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(AddNewObject(newGemBlue), gameObject.transform.position, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(AddNewObject(newGemPurple), gameObject.transform.position, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(AddNewObject(newCherry), gameObject.transform.position, Quaternion.identity);
                    break;
                case 11:
                    Instantiate(AddNewObject(newGemPurple), gameObject.transform.position, Quaternion.identity);
                    break;
                case 14:
                    Instantiate(AddNewObject(newGemBlue), gameObject.transform.position, Quaternion.identity);
                    break;
                case 15:
                    Instantiate(AddNewObject(newGemOrange), gameObject.transform.position, Quaternion.identity);
                    break;
            }
            firstMessage = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsHere = collision.gameObject.CompareTag("Player") & !firstMessage ? true : playerIsHere;
    }
    private GameObject AddNewObject(GameObject unprefabedGameObject)
    {
        unprefabedGameObject.GetComponent<NewObjectScript>().parentName = gameObject.name.ToString();
        unprefabedGameObject.GetComponent<NewObjectScript>().grandParentName = transform.parent.gameObject.name.ToString();
        unprefabedGameObject.GetComponent<Cherry>().itemSound = unprefabedGameObject == newCherry ? GameObject.Find("/Sounds/ItemSound").GetComponent<AudioSource>() : unprefabedGameObject.GetComponent<Cherry>().itemSound;
        unprefabedGameObject.GetComponent<Gem>().itemSound = unprefabedGameObject == newGemOrange || unprefabedGameObject == newGemBlue || unprefabedGameObject == newGemPurple ? GameObject.Find("/Sounds/ItemSound").GetComponent<AudioSource>() : unprefabedGameObject.GetComponent<Gem>().itemSound;
        return unprefabedGameObject;
    }
}
