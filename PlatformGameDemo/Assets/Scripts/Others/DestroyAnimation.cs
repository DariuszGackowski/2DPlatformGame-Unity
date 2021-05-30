using UnityEngine;
public class DestroyAnimation : MonoBehaviour
{
    void Start()
    {
        ScoreManager.listAllScripts.Add(gameObject.GetComponent<DetectorCrouching>());
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
