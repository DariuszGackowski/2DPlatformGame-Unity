using UnityEngine;
public class MiddleBackground : MonoBehaviour
{
    public Transform housePosition, playerPosition, cameraPosition;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<MiddleBackground>());
    }
    private void Update()
    {
        transform.position = cameraPosition.position.y >= housePosition.position.y ? new Vector2(playerPosition.position.x + 0.79f, playerPosition.position.y - 2.98f - (playerPosition.position.y - housePosition.position.y)): new Vector2(playerPosition.position.x + 0.79f, playerPosition.position.y - 2.98f);
    }
}
