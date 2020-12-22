using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameRepo
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPref; 
        private Transform gunPref;
        private float shootOverheat = 0f;
        private PhotonView photonView;
        public Text text;

        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
            gunPref = gameObject.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }
            if (shootOverheat > 0) 
            { 
                Debug.Log(shootOverheat);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (shootOverheat > 3)
                {
                    text.text = "Wait for 2 sec. Overheat!";
                    StartCoroutine(OverHeat());
                }
                else
                {
                    shootOverheat++;
                    shootOverheat -= (Time.deltaTime * 4f);
                    PhotonNetwork.Instantiate(
                        bulletPref.name, gunPref.position, gunPref.rotation);
                }
            }
        }


        IEnumerator OverHeat()
        {
            yield return new WaitForSeconds(2f);
            text.text = "";
            shootOverheat = 0;
            PhotonNetwork.Instantiate(bulletPref.name, gunPref.position, gunPref.rotation);
        }
        
    }
}
