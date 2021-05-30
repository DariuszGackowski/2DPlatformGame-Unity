using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D boundsBox;
    public float debartmentOfCamera;
    private float halfCamHeight, halfCamWidth, clampedX, clampedY;
    private Vector2 minBounds, maxBounds;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<CameraController>());
        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;
        halfCamHeight = gameObject.GetComponent<Camera>().orthographicSize;
        halfCamWidth = halfCamHeight * gameObject.GetComponent<Camera>().aspect;
        transform.position = player.position + new Vector3(0, 0, debartmentOfCamera);
    }
    private void LateUpdate()
    {
        clampedX = Mathf.Clamp(player.position.x, minBounds.x + halfCamWidth, maxBounds.x - halfCamWidth);
        clampedY = Mathf.Clamp(player.position.y, minBounds.y + halfCamHeight, maxBounds.y - halfCamHeight);
        transform.position = new Vector3(clampedX, clampedY, debartmentOfCamera);
    }
}
