using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public float speed = 8.0f;
    public static bool charge = true;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player.transform.position = respawnPoint;
    }

    // Update is called once per frame
    void Update()
    {

        var cubeRenderer = player.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.blue);


        //if (charge == true)
        //{
        //    cubeRenderer.material.SetColor("_Color", Color.red);
        //}

        //if (charge == false)
        //{
        //    cubeRenderer.material.SetColor("_Color", Color.blue);
        //}

        if (Input.GetKey(KeyCode.Space) && (charge == true))
        {
            rb.velocity = new Vector3(0.0f, speed, 0.0f);
            //charge = false;
            //Debug.Log("Forward");
        }

        else if (Input.GetKey(KeyCode.LeftShift) && (charge == true))
        {
            rb.velocity = new Vector3(0.0f, -speed, 0.0f);
            //charge = false;
            //Debug.Log("Back");
        }

        else if (Input.GetKey(KeyCode.RightArrow) && (charge == true))
        {
            rb.velocity = new Vector3(speed, 0.0f, 0.0f);
            //charge = false;
            //Debug.Log("Right");
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && (charge == true))
        {
            rb.velocity = new Vector3(-speed, 0.0f, 0.0f);
            //charge = false;
            //Debug.Log("Left");
        }

        else if (Input.GetKey(KeyCode.UpArrow) && (charge == true))
        {
            rb.velocity = new Vector3(0.0f, 0.0f, speed);
            //charge = false;
            //Debug.Log("Up");
        }

        else if (Input.GetKey(KeyCode.DownArrow) && (charge == true))
        {
            rb.velocity = new Vector3(0.0f, 0.0f, -speed);
            //charge = false;
            //Debug.Log("Down");
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Platform"))
        {
            charge = true;
            //Could potentially turn into a OnCollisionEnter
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
            charge = false;
        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            charge = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Died");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Recharge"))
        {
            Debug.Log("New Charge");
            charge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Recharge"))
        {
            Debug.Log("Lost Charge");
            charge = false;
        }
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}