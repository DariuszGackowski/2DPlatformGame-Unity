using UnityEngine;
public class CeilingSpikes : MonoBehaviour
{
    public GameObject animationDestroy, animationGem;
    public Animator animatorPlayer;
    public AudioSource hurtSound;
    public float velocityOfFall;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<CeilingSpikes>());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = collision.gameObject.CompareTag("Player") ? velocityOfFall : gameObject.GetComponent<Rigidbody2D>().gravityScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MasterSpikes") || collision.gameObject.CompareTag("SkewGround"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.ChangeLifePoints(-healthValue);
            animatorPlayer.SetBool("ContactWithEnemy", true);
            PlayerMove.playerWasHit = true;
            if (!hurtSound.isPlaying)
                hurtSound.Play();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(animationDestroy, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            Instantiate(animationGem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
