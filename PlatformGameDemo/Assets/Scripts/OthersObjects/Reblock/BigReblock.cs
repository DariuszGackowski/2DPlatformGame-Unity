using UnityEngine;
public class BigReblock : MonoBehaviour
{
    public Animator animatorHeaver;
    public Transform targetPoint, startPoint;
    public float velocityOfBigReblock;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<BigReblock>());
    }
    private void Update()
    {
        if (transform.position.x < targetPoint.position.x & animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityOfBigReblock, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (transform.position.y > targetPoint.position.y & animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        if (transform.position.x > startPoint.position.x & animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation"))
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityOfBigReblock, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        else if (transform.position.x < startPoint.position.x & animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
