using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.LobbyRepo
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        public Text text;

        private void Start()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(10, 10000);
            Log("Player's name is set to " + PhotonNetwork.NickName);

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Log("Connected to master");
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 8 });

      
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            Log("Joined the room");
            PhotonNetwork.LoadLevel(1);
        }

        private void Log(string message)
        {
            Debug.Log(message);
            text.text += "\n" + message;
        }
    }
}

