using UnityEngine;
public class EscapeFromCave : MonoBehaviour
{
    public Transform targetPoint, startPoint;
    public Rigidbody2D rigidbody2DLastBlock;
    public BoxCollider2D boxCollider2DLastBlock, rebaseCollider;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<EscapeFromCave>());
        Physics2D.IgnoreCollision(rebaseCollider, boxCollider2DLastBlock, true);
    }
    private void Update()
    {
        if (LastChance.gateIsUnlock)
        {
            boxCollider2DLastBlock.isTrigger = true;
            if (rigidbody2DLastBlock.position.x > targetPoint.position.x)
                rigidbody2DLastBlock.velocity = new Vector2(-2f, 0f);
            else if (rigidbody2DLastBlock.position.x < targetPoint.position.x)
            {
                rigidbody2DLastBlock.velocity = new Vector2(0f, 0f);
                rigidbody2DLastBlock.position = targetPoint.position;
            }
        }
        else if (!LastChance.gateIsUnlock)
        {
            if (transform.position.x < startPoint.position.x)
                rigidbody2DLastBlock.velocity = new Vector2(2f, 0f);
            else if (transform.position.x > startPoint.position.x)
            {
                rigidbody2DLastBlock.velocity = new Vector2(0f, 0f);
                rigidbody2DLastBlock.position = startPoint.position;
                boxCollider2DLastBlock.isTrigger = false;
            }
        }
    }
}
