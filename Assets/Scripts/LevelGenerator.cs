using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] List< GameObject> collectables ;
    [SerializeField] GameObject obstacle;
    [SerializeField] float levelGeneratoroffset = 20f;
    bool generateObstacle;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            generateObstacle=(Random.value >= 0.5) ? true : false;
            if (generateObstacle)
            {
                Instantiate(obstacle, new Vector3(0, 0, (i * 10) + levelGeneratoroffset), Quaternion.identity);
            }
            else
            {
                int temp=Random.Range(0,collectables.Count);
                Instantiate(collectables[temp], new Vector3(0, 0, (i * 10 ) + levelGeneratoroffset), collectables[temp].transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
