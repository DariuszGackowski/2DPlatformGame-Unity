using UnityEngine;
public class Crate : MonoBehaviour
{
    public Animator animatorHeaver;
    public Transform targetPoint, startPoint;
    public float velocityOfCrate;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<Crate>());
    }
    private void Update()
    {
        if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation"))
        {
            if (transform.position.y < targetPoint.position.y)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, velocityOfCrate);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            else if (transform.position.y > targetPoint.position.y)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
        }
        if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation"))
        {
            if (transform.position.y > startPoint.position.y)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -velocityOfCrate);
            else if (transform.position.y < startPoint.position.y)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
