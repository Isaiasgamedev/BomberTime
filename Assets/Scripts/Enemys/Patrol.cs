using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public int SideControl = 0;
    private Player PatrolPlayer;
    public GameObject bombPrefab;
    public GameObject BombPosition;
    public ParticleSystem explosion;
    public GameObject[] Walls;   
    public Transform[] PositionsControl; 
    public static bool CanMove = false;

    // Update is called once per frame
    void Update()
    {
        

        if (!CanMove) return;

        _Patrolrun();   
    }

    public void _Patrolrun()
    {
        if (SideControl == 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            if (Mathf.Abs(transform.localPosition.x) <= Mathf.Abs(PositionsControl[0].localPosition.x))
            {               
                SideControl = 1;
                _DropBomb();
            }
        }

        if (SideControl == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
            if (Mathf.Abs(transform.localPosition.z) <= Mathf.Abs(PositionsControl[1].localPosition.z))
            {
                SideControl = 2;
                _DropBomb();
            }
        }

        if (SideControl == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            if (Mathf.Abs(transform.localPosition.x) >= Mathf.Abs(PositionsControl[2].localPosition.x))
            {
                SideControl = 3;
                _DropBomb();
            }
        }

        if (SideControl == 3)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 270, transform.rotation.z);
            if (Mathf.Abs(transform.localPosition.z) >= Mathf.Abs(PositionsControl[3].localPosition.z))
            {
                SideControl = 0;
                _DropBomb();
            }
        }
    }

    public void _DropBomb()
    {
        if (bombPrefab)
        { //Check if bomb prefab is assigned first
            GameObject go = Instantiate(bombPrefab, BombPosition.transform.position,
            bombPrefab.transform.rotation);

            go.GetComponent<BombEnemies>().explode_size = 2;            
            
        }
       
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Explosion")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            for (int i = 0; i < Walls.Length; i++)
            {
                if(Walls[i] != null)
                {
                    Destroy(Walls[i]);
                }
            }

            if (BomberTime.BomberTimeStart)
            {
                BomberTime.CountEnemys--;
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            Debug.Log("BOMBA");
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
