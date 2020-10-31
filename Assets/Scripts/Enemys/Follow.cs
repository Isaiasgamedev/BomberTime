using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float TimerUnfollow;
    public Transform TransformPlayer;
    Vector3 kickBomb;
    public float FollowSpeed;
    public float BackSpeed;
    public enum StateFollow { Follow, Unfollow, Wait}
    public StateFollow ControlFollow;
    public bool CanFollow;
    public bool KickBombOn = true;



    public GameObject bombPrefab;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        TransformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        CanFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        kickBomb = transform.position;
        switch (ControlFollow)
        {
            case StateFollow.Follow:
                _FollowPlayer();
                break;
            case StateFollow.Unfollow:
                _UnfollowPlayer();
                break;
            case StateFollow.Wait:
                break;
        }
        
    }

    public void _FollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        
        if (TransformPlayer.transform.position != transform.position)
        {            
            Vector3 movePosition = Vector3.MoveTowards(transform.position, TransformPlayer.position, FollowSpeed * Time.deltaTime);
            
            transform.position = movePosition;            
        }
    }

    public void _UnfollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        
        if (TransformPlayer.transform.position != transform.position)
        {
            Vector3 movePosition = Vector3.MoveTowards(transform.position, TransformPlayer.position, -BackSpeed * Time.deltaTime);
            transform.position = movePosition;
            TimerUnfollow += Time.deltaTime;
            if(TimerUnfollow > 3)
            {
                TimerUnfollow = 0;
                ControlFollow = StateFollow.Follow;
                CanFollow = true;
            }
        }
    }

    public void _DropBomb()
    {
        CanFollow = false;
        if (bombPrefab)
        { //Check if bomb prefab is assigned first

            GameObject go = Instantiate(bombPrefab, TransformPlayer.position,
            bombPrefab.transform.rotation);
            go.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            go.GetComponent<BombEnemies>().explode_size = 1;

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _DropBomb();
            ControlFollow = StateFollow.Unfollow;
        }
    
        if (collision.gameObject.tag == "Explosion")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            if (BomberTime.BomberTimeStart)
            {
                BomberTime.CountEnemys--;
            }

            Destroy(gameObject);
        }

        if (KickBombOn)
        {
            if (collision.gameObject.tag == "Bomb")
            {
                Debug.Log("BOMBA");
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(kickBomb * 2, ForceMode.Impulse);
            }
        }

       
    }


  
        
}
