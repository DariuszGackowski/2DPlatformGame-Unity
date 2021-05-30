using Assets.Scripts.Important;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gem : MonoBehaviour
{
    public GameObject animationCollect;
    public AudioSource itemSound;
    public Color orange, blue, purple;
    public int numberOfArea;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<Gem>());
        if (MainValuesContainer.selectedNumbersForLifePoints & MainValuesContainer.CheckMyList(SceneManager.GetActiveScene().name))
        {
            TwoValues.ExportFromMainList(MainValuesContainer.orangeGems, numberOfArea, SceneManager.GetActiveScene().name, orange, gameObject.GetComponent<SpriteRenderer>());
            TwoValues.ExportFromMainList(MainValuesContainer.blueGems, numberOfArea, SceneManager.GetActiveScene().name, blue, gameObject.GetComponent<SpriteRenderer>());
            TwoValues.ExportFromMainList(MainValuesContainer.purpleGems, numberOfArea, SceneManager.GetActiveScene().name, purple, gameObject.GetComponent<SpriteRenderer>());
        }
    }
    private void Update()
    {
        itemSound = itemSound == null ? GameObject.Find("/Sounds/ItemSound").GetComponent<AudioSource>() : itemSound;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.ChangeScore(Gem.ColorCode(gameObject.GetComponent<SpriteRenderer>().color));
            MainValuesContainer.collectedGems.Add(gameObject.name);
            itemSound.Play();
            Instantiate(animationCollect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            Instantiate(animationCollect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public static string ColorCode(Color color)
    {
        return ((int)color.r).ToString() + ((int)color.g).ToString() + ((int)color.b).ToString() + ((int)color.a).ToString();
    }
}
