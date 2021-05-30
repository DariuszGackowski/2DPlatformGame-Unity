using UnityEngine;
public class LadderRebaseDetector : MonoBehaviour
{
    public static bool enterLadder, topEnterLadder = true;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<LadderRebaseDetector>());
    }
    private void FixedUpdate()
    {
        if (PlayerMove.onTrampoline & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetBool("AboveLadder") || gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetBool("IsClimbing"))
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        else if (!PlayerMove.onTrampoline & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetBool("AboveLadder") & !gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetBool("IsClimbing") & !LadderTopDetector.topOfLadder || !gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetBool("IsClimbing") & !LadderTopDetector.topOfLadder)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckingEnter();
            LadderRebaseDetector.enterLadder = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckingEnter();
            LadderRebaseDetector.enterLadder = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        LadderRebaseDetector.enterLadder = collision.gameObject.CompareTag("Player") ? false : LadderRebaseDetector.enterLadder;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !LadderTopDetector.topOfLadder)
        {
            CheckingEnter();
            LadderRebaseDetector.enterLadder = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & !LadderTopDetector.topOfLadder)
        {
            CheckingEnter();
            LadderRebaseDetector.enterLadder = true;
        }
        else if (!collision.gameObject.CompareTag("Player"))
            LadderRebaseDetector.topEnterLadder = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LadderRebaseDetector.enterLadder = PlayerMove.onTrampoline = false;
            LadderRebaseDetector.topEnterLadder = true;
        }
    }
    private void CheckingEnter()
    {
        LadderRebaseDetector.topEnterLadder = Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S) ? true : false;
    }
}
