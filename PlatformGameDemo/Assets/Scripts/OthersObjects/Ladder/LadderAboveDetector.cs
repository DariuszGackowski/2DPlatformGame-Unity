using UnityEngine;
public class LadderAboveDetector : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<LadderAboveDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("AboveLadder", true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("AboveLadder", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("AboveLadder", false);
    }
}
