using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    private Vector3 velocity, targetPosition;
    public Vector2 positionFirstXY, positionSecondXY, sizeFirstCube, sizeSecondCube;
    public float maxSpeed, smoothTime, resetTime;
    private bool rightDirection, playerOnBoard;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<MovingPlatform>());
        ChangePosition();
    }
    void Update()
    {
        if (PlayerMove.onPlatform & playerOnBoard & !Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D) || PlayerMove.onPlatform & playerOnBoard & Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.D))
            player.transform.SetParent(transform);
        else if (!PlayerMove.onPlatform & !playerOnBoard || PlayerMove.onPlatform & PlayerMove.contactWithCeiling || PlayerMove.onPlatform & playerOnBoard & Input.GetKey(KeyCode.A) || PlayerMove.onPlatform & playerOnBoard & Input.GetKey(KeyCode.D))
            player.transform.SetParent(null);
    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, maxSpeed, resetTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerOnBoard = collision.gameObject.CompareTag("Player") ? true : playerOnBoard;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        playerOnBoard = collision.gameObject.CompareTag("Player") ? true : playerOnBoard;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerOnBoard = collision.gameObject.CompareTag("Player") ? false : playerOnBoard;
    }
    private void ChangePosition()
    {
        if (rightDirection)
        {
            targetPosition = positionSecondXY;
            rightDirection = false;
        }
        else if (!rightDirection)
        {
            targetPosition = positionFirstXY;
            rightDirection = true;
        }
        Invoke("ChangePosition", resetTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(positionFirstXY, sizeFirstCube);
        Gizmos.DrawCube(positionSecondXY, sizeSecondCube);
    }
}
