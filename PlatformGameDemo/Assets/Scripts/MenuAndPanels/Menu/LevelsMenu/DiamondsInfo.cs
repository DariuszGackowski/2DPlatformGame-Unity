using TMPro;
using UnityEngine;
public class DiamondsInfo : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = textMeshProUGUI.enabled ? true : false;
    }
}
