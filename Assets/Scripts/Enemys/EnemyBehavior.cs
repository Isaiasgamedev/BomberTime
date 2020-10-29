using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            if (BomberTime.BomberTimeStart)
            {
                BomberTime.CountEnemys--;
            }

            Destroy(gameObject);
        }
    }
}
