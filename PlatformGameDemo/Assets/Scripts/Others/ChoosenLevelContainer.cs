using UnityEngine;
public class ChoosenLevelContainer : MonoBehaviour
{
    public static int choiceNumber;
    private GameObject[] choosenLevelContainers;
    private void Start()
    {
         choosenLevelContainers = GameObject.FindGameObjectsWithTag("ChoosenLevelContainer");
        if ( choosenLevelContainers.Length > 1)
            for (int i = 1; i <  choosenLevelContainers.Length; i++)
                Destroy( choosenLevelContainers[i]);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
