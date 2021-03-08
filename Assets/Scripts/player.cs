using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D myBody;
    //BoxCollider2D myCollider;
    SpriteRenderer myRenderer;
    
    //public Sprite brokenPot;

    float moveDirX;
    float moveDirY;
    public float speed;
    public float speedLim = 0.7f;

    public int numOfBooks;
    public bool key = false;
    //public static bool faceRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity = new Vector3(0,0,0);
        myBody = gameObject.GetComponent<Rigidbody2D>(); 
        //myBody.velocity = Vector2.zero;
        //myCollider = gameObject.GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move(){
        moveDirX = Input.GetAxis("Horizontal");
        moveDirY = Input.GetAxis("Vertical");

        if(moveDirX > 0){
            myRenderer.flipX = false;
        }
        else if(moveDirX < 0){
            myRenderer.flipX = true;
        }

        if (moveDirX !=0 && moveDirY !=0){
            moveDirX *= speedLim;
            moveDirY *= speedLim;
        }
        //transform.Translate(Vector3.up*moveDirY*Time.deltaTime*speed);
        //transform.Translate(Vector3.right*moveDirX*Time.deltaTime*speed);
        myBody.velocity = new Vector2(moveDirX*speed, moveDirY*speed);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "book"){
            Renderer temp = (Renderer) other.gameObject.GetComponent<Renderer>();
            if(temp.enabled && other!=null){
                temp.enabled = false;
                Destroy(other.gameObject);
                numOfBooks++;
            }
        }


        // if(other.gameObject.tag == "pot"){
        //     pot potScript = (pot)other.gameObject.GetComponent(typeof(pot));
        //     SpriteRenderer potSpr = (SpriteRenderer)other.gameObject.GetComponent<SpriteRenderer>();

        //     potSpr.sprite = brokenPot;
        //     potScript.isBookVisible = true;
        // }

         
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "person_rabbit"){
            key = true;
        }

        if(other.gameObject.name =="gate" && key){
            Destroy(other.gameObject);
        }
    }
}
