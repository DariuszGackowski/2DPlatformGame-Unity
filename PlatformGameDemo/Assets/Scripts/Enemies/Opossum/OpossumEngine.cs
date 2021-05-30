using UnityEngine;
public class OpossumEngine : MonoBehaviour
{
    public Animator animatorPlayer;
    public GameObject animationDestroy;
    public PolygonCollider2D playerCollider;
    public AudioSource hurtSound, deathSound;
    public Vector2 positionLeftXY, positionRightXY, sizeLeftCube, sizeRightCube;
    private RigidbodyConstraints2D rigidbodyConstraints2D;
    public float velocity, firstNumberMin0, secondNumberMax4;
    public bool directionRight;
    private float time, delayOfOpossum;
    private bool biteIsBlocked = true, countDelay = true, contactWithGround;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<OpossumEngine>());
        delayOfOpossum = Random.Range(firstNumberMin0, secondNumberMax4);
        rigidbodyConstraints2D = gameObject.GetComponent<Rigidbody2D>().constraints;
    }
    private void Update()
    {
        if (gameObject.transform.position.x < positionLeftXY.x)
            directionRight = true;
        else if (gameObject.transform.position.x > positionRightXY.x)
            directionRight = false;
        if (OpossumDetector.playerExitCollider & !biteIsBlocked)
        {
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), false);
            animatorPlayer.SetBool("ContactWithEnemy", false);
            biteIsBlocked = true;
        }
        if (countDelay)
            time += Time.deltaTime + delayOfOpossum;
    }
    private void FixedUpdate()
    {
        if (countDelay)
        {
            if (time > 4f)
                countDelay = false;
        }
        else if (!countDelay)
            MoveOfOpossum();
        if (gameObject.GetComponent<PolygonCollider2D>().isTrigger & contactWithGround)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            contactWithGround = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePositionY ? rigidbodyConstraints2D : gameObject.GetComponent<Rigidbody2D>().constraints;
        }
    }
    private void MoveOfOpossum()
    {
        if (directionRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = transform.rotation != Quaternion.Euler(0, 180, 0) ? Quaternion.Euler(0, 180, 0) : transform.rotation;
        }
        else if (!directionRight)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = transform.rotation != Quaternion.Euler(0, 0, 0) ? Quaternion.Euler(0, 0, 0) : transform.rotation;
        }
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
        contactWithGround = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline") ? true : contactWithGround; ;
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
            biteIsBlocked = OpossumDetector.playerExitCollider = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(positionLeftXY, sizeLeftCube);
        Gizmos.DrawCube(positionRightXY, sizeRightCube);
    }
}
