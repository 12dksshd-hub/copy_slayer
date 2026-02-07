using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer background;
    private float width;

    [SerializeField]
    private float speed;
    private int count;
    private bool enableAutoMove = true;

    public float Width
    {
        get { return width; }
    }

    public bool EnableAutoMove
    {
        get { return enableAutoMove; }
        set
        {
            enableAutoMove = value;
        }
    }

    void Awake()
    {
        width = background.bounds.size.x;
        UpdateBackgroundCount();
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

        if (enableAutoMove == true)
            Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void ResetPosition()
    {
        transform.Translate(Vector3.right * width * count);
    }

    private int GetCurrentBackgroundCount()
    {
        int count = FindObjectsByType<Background>(FindObjectsSortMode.None).Length;
        return count;
    }

    public void UpdateBackgroundCount()
    {
        count = GetCurrentBackgroundCount();
    }
}
