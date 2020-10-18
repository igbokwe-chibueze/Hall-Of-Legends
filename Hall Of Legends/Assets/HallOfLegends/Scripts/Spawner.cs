using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject loots;

    float spawnFrequency = 35f;

    public bool noLooping = true;
    // Start is called before the first frame update
    void Start()
    {
        SpawnIteams();
        if (noLooping == false)
        {
            InvokeRepeating ("SpawnIteams", spawnFrequency, spawnFrequency);
        }
    }

    void SpawnIteams()
    {
        Instantiate (loots, gameObject.transform.position, Quaternion.identity);
    }
}
