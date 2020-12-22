using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CamScript : MonoBehaviour
{

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        float vertical = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Mouse X");

        //transform.localEulerAngles += 0.0001f * rotation;
        

        //Debug.Log(transform.rotation.eulerAngles.x);
        
     
        Vector3 rotation = new Vector3(-1 * vertical, 0, 0);
        Vector3 vector = new Vector3(0, -1 * vertical * 0.01f, 0);
        transform.position += vector;
        transform.localEulerAngles += 0.5f * rotation;
 
       
        if (transform.rotation.eulerAngles.x <= 2.5f)
        {
            transform.position -= vector;
            transform.localEulerAngles -= 0.5f * rotation;

        }
        if (transform.rotation.eulerAngles.x >= 35f)
        {
            transform.position -= vector;
            transform.localEulerAngles -= 0.5f * rotation;
        } 
    }
}

