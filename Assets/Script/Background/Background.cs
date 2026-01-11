using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer background;
    private float width;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        width = background.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //배경 움직임 테스트용 호출 코드
        Move(2f); // 나중에 SceneController 에서 호출하도록 변경 시 이 코드는 지워야 함

        if (transform.position.x <= -width)
            ResetPosition();
    }

    void Move(float speed)
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void ResetPosition()
    {
        transform.Translate(Vector3.right * width * 2);
    }
}
