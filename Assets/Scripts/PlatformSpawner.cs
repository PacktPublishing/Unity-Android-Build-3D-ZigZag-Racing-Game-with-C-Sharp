using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;
    bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.transform.position;

        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            stop = true;
        }
    }

    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            GeneratePosition();

            Instantiate(platform, newPos, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);

            lastPosition = newPos;
        }



    }

    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if (rand > 0)
        {
            //spawn on left
            newPos.x += 2f;
        }
        else
        {
            //spawn on right
            newPos.z += 2f;
        }

        
    }
}
