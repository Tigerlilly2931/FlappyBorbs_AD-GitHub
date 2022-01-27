using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumnPool : MonoBehaviour
{
    public int columnSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public Borb birdy;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectColPos = new Vector2(-15, -25);
    private float timeSinceLastSpawn;
    private float spawnXPos = 10f;
    private int currentColumn = 0;
    // Start is called before the first frame update
    void Start()
    {
        birdy = GameObject.Find("Dargon").GetComponent<Borb>();
        columns = new GameObject[columnSize];
        for(int i = 0; i < columnSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectColPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!birdy.isDed && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos, spawnYPos);
            currentColumn++;
            if(currentColumn >= columnSize)
            {
                currentColumn = 0;
            }
        }

    }
}
