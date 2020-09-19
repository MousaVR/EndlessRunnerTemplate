using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    bool grounded;
    bool stationary;
    int laneInitseleted;
    [SerializeField] Vector3Variable playerPos;
    [SerializeField] float objectHight;
    [SerializeField] float objectSpeed;

    bool goRight=true;
    Vector3 newPos;

    private void Start()
    {
        SetObjet();
        StartCoroutine(CheckDistanceFromthePlayer());
    }

    private void Update()
    {
        if (stationary) return;
        if (goRight)
        {
            if (transform.position.x < 2) newPos.x += (Time.deltaTime * objectSpeed);
            else goRight = false;
        }
        else
        {
            if (transform.position.x > -2) newPos.x -= (Time.deltaTime * objectSpeed);
            else goRight = true;
        }
        transform.position = newPos;
            
    }

    public void SetObjet()
    {
        RandomizeValues();
        SetObjectHight();
        SetObjectLane();
        newPos.z = transform.position.z;
        transform.position = newPos;
    }

    void RandomizeValues()
    {
        grounded = (Random.value >= 0.5) ? true : false;
        stationary = (Random.value >= 0.5) ? true : false;
        laneInitseleted = Random.Range(0, 3);
    }

    void SetObjectHight()
    {
        if (grounded) newPos.y = .2f;
        else newPos.y = 2;
    }

    void SetObjectLane()
    {
        if (laneInitseleted == 0) newPos.x=(-2);
        else if (laneInitseleted == 1) newPos.x=0;
        else newPos.x=2;
    }

    //using object pooling for generated object instead of re instiate it 
    IEnumerator CheckDistanceFromthePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if ((playerPos.Value.z - transform.position.z) > 2)
            {
                SetNewZ();
                SetObjet();
            }
        }
    }

    void SetNewZ()
    {
        float temp;
        temp = playerPos.Value.z + 95;
        transform.position = new Vector3(0,0,temp);
    }
}
