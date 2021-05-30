using UnityEngine;
public class LogDetector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") & collision.gameObject.GetComponent<Rigidbody2D>() && collision.gameObject.GetComponent<Rigidbody2D>().gravityScale != 0 || collision.gameObject.CompareTag("FallenLog") & collision.gameObject.GetComponent<Rigidbody2D>() && collision.gameObject.GetComponent<Rigidbody2D>().gravityScale != 0)
            transform.parent.gameObject.GetComponent<FallenLogs>().playerDetected = true;
    }
}
