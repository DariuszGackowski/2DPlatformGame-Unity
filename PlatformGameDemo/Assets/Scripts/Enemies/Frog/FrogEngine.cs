using UnityEngine;
public class FrogEngine : MonoBehaviour
{
    public Animator animatorPlayer;
    public GameObject animationDestroy, animationGem;
    public PolygonCollider2D playerCollider;
    public AudioSource hurtSound, deathSound;
    private RigidbodyConstraints2D rigidbodyConstraints2D;
    public float velocityX, jump, firstNumberMin0, secondNumberMax2;
    public bool jumpRight;
    private float time, delayOfFrog;
    private bool biteIsBlocked = true, jumping = true, countDelay = true, contactWithGround;
    private readonly int healthValue = 1;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<FrogEngine>());
        delayOfFrog = Random.Range(firstNumberMin0, secondNumberMax2);
        rigidbodyConstraints2D = gameObject.GetComponent<Rigidbody2D>().constraints;
    }
    private void Update()
    {
        if (FrogDetector.playerExitCollider & gameObject.GetComponent<Animator>().GetBool("IsContactWithPlayer"))
            gameObject.GetComponent<Animator>().SetBool("IsContactWithPlayer", false);
        gameObject.GetComponent<Animator>().SetFloat("Fly", gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (jumpRight)
            transform.rotation = transform.rotation != Quaternion.Euler(0, 0, 0) ? Quaternion.Euler(0, 0, 0) : transform.rotation;
        else if (!jumpRight)
            transform.rotation = transform.rotation != Quaternion.Euler(0, 180, 0) ? Quaternion.Euler(0, 180, 0) : transform.rotation;
        if (FrogDetector.playerExitCollider & !biteIsBlocked)
        {
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), false);
            animatorPlayer.SetBool("ContactWithEnemy", false);
            biteIsBlocked = true;
        }
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FrogIdle") & jumping)
        {
            if (countDelay)
            {
                time += delayOfFrog + Time.deltaTime;
                countDelay = false;
            }
            else if (!countDelay)
                time += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (time > 2f)
        {
            if (jumpRight & jumping)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, +jump);
                jumpRight = false;
            }
            else if (!jumpRight & jumping)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX, jump);
                jumpRight = true;
            }
            gameObject.GetComponent<Animator>().SetBool("IsJumping", true);
            jumping = false;
            time = 0f;
        }
        if (gameObject.GetComponent<PolygonCollider2D>().isTrigger & contactWithGround)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            contactWithGround = false;
        }
        else
            gameObject.GetComponent<Rigidbody2D>().constraints = gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePositionY ? rigidbodyConstraints2D : gameObject.GetComponent<Rigidbody2D>().constraints;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.x >= gameObject.GetComponent<PolygonCollider2D>().bounds.min.x - 0.3f & collision.gameObject.transform.position.x <= gameObject.GetComponent<PolygonCollider2D>().bounds.max.x + 0.3f & collision.gameObject.GetComponent<PolygonCollider2D>().bounds.min.y >= gameObject.GetComponentInParent<PolygonCollider2D>().bounds.max.y)
        {
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), true);
            deathSound.Play();
            Instantiate(animationDestroy, transform.position, Quaternion.identity);
            DetectorEnemy.inCorridor = false;
            Destroy(gameObject);
        }
        contactWithGround = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline") ? true : contactWithGround;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(animationDestroy, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            Instantiate(animationGem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Ceiling"))
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FrogJumpUp"))
                gameObject.GetComponent<Animator>().SetBool("IsContactWithCeiling", true);
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FrogIdle"))
        {
            gameObject.GetComponent<Animator>().SetBool("IsContactWithCeiling", false);
            gameObject.GetComponent<Animator>().SetBool("IsJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & biteIsBlocked)
        {
            animatorPlayer.SetBool("ContactWithEnemy", true);
            gameObject.GetComponent<Animator>().SetBool("IsContactWithPlayer", true);
            ScoreManager.ChangeLifePoints(-healthValue);
            Physics2D.IgnoreCollision(playerCollider, gameObject.GetComponent<PolygonCollider2D>(), true);
            if (!hurtSound.isPlaying)
                hurtSound.Play();
            biteIsBlocked = FrogDetector.playerExitCollider = false;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(animationDestroy, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            Instantiate(animationGem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Ceiling"))
        {
            jumping = true;
            gameObject.GetComponent<Animator>().SetBool("IsJumping", false);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FrogJumpUp"))
                gameObject.GetComponent<Animator>().SetBool("IsContactWithCeiling", true);
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FrogIdle"))
            {
                gameObject.GetComponent<Animator>().SetBool("IsContactWithCeiling", false);
                gameObject.GetComponent<Animator>().SetBool("IsJumping", true);
            }
        }
        else
        {
            jumping = false;
            gameObject.GetComponent<Animator>().SetBool("IsJumping", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Ceiling"))
            gameObject.GetComponent<Animator>().SetBool("IsContactWithCeiling", false);
        if (collision.gameObject.CompareTag("Player"))
            gameObject.GetComponent<Animator>().SetBool("IsContactWithPlayer", false);
    }
}
