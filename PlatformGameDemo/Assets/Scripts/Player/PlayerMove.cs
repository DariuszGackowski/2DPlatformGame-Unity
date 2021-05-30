using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public static bool onPlatform, onTrampoline, contactWithGround, playerWasHit, contactWithCeiling;
    public Animator animator;
    public AudioSource jumpSound;
    public Vector2[] newPolygonPoints;
    public float speed, jump, jumpAfterCrouching, velocityOfClimbing;
    public bool levelWithLadders;
    private float trueGravity, trueSpeedAnimation = 1f, timeToEndHurtAnimation;
    private bool doIAmFreeze, thisWayIsBlocked;
    private readonly bool inDungeon = true;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<PlayerMove>());
        if (!inDungeon)
            FirstMove();
        trueGravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
    }
    #region AnimationRegion
    private void Update()
    {
        if (!MainValuesContainer.pattern)
        {
            MainValuesContainer.rigidbodyConstraints2DPlayer = gameObject.GetComponent<Rigidbody2D>().constraints;
            MainValuesContainer.pattern = true;
        }
        if (PlayerMove.playerWasHit)
        {
            timeToEndHurtAnimation += Time.deltaTime;
            if (timeToEndHurtAnimation > 0.5f & animator.GetBool("ContactWithEnemy"))
            {
                animator.SetBool("ContactWithEnemy", false);
                PlayerMove.playerWasHit = false;
            }
        }
        else if (!PlayerMove.playerWasHit & timeToEndHurtAnimation != 0f)
            timeToEndHurtAnimation = 0f;
        if (!levelWithLadders)
        {
            animator.SetBool("AboveLadder", false);
            animator.SetBool("UnderLadder", false);
            ClimbingDetector.playerOnLadder = LadderTopDetector.topOfLadder = LadderGroundDetector.baseOfLadder = LadderRebaseDetector.topEnterLadder = LadderRebaseDetector.enterLadder = false;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch"))
        {
            newPolygonPoints = gameObject.GetComponent<PolygonCollider2D>().points;
            newPolygonPoints[0] = new Vector2(0.25f, -0.7f);
            newPolygonPoints[1] = new Vector2(0.15f, -0.5f);
            newPolygonPoints[2] = new Vector2(-0.35f, -0.5f);
            newPolygonPoints[3] = new Vector2(-0.45f, -0.7f);
            gameObject.GetComponent<PolygonCollider2D>().points = newPolygonPoints;
        }
        else
        {
            newPolygonPoints = gameObject.GetComponent<PolygonCollider2D>().points;
            newPolygonPoints[0] = new Vector2(0.25f, 0f);
            newPolygonPoints[1] = new Vector2(0.15f, 0.2f);
            newPolygonPoints[2] = new Vector2(-0.35f, 0.2f);
            newPolygonPoints[3] = new Vector2(-0.45f, 0f);
            gameObject.GetComponent<PolygonCollider2D>().points = newPolygonPoints;
        }
        if (!DetectorGround.onGround)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("FallFromLadder", true);
        }
        else if (!Input.GetKey(KeyCode.Space) & DetectorGround.onGround)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("FallFromLadder", false);
        }
        #region SpeedAnimation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & animator.GetBool("ContactWithEnemy") & animator.speed != trueSpeedAnimation)
            animator.speed = trueSpeedAnimation;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) & !thisWayIsBlocked ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.W))
            animator.speed = 2f;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & Input.GetKey(KeyCode.W) & thisWayIsBlocked || animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & !animator.GetBool("ContactWithEnemy") & animator.speed == trueSpeedAnimation & !Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) || animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & !Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder || animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder)
            animator.speed = 0f;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & !ClimbingDetector.playerOnLadder & DetectorGround.onGround ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & !ClimbingDetector.playerOnLadder & !LadderGroundDetector.baseOfLadder & animator.GetBool("AboveLadder") & !PlayerMove.onTrampoline ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & ClimbingDetector.playerOnLadder & DetectorGround.onGround & LadderGroundDetector.baseOfLadder)
            animator.speed = 4f;
        else
            animator.speed = trueSpeedAnimation;
        #endregion
        if (Input.GetKey(KeyCode.LeftShift) & DetectorGround.onGround)
            animator.SetBool("IsCrouching", true);
        else if (!Input.GetKey(KeyCode.LeftShift) & DetectorCrouching.endOfCrouching)
            animator.SetBool("IsCrouching", false);
        else if (Input.GetKey(KeyCode.LeftShift) & !DetectorGround.onGround)
            animator.SetBool("IsCrouching", false);
        if (!ClimbingDetector.playerOnLadder)
            animator.SetBool("IsClimbing", false);
        if (ClimbingDetector.playerOnLadder & !LadderGroundDetector.baseOfLadder & !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun") & animator.GetBool("AboveLadder") & Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) & ClimbingDetector.playerOnLadder & LadderGroundDetector.baseOfLadder & PlayerMove.contactWithGround)
            animator.SetBool("IsClimbing", true);
        else if (!ClimbingDetector.playerOnLadder & animator.GetBool("AboveLadder") || Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder & LadderGroundDetector.baseOfLadder & PlayerMove.contactWithGround)
            animator.SetBool("IsClimbing", false);
        else if (!ClimbingDetector.playerOnLadder & !PlayerMove.contactWithGround)
        {
            animator.SetBool("FallFromLadder", true);
            animator.SetBool("IsClimbing", false);
        }
    }
    #endregion
    #region MoveRegion
    private void FixedUpdate()
    {
        animator.SetFloat("Fly", gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (!ClimbingDetector.playerOnLadder & animator.GetBool("AboveLadder") & gameObject.GetComponent<Rigidbody2D>().gravityScale == 0f)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = trueGravity;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        else if (ClimbingDetector.playerOnLadder & !LadderGroundDetector.baseOfLadder & gameObject.GetComponent<Rigidbody2D>().gravityScale == trueGravity)
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        else if (!ClimbingDetector.playerOnLadder & gameObject.GetComponent<Rigidbody2D>().gravityScale == 0f || ClimbingDetector.playerOnLadder & gameObject.GetComponent<Rigidbody2D>().gravityScale == 0f & LadderGroundDetector.baseOfLadder)
            gameObject.GetComponent<Rigidbody2D>().gravityScale = trueGravity;
        if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            animator.SetFloat("Speed", speed);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            animator.SetFloat("Speed", speed);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            animator.SetFloat("Speed", 0f);
        }
        else
            animator.SetFloat("Speed", 0f);
        if (!Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D) & DetectorGround.onSkewGround & PlayerMove.contactWithGround & !Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.D) & DetectorGround.onSkewGround & PlayerMove.contactWithGround & !Input.GetKey(KeyCode.Space))
        {
            if (!doIAmFreeze)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                doIAmFreeze = true;
            }
        }
        else
        {
            if (doIAmFreeze)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = MainValuesContainer.rigidbodyConstraints2DPlayer;
                doIAmFreeze = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) & !LadderGroundDetector.baseOfLadder & DetectorGround.onGround & !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch") & !animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jump);
            animator.SetBool("IsJumping", true);
            if (!jumpSound.isPlaying)
                jumpSound.Play();
        }
        else if (Input.GetKey(KeyCode.Space) & !LadderGroundDetector.baseOfLadder & DetectorGround.onGround & DetectorCrouching.endOfCrouching & animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpAfterCrouching);
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsCrouching", false);
            if (!jumpSound.isPlaying)
                jumpSound.Play();
        }
        if (Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder & animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, velocityOfClimbing);
        else if (!Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder & animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -velocityOfClimbing);
        else if (Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.W) & ClimbingDetector.playerOnLadder & animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
        else if (!Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) & ClimbingDetector.playerOnLadder & animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerJumpUp") & ClimbingDetector.playerOnLadder & !animator.GetBool("AboveLadder") || animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerJumpDown") & ClimbingDetector.playerOnLadder & !animator.GetBool("AboveLadder"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
            animator.SetBool("IsClimbing", true);
        }
        else if (Input.GetKey(KeyCode.W) & ClimbingDetector.playerOnLadder & LadderRebaseDetector.enterLadder & animator.GetBool("AboveLadder"))
            animator.SetBool("IsClimbing", false);
        if (gameObject.GetComponent<Rigidbody2D>().rotation != 0f)
            gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
    }
    #endregion
    #region CollidersRegion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove.onPlatform = collision.gameObject.name.Equals("MainPlatform") ? true : PlayerMove.onPlatform;
        PlayerMove.contactWithCeiling = collision.gameObject.CompareTag("Ceiling") ? true : PlayerMove.contactWithCeiling;
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround"))
        {
            PlayerMove.contactWithGround = LadderTopDetector.topOfLadder ? false : true;
            thisWayIsBlocked = (collision.gameObject.name == "BlockBlock") ? true : thisWayIsBlocked;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerMove.onPlatform = collision.gameObject.name.Equals("MainPlatform") ? true : PlayerMove.onPlatform;
        PlayerMove.contactWithCeiling = collision.gameObject.CompareTag("Ceiling") ? true : PlayerMove.contactWithCeiling;
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline"))
        {
            PlayerMove.contactWithGround = LadderTopDetector.topOfLadder ? false : true;
            thisWayIsBlocked = collision.gameObject.name == "BlockBlock" ? true : thisWayIsBlocked;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerMove.onPlatform = collision.gameObject.name.Equals("MainPlatform") ? false : PlayerMove.onPlatform;
        PlayerMove.contactWithCeiling = collision.gameObject.CompareTag("Ceiling") ? false : PlayerMove.contactWithCeiling;
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline"))
        {
            PlayerMove.contactWithGround = false;
            thisWayIsBlocked = collision.gameObject.name == "BlockBlock" ? false : thisWayIsBlocked;
        }
    }
    #endregion
    private void FirstMove()
    {
        trueGravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        trueSpeedAnimation = GetComponent<Animator>().speed;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = MainValuesContainer.rigidbodyConstraints2DPlayer;
    }

}