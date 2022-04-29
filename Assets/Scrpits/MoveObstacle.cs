using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public GameObject player;

    float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        DestroyObstacle();
    }

    void DestroyObstacle()
    {
        if(transform.position.z < player.transform.position.z - 10)
        {
            Destroy(this.gameObject);
        }
    }
}