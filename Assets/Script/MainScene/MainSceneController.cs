using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject backgroundObj;
    private Background backgroundComponent;
    private Background backgroundComponent2;

    [SerializeField]
    private GameObject playerObj;
    private Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundComponent = backgroundObj.GetComponent<Background>();

        Vector3 backgroundPosition = backgroundComponent.transform.position;
        backgroundComponent2 = Instantiate<Background>(
            backgroundComponent,
            new Vector3(backgroundPosition.x + backgroundComponent.Width, backgroundPosition.y, backgroundPosition.z),
            Quaternion.identity);

        playerAnimator = playerObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("run") == true)
        {
            MoveBackground();
        }
    }

    private void MoveBackground()
    {
        backgroundComponent.Move();
        backgroundComponent2.Move();
    }
}
