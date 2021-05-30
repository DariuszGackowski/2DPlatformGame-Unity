using UnityEngine;
public class MasterFallenDetector : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<MasterFallenDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterFallenLog.playerDetected = collision.gameObject.CompareTag("Player") ? true : MasterFallenLog.playerDetected;
    }
}
