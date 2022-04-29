using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance;
    public float smooth;
    public bool gameOver;

    float height;
    int desiredLane;

    private void Awake()
    {
        height = transform.localScale.y / 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        desiredLane = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.x * Vector3.zero + new Vector3(0, height, 0);

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over"); 
            //particles
            //sound
        }
    }
}
