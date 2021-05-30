using System.Collections.Generic;
using UnityEngine;
public class DetectorCrouching : MonoBehaviour
{
    public static bool endOfCrouching = true;
    public List<string> listOfAllCeilings = new List<string>();
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DetectorCrouching>());
    }
    private void Update()
    {
        DetectorCrouching.endOfCrouching = listOfAllCeilings.Count > 0 ? false : true;
        gameObject.GetComponent<BoxCollider2D>().enabled = gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch") ? true : false;;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline"))
            listOfAllCeilings.Add("Ground");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling") || collision.gameObject.CompareTag("SkyGround") || collision.gameObject.CompareTag("SkewGround") || collision.gameObject.CompareTag("Trampoline") & listOfAllCeilings.Count > 0)
            if (listOfAllCeilings.Count > 0)
                listOfAllCeilings.RemoveAt(listOfAllCeilings.Count - 1);
    }
}
