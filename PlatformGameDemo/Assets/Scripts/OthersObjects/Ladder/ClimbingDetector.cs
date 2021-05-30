using UnityEngine;
public class ClimbingDetector : MonoBehaviour
{
    public static bool playerOnLadder;
    public Animator animatorPlayer;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<ClimbingDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ClimbingDetector.playerOnLadder = collision.gameObject.CompareTag("Player") ? true : ClimbingDetector.playerOnLadder;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ClimbingDetector.playerOnLadder = collision.gameObject.CompareTag("Player") ? true : ClimbingDetector.playerOnLadder;
        if (collision.gameObject.CompareTag("Player") & !LadderGroundDetector.baseOfLadder)
            animatorPlayer.SetBool("UnderLadder", false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ClimbingDetector.playerOnLadder = collision.gameObject.CompareTag("Player") & LadderGroundDetector.baseOfLadder & PlayerMove.contactWithGround || collision.gameObject.CompareTag("Player") & !LadderGroundDetector.baseOfLadder & !DetectorGround.onGround & LadderTopDetector.topOfLadder || collision.gameObject.CompareTag("Player") & !LadderGroundDetector.baseOfLadder & !LadderTopDetector.topOfLadder || collision.gameObject.CompareTag("Player") & animatorPlayer.GetBool("AboveLadder") ? false : ClimbingDetector.playerOnLadder;

    }
}
