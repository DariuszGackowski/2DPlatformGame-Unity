using TMPro;
using UnityEngine;
public class InfoAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponent<Animator>().enabled = textMeshProUGUI.enabled ? true : false;
    }
}
