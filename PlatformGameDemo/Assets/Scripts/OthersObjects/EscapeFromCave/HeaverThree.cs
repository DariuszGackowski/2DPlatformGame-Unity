using UnityEngine;
public class HeaverThree : MonoBehaviour
{
    public static bool heaverThreeIsReady = false;
    public Animator animatorHeaver;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<HeaverThree>());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", true);
                HeaverThree.heaverThreeIsReady = true;
            }
            else if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", false);
                HeaverThree.heaverThreeIsReady = false;
            }
    }
}
