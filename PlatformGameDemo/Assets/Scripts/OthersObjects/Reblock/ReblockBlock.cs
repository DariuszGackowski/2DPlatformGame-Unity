using UnityEngine;
public class ReblockBlock : MonoBehaviour
{
    public GameObject blockBlock;
    public Transform pointPosition;
    public BoxCollider2D rebaseCollider, blockBlockCollider;
    private bool openTheGate;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<ReblockBlock>());
        Physics2D.IgnoreCollision(rebaseCollider, blockBlock.GetComponent<BoxCollider2D>(), true);
    }
    private void Update()
    {
        if (openTheGate)
        {
            blockBlock.GetComponent<BoxCollider2D>().isTrigger = true;
            if (blockBlock.GetComponent<Transform>().position.x < pointPosition.position.x)
                blockBlock.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0f);
            else if (blockBlock.GetComponent<Transform>().position.x > pointPosition.position.x)
            {
                blockBlock.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                blockBlock.GetComponent<Transform>().position = pointPosition.position;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        openTheGate = collision.gameObject.CompareTag("Ground") ? true : openTheGate;
    }
}
