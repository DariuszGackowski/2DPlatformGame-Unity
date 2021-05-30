using UnityEngine;
public class DetectorBridge : MonoBehaviour
{
    public static bool enterBridge;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DetectorBridge>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectorBridge.enterBridge = collision.gameObject.CompareTag("Player") ? true : DetectorBridge.enterBridge;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectorBridge.enterBridge = collision.gameObject.CompareTag("Player") ? true : DetectorBridge.enterBridge;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DetectorBridge.enterBridge = collision.gameObject.CompareTag("Player") ? false : DetectorBridge.enterBridge;
    }
}
