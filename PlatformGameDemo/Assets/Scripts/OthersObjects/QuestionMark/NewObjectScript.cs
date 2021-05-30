using UnityEngine;
public class NewObjectScript : MonoBehaviour
{
    public BoxCollider2D questionCollider;
    public GameObject parent, pathOfParent;
    public string parentName, grandParentName;
    private float step;
    public bool firstMove;
    private readonly float velocity = 3f;
    private readonly bool inDungeon = true;
    private void Start()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        FindingObjects();
        if (!inDungeon)
            RemovingScript();
    }
    private void Update()
    {
        if (transform.position.y == pathOfParent.transform.position.y)
            Invoke("WaitMomentThisIsYourTarget", 0f);
    }
    private void FixedUpdate()
    {
        if (transform.rotation.z != 0f)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (firstMove)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<PolygonCollider2D>(), questionCollider, true);
            step = velocity * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, pathOfParent.transform.position, step);  
        }
    }
    private void RemovingScript()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        Destroy(gameObject.GetComponent<NewObjectScript>());
    }
    private void FindingObjects()
    {
        pathOfParent = GameObject.Find( "/" + grandParentName + "/" + parentName + "/TargetPosition");
        parent = GameObject.Find("/" + grandParentName + "/" + parentName);
        questionCollider = parent.GetComponent<BoxCollider2D>();
        firstMove = true;
    }
}
