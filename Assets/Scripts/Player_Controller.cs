
using UnityEngine;
using System.Collections;
using System;

public class Player_Controller : Controller
{
    private string FireAxis = "Fire 1";
    public enum Players { Player1, Player2 };
    public Players PlayerControl;
    public bool canDropBombs = true;
    public KeyCode Press;
    //Can the player drop bombs?
    public bool canMove = true;
    //Can the player move?

    //Prefabs
    public GameObject bombPrefab;
    //Cached components
    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;
    private Player player;
    private bool mobile;
    public GameObject BombPosition;


    // Use this for initialization
    void Start ()
    {
	    if (Application.CanStreamedLevelBeLoaded("Game"))
        {
		    mobile = false;
	    }

        else
        {
		    mobile = true;	
	    }

        player = GetComponent<Player>();
        //Cache the attached components for better performance and less typing
        rigidBody = GetComponent<Rigidbody> ();
        myTransform = transform;
        animator = myTransform.Find ("PlayerModel").GetComponent<Animator> ();
    }

  

  // Update is called once per frame
    void Update ()
    {
        UpdateMovement ();
    }

    
    private void UpdateMovement ()
    {
        animator.SetBool ("Walking", false);



        //Depending on the player number, use different input for moving
        UpdatePlayer2Movement ();
    }

   

    /// <summary>
    /// Updates Player 2's movement and facing rotation using the arrow keys and drops bombs using Enter or Return
    /// </summary>
    private void UpdatePlayer2Movement ()
    {
        if (PlayerControl == Players.Player1)
        {
            Vector3 vel = new Vector3 (Input.GetAxis("Horizontal")*player.moveSpeed, rigidBody.velocity.y, Input.GetAxis("Vertical")*player.moveSpeed);
            if(vel != rigidBody.velocity)
            {
                rigidBody.velocity = vel;
                myTransform.rotation = Quaternion.Euler (0, FindDegree(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical")), 0);
                animator.SetBool ("Walking", true);
            }

            if (canDropBombs && (Input.GetKeyDown(Press)))
            { //Drop Bomb. For Player 2's bombs, allow both the numeric enter as the return key or players 
              //without a numpad will be unable to drop bombs

                DropBomb();

            }
        }


        else if (PlayerControl == Players.Player2)
        {
            Vector3 vel = new Vector3(Input.GetAxis("Horizontal2") * player.moveSpeed, rigidBody.velocity.y, Input.GetAxis("Vertical2") * player.moveSpeed);
            if (vel != rigidBody.velocity)
            {
                rigidBody.velocity = vel;
                myTransform.rotation = Quaternion.Euler(0, FindDegree(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")), 0);
                animator.SetBool("Walking", true);
            }

            if (canDropBombs && (Input.GetKeyDown(Press)))
            { //Drop Bomb. For Player 2's bombs, allow both the numeric enter as the return key or players 
              //without a numpad will be unable to drop bombs

                DropBomb();

            }

        }






       
    }

     public static float FindDegree(float x, float y){
     float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
     if(value < 0) value += 360f;
 
     return value;
 }

    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    public void DropBomb ()
    {
        if(player.bombs != 0)
        {

            player.bombs--;

            if (bombPrefab)
            { //Check if bomb prefab is assigned first
                GameObject go = Instantiate(bombPrefab, BombPosition.transform.position,
                bombPrefab.transform.rotation);

                go.GetComponent<Bomb>().explode_size = player.explosion_power;
                go.GetComponent<Bomb>().player = player;
                if(player.canKick)
                {
                    go.GetComponent<Rigidbody>().isKinematic = false; // make bomb kickable
                }
            }
        }
    }
}
