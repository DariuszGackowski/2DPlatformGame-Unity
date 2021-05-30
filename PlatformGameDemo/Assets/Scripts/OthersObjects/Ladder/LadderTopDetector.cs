using UnityEngine;
public class LadderTopDetector : MonoBehaviour
{
    public static bool topOfLadder;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<LadderTopDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LadderTopDetector.topOfLadder = collision.gameObject.CompareTag("Player") ? true : LadderTopDetector.topOfLadder;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        LadderTopDetector.topOfLadder = collision.gameObject.CompareTag("Player") ? true : LadderTopDetector.topOfLadder;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LadderTopDetector.topOfLadder = collision.gameObject.CompareTag("Player") ? false : LadderTopDetector.topOfLadder;
    }
}
