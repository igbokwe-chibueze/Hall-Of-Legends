using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Transform barrel;
    public AudioClip shootSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject spawnedBullet = Instantiate (bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(shootSound);
        Destroy(spawnedBullet, 2);
    }
}
