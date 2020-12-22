using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class SpaceShipManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject leaveButton;

    [SerializeField] private GameObject startCanvas;

    [SerializeField] private List<GameObject> playerPrefabs;
    
    private bool flag;
    private bool master;



    // Start is called before the first frame update
    void Start() {
        flag = false;
        leaveButton.SetActive(flag);
        string playerPrefabName;
        
        System.Random random = new System.Random();
        
        String[] prefabNamesReserved = new String[1];
        prefabNamesReserved[0] = "null";

        
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerPref")) {
            prefabNamesReserved = (string[]) PhotonNetwork.CurrentRoom
                .CustomProperties["PlayerPref"];
        }
        

        //delete reserved prefs in our client


        for (int i = 0; i < playerPrefabs.Count; i++)
        {
            if (prefabNamesReserved.Contains(playerPrefabs[i].name))
            {
                playerPrefabs.RemoveAt(i); 
               
            }
        }

       
        // get random pref
        int randomIndex = random.Next(0, playerPrefabs.Count);
        playerPrefabName = playerPrefabs[randomIndex].name;

        // save chosen prefab to Photon
        ExitGames.Client.Photon.Hashtable hashtable =
            new ExitGames.Client.Photon.Hashtable();
        String[] prefabNamesReservedNew = new String[prefabNamesReserved.Length + 1];

        for (int i = 0; i < prefabNamesReservedNew.Length - 1; i++)
        {
            prefabNamesReservedNew[i] = prefabNamesReserved[i];
        }
        prefabNamesReservedNew[prefabNamesReserved.Length] = playerPrefabName;
        
        hashtable.Add("PlayerPref", prefabNamesReservedNew);
        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
        
        // spawn prefab
        Vector3 pos = new Vector3(
        Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        PhotonNetwork.Instantiate(playerPrefabName, pos, Quaternion.identity);


        // save data
        PlayerPrefs.SetString("prefabName", playerPrefabName);
        
        // disable start-game window
        startCanvas.SetActive(false);
 
    }


    // Update is called once per frame
    void Update()
    {
        master = PhotonNetwork.IsMasterClient;
        StartGame();
        OnEscapeKey();
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        if (master) {
            startCanvas.SetActive(true);
        
        }
    }

    public void StartButton()
    {
        if (PhotonNetwork.PlayerList.Length >= 1)
        {
            PhotonNetwork.LoadLevel(2);
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("Недостаточно игроков.");
        }
    }

    private void OnEscapeKey()
    {
      
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            flag = !flag;
            leaveButton.SetActive(flag);
                     
        }


    }





}
