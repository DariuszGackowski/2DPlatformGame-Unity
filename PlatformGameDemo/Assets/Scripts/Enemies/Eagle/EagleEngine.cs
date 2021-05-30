using UnityEngine;
public class EagleEngine : MonoBehaviour
{
    public Animator animatorPlayer;
    public GameObject animationDestroy;
    public PolygonCollider2D playerCollider;
    public AudioSource hurtSound, deathSound;
    public Vector2 positionUpXY, positionDownXY, sizeUpCube, sizeDownCube;
    private RigidbodyConstraints2D rigidbodyConstraints2D;
    public float velocity, firstNumberMin0, secondNumberMax4;
    private float time, delayOfEagle;
    private bool countDelay = true, directionUp = true, biteIsBlocked = true, contactWithGround;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<EagleEngine>());
        delayOfEagle = Random.Range(firstNumberMin0, secondNumberMax4);
        rigidbodyConstraints2D = gameObject.GetComponent<Rigidbody2D>().constraints;
    }
    private void Update()
    {
        if (gameObject.transform.position.y > positionUpXY.y)
            directionUp = false;
        else if (gameObject.transform.position.y < positionDownXY.y)
            directionUp = true;
        if (EagleDetector.playerExitCollider & !biteIsBlocked)
        {
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), false);
            animatorPlayer.SetBool("ContactWithEnemy", false);
            biteIsBlocked = true;
        }
        if (countDelay)
            time += Time.deltaTime + delayOfEagle;
    }
    private void FixedUpdate()
    {
        if (countDelay)
        {
            if (time > 4f)
                countDelay = false;
        }
        else if (!countDelay)
            MoveOfEagle();
        if (gameObject.GetComponent<PolygonCollider2D>().isTrigger & contactWithGround)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            contactWithGround = false;
        }
        else
            gameObject.GetComponent<Rigidbody2D>().constraints = gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePositionY ? rigidbodyConstraints2D : gameObject.GetComponent<Rigidbody2D>().constraints;
    }
    private void MoveOfEagle()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = directionUp ? new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, velocity) : new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.x >= gameObject.GetComponent<PolygonCollider2D>().bounds.min.x - 0.3f & collision.gameObject.transform.position.x <= gameObject.GetComponent<PolygonCollider2D>().bounds.max.x + 0.3f & collision.gameObject.GetComponent<PolygonCollider2D>().bounds.min.y >= gameObject.GetComponentInParent<PolygonCollider2D>().bounds.max.y)
        {
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), true);
            deathSound.Play();
            Instantiate(animationDestroy, gameObject.transform.position, Quaternion.identity);
            DetectorEnemy.inCorridor = false;
            Destroy(gameObject);
        }
        contactWithGround = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline") ? true : contactWithGround;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & biteIsBlocked)
        {
            animatorPlayer.SetBool("ContactWithEnemy", true);
            ScoreManager.ChangeLifePoints(-healthValue);
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), true);
            if (!hurtSound.isPlaying)
                hurtSound.Play();
            biteIsBlocked = EagleDetector.playerExitCollider = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(positionUpXY, sizeUpCube);
        Gizmos.DrawCube(positionDownXY, sizeDownCube);
    }
}