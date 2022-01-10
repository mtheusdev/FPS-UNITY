using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PhotonNetwork.Disconnect();
        }
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobby!");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause){
        // base.OnDisconnected();
        Debug.Log("Desconnected!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Não entrou em nenhuma sala");
        PhotonNetwork.CreateRoom(null, new RoomOptions());
    }

    public override void OnJoinedRoom(){
        Debug.Log("Entrei em uma sala!");
    }


}
