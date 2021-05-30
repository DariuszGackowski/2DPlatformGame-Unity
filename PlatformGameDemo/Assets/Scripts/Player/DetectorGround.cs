using System.Collections.Generic;
using UnityEngine;
public class DetectorGround : MonoBehaviour
{
    public static bool onGround, onSkewGround;
    public List<string> listOfAllGround = new List<string>();
    private float trueGravity;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DetectorGround>());
        trueGravity = gameObject.GetComponentInParent<Rigidbody2D>().gravityScale;
    }
    private void FixedUpdate()
    {
        DetectorGround.onGround= listOfAllGround.Count > 0 ? true : false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SkewGround"))
        {
            gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 0f;
            gameObject.GetComponentInParent<Animator>().SetBool("OnSkewGround", true);
            onSkewGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") & !collision.gameObject.GetComponent<FallenLogs>() || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline"))
            listOfAllGround.Add("Ground");
        else if (collision.gameObject.CompareTag("Ground") & collision.gameObject.GetComponent<FallenLogs>())
        {
            listOfAllGround.Add("Ground");
            collision.gameObject.GetComponent<FallenLogs>().playerDetected = true;
            collision.gameObject.GetComponent<FallenLogs>().contactWithPlayer = true;
        }
        else if (collision.gameObject.CompareTag("SkyGround"))
        {
            collision.gameObject.GetComponent<TopSecret>().startTime = collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            listOfAllGround.Add("Ground");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline"))
            if (listOfAllGround.Count > 0)
                listOfAllGround.RemoveAt(listOfAllGround.Count - 1);
        if (collision.gameObject.CompareTag("SkewGround"))
        {
            gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = trueGravity;
            gameObject.GetComponentInParent<Animator>().SetBool("OnSkewGround", false);
            onSkewGround = false;
        }
    }
}
