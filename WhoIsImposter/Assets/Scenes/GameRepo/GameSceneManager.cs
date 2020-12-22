using Photon.Pun;
using UnityEngine;

namespace Scenes.GameRepo
{
    public class GameSceneManager : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            
            //spawn1
            Vector3 pos = new Vector3(
                Random.Range(-3.4f, -4.4f), 0.5f, -10);
            //spawn2
            Vector3 pos1 = new Vector3(
                Random.Range(9.8f, 11.2f), 0.5f, -10);

            System.Random sysRnd = new System.Random();

            if (sysRnd.Next(1, 2) == 1)
            {
                PhotonNetwork.Instantiate(PlayerPrefs.GetString("prefabName"), 
                    pos, Quaternion.identity);
            }
            else
            {
                PhotonNetwork.Instantiate(PlayerPrefs.GetString("prefabName"),
                    pos1, Quaternion.identity);
            }
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
