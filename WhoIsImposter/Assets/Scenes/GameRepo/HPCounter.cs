using System.Security.Cryptography;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameRepo
{
    public class HPCounter : MonoBehaviour
    {
        [SerializeField] private Text text;
        private GameObject player;
        void Start()
        {
            player = GameObject.FindGameObjectsWithTag("Player")[1];
            Debug.Log(player.name);
        }

        void Update()
        {
            text.text = "" + player.GetComponent<HpPlayer>().hp +
                        "/" + player.GetComponent<HpPlayer>().fullHp;
        }

    
        
    }
}
