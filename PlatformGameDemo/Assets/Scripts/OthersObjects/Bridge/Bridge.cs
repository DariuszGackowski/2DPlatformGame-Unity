using UnityEngine;
using UnityEngine.Tilemaps;
public class Bridge : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<Bridge>());
    }
    private void Update()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = DetectorBridge.enterBridge ? false : true;
    }
}
