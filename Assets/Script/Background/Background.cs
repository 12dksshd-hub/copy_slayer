using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer background;
    private float width;

    [SerializeField]
    private float speed;

    public float Width
    {
        get { return width; }
    }

    void Awake()
    {
        width = background.bounds.size.x;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
            ResetPosition();
    }

    public void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void ResetPosition()
    {
        transform.Translate(Vector3.right * width * 2);
    }
}
