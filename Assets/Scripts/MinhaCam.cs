using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinhaCam : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        Instantiate(cam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
