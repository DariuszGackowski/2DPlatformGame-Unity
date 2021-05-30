using UnityEngine;
public class HeaverTwo : MonoBehaviour
{
    public static bool heaverTwoIsReady = false;
    public Animator animatorHeaver;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<HeaverTwo>());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", true);
                HeaverTwo.heaverTwoIsReady = true;
            }
            else if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", false);
                HeaverTwo.heaverTwoIsReady = false;
            }
    }
}
