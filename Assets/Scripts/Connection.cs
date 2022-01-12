using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject painelLogin, painelRoom;
    [SerializeField]
    private InputField playerName, roomName;
    // [SerializeField]
    // private Text txtPing;
    [SerializeField]
    public GameObject[] Player;
    
    public int id;

    public static Connection instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Login() {
        PhotonNetwork.NickName = playerName.text;
        PhotonNetwork.ConnectUsingSettings();
        painelLogin.SetActive(false);
        painelRoom.SetActive(true);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.Space)) {
    //     //     PhotonNetwork.Disconnect();
    //     // }
    //     txtPing.text = "Ping: " + PhotonNetwork.GetPing().ToString();
    // }

    public void CreateRoom() {
        PhotonNetwork.JoinOrCreateRoom(roomName.text, new RoomOptions(), TypedLobby.Default);
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobby!");
        // PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("Desconnected!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Não entrou em nenhuma sala");
        // PhotonNetwork.CreateRoom(null, new RoomOptions());
    }

    public override void OnJoinedRoom(){
        Debug.Log("Entrei em uma sala!");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        // print(PhotonNetwork.NickName);
        // painelRoom.SetActive(false);
        // PhotonNetwork.Instantiate(Player.name, new Vector3(Random.Range(1,8), 2, Random.Range(1,8)), Quaternion.identity , 0);
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void SetID(int ID) {
        id = ID;
    }
}
