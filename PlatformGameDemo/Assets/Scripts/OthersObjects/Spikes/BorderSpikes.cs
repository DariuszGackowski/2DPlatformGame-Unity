using UnityEngine;
public class BorderSpikes : MonoBehaviour
{
    public GameObject animationDestroy;
    public Animator animatorPlayer;
    public AudioSource hurtSound;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<BorderSpikes>());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.ChangeLifePoints(-healthValue);
            animatorPlayer.SetBool("ContactWithEnemy", true);
            PlayerMove.playerWasHit = true;
            if (!hurtSound.isPlaying)
                hurtSound.Play();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(animationDestroy, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.transform.gameObject);
        }
    }
}
