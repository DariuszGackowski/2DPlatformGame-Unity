using UnityEngine;
public class Background : MonoBehaviour
{
    public Transform playerPosition, cameraPosition;
    private void LateUpdate()
    {
        transform.position = cameraPosition.position.y == playerPosition.position.y ? new Vector3(playerPosition.position.x, playerPosition.position.y, 5f) : new Vector3(playerPosition.position.x, playerPosition.position.y + (cameraPosition.position.y - playerPosition.position.y), 5f);
    }
}
