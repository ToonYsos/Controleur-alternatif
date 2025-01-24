using UnityEngine;

public class InstantiateEnnemis : MonoBehaviour
{
    public GameObject ennemies;
    public int timeBetweenSpawn = 6;
    void Start()
    {
        InvokeRepeating("Instantiate", 0, timeBetweenSpawn);
    }

    void Instantiate()
    {
        Vector3 whereAreYou = new Vector3(transform.position.x, transform.position.y, Random.Range(-15.485f, 19.472f));
        Instantiate(ennemies, whereAreYou, Quaternion.identity);
    }
}
