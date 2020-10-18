using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerAlways : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        this.transform.LookAt(player.transform);
    }

    public void DialogueOne()
    {
        FindObjectOfType<AudioManager>().Play("DialogueOne");
    }
    public void DialogueTwo()
    {
        FindObjectOfType<AudioManager>().Play("DialogueTwo");
    }
    public void DialogueThree()
    {
        FindObjectOfType<AudioManager>().Play("DialogueThree");
    }
    public void DialogueFour()
    {
        FindObjectOfType<AudioManager>().Play("DialogueFour");
    }
}
