using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class camera : MonoBehaviour
{
    public GameObject Player;
    public float speed = 20;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;
    public GameObject Wintext;
    public float TBT;
    private int Count;
    [SerializeField] TextMeshProUGUI CountText1;
    [SerializeField] TextMeshProUGUI CountTime1;
    public Vector3 one = new Vector3(0.8f, 0, 0);
    public Vector3 two = new Vector3(-0.8f, 0, 0);
    public Vector3 three = new Vector3(0, 0, 0.8f);
    public Vector3 four = new Vector3(0, 0, -0.8f);
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        Counth();
        TBT = 420; //The variable for counting time
        CountTimehh();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        horizontalInput= Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");   
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            transform.Translate(Vector3.forward*Time.deltaTime*speed*(-1));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rotate the sprite about the Z axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed*5);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate the sprite about the Z axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed*5);
        }
        tbt();

        if (TBT > 0){
            if(Count == 6){
                print("you won the game! Play again?");
                SceneManager.LoadScene("enscene1");
                
            }
        }
        else {
            print("you lost the game! Try again?");
            transform.position = new Vector3(82,1,82);
            SceneManager.LoadScene("endscene");
        }

    }
    void tbt(){
        TBT -= Time.deltaTime;
        CountTimehh();
    }
    void CountTimehh()
    {
        CountTime1.text = "your time left: " + TBT.ToString() +("sec");
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            transform.Rotate(new Vector3(0,180,0));
            print("ENTER");
           
        }
        
        if (other.gameObject.tag == "key")
        {
            Destroy(other.gameObject);
            Count += 1;
            Debug.Log(Count);
            Counth();
        }
    }
    
    void Counth()
    {
        CountText1.text = "Keys collected: " + Count.ToString()+ "/6";
    }
}

