using UnityEngine;
public class FallenLogs : MonoBehaviour
{
    public bool contactWithPlayer, playerDetected;
    private float timetToFallLogs, lockEverything;
    private bool lockPlayerTouch, changingDirection, removeLog;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<FallenLogs>());
    }
    private void Update()
    {
        if (playerDetected)
        {
            timetToFallLogs += Time.deltaTime;
            if (timetToFallLogs > 0.25f)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                lockPlayerTouch = changingDirection = true;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
                playerDetected = false;
            }
        }
        if (!contactWithPlayer & changingDirection)
        {
            gameObject.tag = "FallenLog";
            changingDirection = false;
        }
        if (lockPlayerTouch)
        {
            lockEverything += Time.deltaTime;
            lockPlayerTouch = lockEverything > 0.1f ? false : lockPlayerTouch;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerDetected = collision.gameObject.CompareTag("Player") && gameObject.GetComponent<Rigidbody2D>().gravityScale == 0f ? true : playerDetected;
        if (!collision.gameObject.CompareTag("Player") & gameObject.GetComponent<Rigidbody2D>().gravityScale != 0f || collision.gameObject.CompareTag("Player") & gameObject.GetComponent<Rigidbody2D>().gravityScale != 0f & !lockPlayerTouch)
            Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        contactWithPlayer = collision.gameObject.CompareTag("Player") ? true : false;
        if (collision.gameObject.CompareTag("Player") & gameObject.GetComponent<Rigidbody2D>().gravityScale != 0f & !lockPlayerTouch & !removeLog)
        {
            GameObject.Find("DetectorGround").GetComponent<DetectorGround>().listOfAllGround.RemoveAt(GameObject.Find("DetectorGround").GetComponent<DetectorGround>().listOfAllGround.Count - 1);
            removeLog = true;
        }
    }
}
