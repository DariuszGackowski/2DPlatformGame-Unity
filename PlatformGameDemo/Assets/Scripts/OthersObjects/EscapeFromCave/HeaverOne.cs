using UnityEngine;
public class HeaverOne : MonoBehaviour
{
    public static bool heaverOneIsReady = false;
    public Animator animatorHeaver;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<HeaverOne>());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", true);
                HeaverOne.heaverOneIsReady = true;
            }
            else if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation") & Input.GetKey(KeyCode.LeftControl))
            {
                animatorHeaver.SetBool("MoveUp", false);
                HeaverOne.heaverOneIsReady = false;
            }
    }
}
