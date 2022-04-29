using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleInfo
{
    public string name; // S� pra mudar o nome do elemento e ficar bonito no editor
    public GameObject prefab;
    public float[] posX;
}

public class SpawningObstacle2 : MonoBehaviour
{
    public ObstacleInfo[] obstacles;

    public float spawnDelay = 1.4f; 

    void Start()
    {
        //adicionei um delay no primeiro par�metro pra n�o come�ar j� com objeto na cara
        InvokeRepeating("SpawnObstacle", 1f, spawnDelay); 
    }

    void SpawnObstacle()
    {
        //sorteia o objeto
        int obstacle = Random.Range(0, obstacles.Length);

        //sorteia a posi��o entre uma das poss�veis para o objeto
        int randomPosX = Random.Range(0, obstacles[obstacle].posX.Length);

        Vector3 pos = new Vector3(obstacles[obstacle].posX[randomPosX], 0f, 100f);

        Instantiate(obstacles[obstacle].prefab, pos, obstacles[obstacle].prefab.transform.rotation);
    }
}

