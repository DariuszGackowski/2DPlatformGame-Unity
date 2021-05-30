using UnityEngine;
public class Heaver : MonoBehaviour
{
    public Animator animatorHeaver;
    private void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<Heaver>());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInDownAnimation") & Input.GetKey(KeyCode.LeftControl))
                animatorHeaver.SetBool("MoveUp", true);
            if (animatorHeaver.GetCurrentAnimatorStateInfo(0).IsName("HeaverInUpAnimation") & Input.GetKey(KeyCode.LeftControl))
                animatorHeaver.SetBool("MoveUp", false);
        }
    }
}
