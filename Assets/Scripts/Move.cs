using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;

    public GameObject center;

    public GameObject front;
    public GameObject back;
    public GameObject right;
    public GameObject left;

    public float step = 9;
    public float speed = 0.01f;
    private bool input = true;

    // Start is called before the first frame update
    void Start()
    {
        moveOrigins();
    }

    // Update is called once per frame
    void Update()
    {
        if (input)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(nameof(moveFront));
                input = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(nameof(moveBack));
                input = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(nameof(moveRight));
                input = false;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(nameof(moveLeft));
                input = false;
            }
        }
    }

    private IEnumerator moveFront()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(front.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }

        moveOrigins();
        input = true;
    }

    private IEnumerator moveBack()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(back.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }

        moveOrigins();
        input = true;
    }

    private IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }

        moveOrigins();
        input = true;
    }

    private IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }

        moveOrigins();
        input = true;
    }

    private void moveOrigins()
    {
        player.transform.position = new Vector3(
            (float) Math.Round(player.transform.position.x),
            (float) Math.Round(player.transform.position.y),
            (float) Math.Round(player.transform.position.z)
        );
        center.transform.position = player.transform.position;
        Vector3 size = player.GetComponent<MeshRenderer>().bounds.size;
        front.transform.localPosition = new Vector3(0, -size.y / 2, size.z / 2);
        back.transform.localPosition = new Vector3(0, -size.y / 2, -size.z / 2);
        right.transform.localPosition = new Vector3(size.x / 2, -size.y / 2, 0);
        left.transform.localPosition = new Vector3(-size.x / 2, -size.y / 2, 0);
    }
}