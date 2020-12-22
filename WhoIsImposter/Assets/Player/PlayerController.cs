
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Camera camera;
    [SerializeField] [Header("Gun Animator")] 
    private Animator animatorGun;
    [SerializeField] [Header("Player Animator")] private Animator animator;

    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            camera.enabled = false;
            return;
        }
        MoveMethod();
    }

    private void MoveMethod()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SetBool(true);
            transform.position += transform.forward * (speed * Time.deltaTime);
            leftRight();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetBool(true);
            transform.position -= transform.forward * (speed * Time.deltaTime);
            leftRight();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            leftRight();
        }
        else
        {
            SetBool(false);
        }
        
        float horizontal = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0, horizontal, 0);
        transform.Rotate(4 * rotation);
    }

    private void leftRight()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (rotationSpeed * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * (rotationSpeed * Time.deltaTime);
        }
    }

    private void SetBool(bool value)
    {
        animator.SetBool("walk", value);
        animatorGun.SetBool("walk", value);
    }
}



