using UnityEngine;
public class DetectorEnemy : MonoBehaviour
{
    public static bool inCorridor;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DetectorEnemy>());
        DetectorEnemy.inCorridor = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy") & DetectorEnemy.inCorridor)
        {
            collider.gameObject.GetComponent<PolygonCollider2D>().isTrigger = !collider.gameObject.GetComponent<PolygonCollider2D>().isTrigger ? true: collider.gameObject.GetComponent<PolygonCollider2D>().isTrigger;
            DetectorEnemy.inCorridor = false;
        }
    }
}
