using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public GameObject socket;
    public Input tagName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Ball") || other.CompareTag("Helmet"))
        {
            socket.SetActive(true);
        }else
            {
                socket.SetActive(false);
            }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Ball") || other.CompareTag("Helmet"))
        {
            socket.SetActive(false);
        }else
            {
                socket.SetActive(true);
            }
    }
}
