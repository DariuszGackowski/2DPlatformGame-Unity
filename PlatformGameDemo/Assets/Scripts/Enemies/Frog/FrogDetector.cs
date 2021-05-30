using UnityEngine;
public class FrogDetector : MonoBehaviour
{
    public static bool playerExitCollider;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<FrogDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.transform.position.x >= gameObject.GetComponentInParent<PolygonCollider2D>().bounds.min.x - 0.3f & collision.gameObject.transform.position.x <= gameObject.GetComponentInParent<PolygonCollider2D>().bounds.max.x + 0.3f & collision.gameObject.GetComponent<PolygonCollider2D>().bounds.min.y >= gameObject.GetComponentInParent<PolygonCollider2D>().bounds.max.y)
            {
                FrogDetector.playerExitCollider = false;
                DetectorEnemy.inCorridor = true;
            }
            else
            {
                OpossumDetector.playerExitCollider = false;
                gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger = gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger ? false : gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FrogDetector.playerExitCollider = true;
            gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger = gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger ? false : gameObject.GetComponentInParent<PolygonCollider2D>().isTrigger;
        }
    }
}
