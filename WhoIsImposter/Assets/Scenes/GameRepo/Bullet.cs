using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Scenes.GameRepo
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] private int bulletSpeed;
        private PhotonView photonView;

        private float destroyTime = 2f;

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }
        
        // Start is called before the first frame update
        void Start()
        {
            photonView = gameObject.GetComponent<PhotonView>();
            StartCoroutine(DestroyBullet());
        }

        // Update is called once per frame
        void Update()
        {
            Shooting();
        }

        private void Shooting()
        {
            transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, 2))
            {
                if (raycastHit.collider.CompareTag("Player"))
                {
                    Debug.Log(raycastHit.collider.name);
                    raycastHit.collider.GetComponent<HpPlayer>().SetDamage(5);
                    Destroy(gameObject);

                }

            }
        }

      
    }
}
