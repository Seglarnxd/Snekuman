using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ADT;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.up;
    private LList<Transform> snakeList;
    public Transform segmentPrefab;

    private void Start()
    {
        snakeList = new LList<Transform>();
        snakeList.AddLast(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (_direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        ListNode<Transform> currentNode = snakeList.Head;
        Vector3 temp = currentNode.data.position;
        while (currentNode.Nextnode != null)
        {
            (currentNode.Nextnode.data.position, temp) = (temp, currentNode.Nextnode.data.position);
                currentNode = currentNode.Nextnode;
        }
        var position = transform.position;
        position = new Vector3(Mathf.Round(position.x) + _direction.x, 
            Mathf.Round(position.y) + _direction.y, 0.0f);
                transform.position = position;
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = snakeList.Tail.data.position;
        
        snakeList.AddLast(segment);
    }

    private void ResetState()
    {
        Score.instance.Reset();
        ListNode<Transform> currentNode = snakeList.Head.Nextnode;
        while (currentNode != null)
        {
            Destroy(currentNode.data.gameObject);
            currentNode = currentNode.Nextnode;
        }
        
        snakeList.Clear();
        snakeList.AddFirst(transform);

        transform.position = Vector3.zero;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }
}