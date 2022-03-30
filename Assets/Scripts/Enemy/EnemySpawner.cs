using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Transform pointRightUp;
    [SerializeField] Transform pointLeftDown;

    [SerializeField] GameObject enemy;
    
    [SerializeField]float distance;

    private void Start()
    {
        StartCoroutine(SpawnerRoutine());
    }
    IEnumerator SpawnerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            CreateNewEnemy();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewEnemy();
        }
    }
    void CreateNewEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, GetRandomPosition(), Quaternion.identity, player.transform);
        MoveEnemyBehindPlayer(newEnemy);
    }
    //ќграничиваю по€вление врагов только за спиной игрока
    void MoveEnemyBehindPlayer(GameObject newEnemy)
    {
        newEnemy.transform.SetParent(player);
        if (newEnemy.transform.localPosition.z > 0)
        {
            newEnemy.transform.localPosition = new Vector3(newEnemy.transform.localPosition.x, newEnemy.transform.localPosition.y, newEnemy.transform.localPosition.z * -1);
        }
        newEnemy.transform.SetParent(null);
    }
    //ѕолучаю рандомную позицию
    Vector3 GetRandomPosition()
    {
        Vector3 randomCirclePos = Random.insideUnitCircle;

        Vector3 randomPos = player.position + new Vector3(randomCirclePos.x, 0, randomCirclePos.y) * GetDistanceToBounds();

        return randomPos;
    }
    //ќграничиваю спавн в пределах карты
    float GetDistanceToBounds()
    {
        float shortestDistance = 0, distanceA, distanceB, distanceC, distanceD;

        distanceA = pointRightUp.position.x - player.position.x;
        distanceB = pointRightUp.position.z - player.position.z;
        distanceC = pointLeftDown.position.x - player.position.x;
        distanceD = pointLeftDown.position.z - player.position.z;

        float[] distancesToBounds = { distanceA, distanceB, distanceC, distanceD};

        //ѕревращаю отрицательные числа в положительные
        for(int i = distancesToBounds.Length - 1; i >= 0; i--)
        {
            if (distancesToBounds[i] < 0)
            {
                distancesToBounds[i] = distancesToBounds[i] * -1;
            }
        }

        for(int i = distancesToBounds.Length - 1; i >= 0; i--)
        {
            if (i == distancesToBounds.Length - 1)
            {
               shortestDistance = distancesToBounds[i];
            }
            else
            {
                if(shortestDistance > distancesToBounds[i])
                {
                    shortestDistance = distancesToBounds[i];
                }
            }
        }
        return shortestDistance;
    }
}
