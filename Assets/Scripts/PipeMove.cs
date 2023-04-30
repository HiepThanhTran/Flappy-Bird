using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float moveSpeed;
    public float oldPosition;
    public float minY;
    public float maxY;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ResetPipe"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }
    }
}
