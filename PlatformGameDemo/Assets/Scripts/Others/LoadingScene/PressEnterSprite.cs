using UnityEngine;
public class PressEnterSprite : MonoBehaviour
{
    private float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time <= 0.5f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else if (time>0.5f & time <= 1f)
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        else if (time>1f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            time = 0f;
        }
    }
}
