using System.Collections.Generic;
using UnityEngine;
public class LadderGroundDetector : MonoBehaviour
{
    public static bool baseOfLadder;
    public List<string> listOfAllGroundLadderDetection = new List<string>();
    public BoxCollider2D rebaseCollider2D;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<LadderGroundDetector>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            listOfAllGroundLadderDetection.Add("Player");
            LadderGroundDetector.baseOfLadder = rebaseCollider2D.isTrigger = true;
            LadderRebaseDetector.topEnterLadder = false;
            if (Input.GetKey(KeyCode.S) & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch") & !Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", false);
            else if (Input.GetKey(KeyCode.S) & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & PlayerMove.contactWithGround || Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W) & PlayerMove.contactWithGround || Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.W) & PlayerMove.contactWithGround)
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LadderRebaseDetector.topEnterLadder = false;
            rebaseCollider2D.isTrigger = true;
            if (Input.GetKey(KeyCode.S) & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouch") & !Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.W))
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", false);
            else if (Input.GetKey(KeyCode.S) & gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerClimb") & PlayerMove.contactWithGround || Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W) & DetectorGround.onGround || Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.W) & DetectorGround.onGround)
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LadderGroundDetector.baseOfLadder = false;
            if (Input.GetKey(KeyCode.S) & !ClimbingDetector.playerOnLadder || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", false);
            else if (Input.GetKey(KeyCode.W) & ClimbingDetector.playerOnLadder & !Input.GetKey(KeyCode.S) & PlayerMove.contactWithGround)
                gameObject.transform.parent.GetComponent<ClimbingDetector>().animatorPlayer.SetBool("UnderLadder", true);
            if (ClimbingDetector.playerOnLadder)
            {
                LadderRebaseDetector.topEnterLadder = false;
                rebaseCollider2D.isTrigger = true;
            }
            else
            {
                LadderRebaseDetector.topEnterLadder = true;
                rebaseCollider2D.isTrigger = false;
            }
        }
    }
}
