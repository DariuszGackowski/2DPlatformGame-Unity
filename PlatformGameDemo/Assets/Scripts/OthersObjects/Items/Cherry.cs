using UnityEngine;
public class Cherry : MonoBehaviour
{
    public GameObject animationCollect;
    public AudioSource itemSound;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<Cherry>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (MainValuesContainer.health < 5)
            {
                itemSound.Play();
                Instantiate(animationCollect, transform.position, Quaternion.identity);
                ScoreManager.ChangeLifePoints(healthValue);
                Destroy(gameObject);
            }
    }
}
