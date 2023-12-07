using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad_Move1 : MonoBehaviour
{
    //variable for movement
    public float speed = .0125f;
    public float yBorder = 7f;

    public GameObject Pad2;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < yBorder)    //when Up is pressed
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);   //move up
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -yBorder)    //when Down is pressed
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed); //move down
        }
        
    }
}
