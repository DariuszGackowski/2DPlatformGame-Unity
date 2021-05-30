using UnityEngine;
public class GemBounce : MonoBehaviour
{
    public Vector2 positionCube;
    public float sizeCube, velocity;
    private bool directionDown = true, hitGround, changingDirection;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<GemBounce>());
    }
    void Update()
    {
        directionDown = gameObject.transform.position.y >= positionCube.y ? true : false;
        changingDirection = gameObject.transform.position.y >= positionCube.y ? true : changingDirection;
        MovingGemBounce();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitGround = collision.gameObject.CompareTag("Ground") ? true : hitGround;
        changingDirection = collision.gameObject.CompareTag("Ground") ? true : changingDirection;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hitGround = collision.gameObject.CompareTag("Ground") ? false : hitGround;
    }
    private void MovingGemBounce()
    {
        if (directionDown & changingDirection)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -velocity);
            changingDirection = false;
        }
        else if (!directionDown & changingDirection)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, velocity);
            changingDirection = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(positionCube, sizeCube);
    }
}
