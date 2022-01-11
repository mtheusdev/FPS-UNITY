using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoveBala : MonoBehaviour
{
    private Rigidbody bala;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {   
        bala = GetComponent<Rigidbody>();
        bala.AddRelativeForce(Vector3.forward * 60, ForceMode.Impulse);
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().IsMine) {
            this.GetComponent<PhotonView>().RPC("MataBala", RpcTarget.All);
            col.GetComponent<Move>().Danos(50);
        }
    }

    [PunRPC]
    void MataBala(){
        Destroy(this.gameObject);
    }
}
