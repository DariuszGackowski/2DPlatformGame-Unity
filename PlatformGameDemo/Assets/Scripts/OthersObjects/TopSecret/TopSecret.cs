using UnityEngine;
public class TopSecret : MonoBehaviour
{
    public bool startTime;
    private float time;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<TopSecret>());
    }
    private void Update()
    {
        if (startTime)
        {
            time += Time.deltaTime;
            if (time > 0.4f)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                time = 0f;
            }
            startTime = !gameObject.GetComponent<SpriteRenderer>().enabled ? false: startTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            startTime = false;
            time = 0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        startTime = collision.gameObject.CompareTag("Player") ? true : startTime;
    }
}
