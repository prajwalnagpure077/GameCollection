using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpaceEnemyDetails : MonoBehaviour
{
    public int Points;

    public void ShootProjectile()
    {
        if (Time.timeScale > 0)
        {
            Instantiate(SpaceManager.instance.EnemyProjectile, transform.position, Quaternion.identity);

        }
    }
}
