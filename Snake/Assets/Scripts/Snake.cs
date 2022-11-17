using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;

    [SerializeField] private GameObject segmentPrefab;
    LinkedList linkedList;

    public bool died = false;

    void Start()
    {
        linkedList = new LinkedList();
        linkedList.AddNode(this.gameObject);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
    }

    void FixedUpdate()
    {
        LinkedListNode runner = linkedList.head;

        for (int i = 1; i < linkedList.count; i++)
        {
            runner.segment.transform.position = runner.next.segment.transform.position;
            runner = runner.next;

        }


        transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x, 
            Mathf.Round(transform.position.y) + direction.y, transform.position.z);
    }

    void Grow()
    {
        var segment = Instantiate(segmentPrefab);

        Vector3 lastNodePosition = Vector3.zero;
        LinkedListNode runner = linkedList.head;

        for (int i = 1; i < linkedList.count; i++)
        {
            runner = runner.next;
        }

        lastNodePosition = runner.segment.transform.position;

        segment.transform.position = lastNodePosition;

        linkedList.AddNode(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            died = true;
        }
    }


    class LinkedListNode
    {
        public GameObject segment;
        public LinkedListNode next;

        public LinkedListNode(GameObject x)
        {
            segment = x;
            next = null;
        }
        
    }
    class LinkedList
    {
        public int count;
        public LinkedListNode head;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public void AddNode(GameObject segment)
        {
            LinkedListNode node = new LinkedListNode(segment);
            node.next = head;
            head = node;


            count++;
        }
    }

}

