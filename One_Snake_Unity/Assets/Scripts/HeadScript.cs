using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeadScript : MonoBehaviour
{

    public GameObject tailBit;
    public float moveSpeed;

    private Vector3 direction, up, down, right, left;
    private bool snakeAte;
    private List<GameObject> tail;


    // Use this for initialization
    void Start()
    {
        tail = new List<GameObject>();
        snakeAte = false;
        moveSpeed = 0.1f;
        up = new Vector3(0f, 0f, 1f);
        down = new Vector3(0f, 0f, -1f);
        right = new Vector3(1f, 0f, 0f);
        left = new Vector3(-1f, 0f, 0f);

        // initially go up
        direction = up;

        Invoke("movement", moveSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputManagement();
      //  movement();
    }

    // check for key press and do movement
    void movement()
    {
        // take the head position
        Vector3 tempHeadPos = transform.position;

        // move head in the desired direction
        transform.position += /*Time.deltaTime * 5f **/direction;

        moveSnakeTail(tempHeadPos);

        // call itself to move
        Invoke("movement", moveSpeed);
    }

    void inputManagement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction = up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction = down;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = right;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = left;
    }

    // if it collides with something
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hello");

        if (other.name.StartsWith("food"))
        {
            Destroy(other.gameObject);
            snakeAte = true;
            growSnake();
            Debug.Log(snakeAte);
        }
    }


    // moves the  tail of the snake
    void moveSnakeTail(Vector3 previousHeadPos)
    {

        Vector3 newTailBitPos;
        if (tail.Count < 1) newTailBitPos = previousHeadPos;
        else newTailBitPos = tail[tail.Count - 1].transform.position;

        for (int i = tail.Count - 1; i > 0; i--)
        {
            tail[i].transform.position = tail[i - 1].transform.position;
        }
        if (tail.Count > 0)
            tail[0].transform.position = previousHeadPos;

        if (snakeAte)
        {
            tail.Add(Instantiate(tailBit, newTailBitPos, Quaternion.identity) as GameObject);
            snakeAte = false;
            return;
        }

        
        
    }


    void growSnake()
    {

    }

}
