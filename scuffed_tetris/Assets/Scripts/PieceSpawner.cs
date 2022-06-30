using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject piece5;
    public LayerMask groundLayer;
    public GameObject a;
    public float time = 1.0f;
    public bool IsGroundedVar;
    List<Vector2> gameObjectCenters = new List<Vector2>();
    public int tileType;
    public Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            time = 0.1f;
        }
    }

    private bool IsGrounded()
    {
        findCenters();
        bool floorHit = false;
        foreach (var centerCoord in gameObjectCenters)
        {
            Vector2 position = centerCoord;
            Vector2 direction = Vector2.down;
            float distance = 1.0f;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

            if (hit.collider != null)
            {
                floorHit = true;
            }
        }
        return floorHit;
    }

    private void spawnTile()
    {
        gameObjectCenters.Clear();
        int roll = Random.Range(1, 6);
        tileType = roll;
        switch (roll)
        {
            case 1:
                a = Instantiate(piece1);
                a.transform.position = new Vector2(0.0f, 10.5f);
                break;
            case 2:
                a = Instantiate(piece2);
                a.transform.position = new Vector2(0, 11);
                break;

            case 3:
                a = Instantiate(piece3);
                a.transform.position = new Vector2(0, 11.5f);    
                break;

            case 4:
                a = Instantiate(piece4);
                a.transform.position = new Vector2(0, 11.5f);
                break;

            case 5:
                a = Instantiate(piece5);
                a.transform.position = new Vector2(0.5f, 11);
                break;
        }
        //a = Instantiate(piece3);
        //a.transform.position = new Vector2(0, 4);
        IsGroundedVar = IsGrounded();
        StartCoroutine(TimeBehaviour());
    }

    IEnumerator TimeBehaviour()
    {

        DownMovement();
        IsGroundedVar = IsGrounded();
        yield return new WaitForSeconds(time);
        
        if (IsGroundedVar == false)
        {
            StartCoroutine(TimeBehaviour());
        }
        else
        {
            time = 1.0f;
            a.layer = LayerMask.NameToLayer("Ground");
            spawnTile();
        }
    }

    void DownMovement()
    {
        a.transform.position += new Vector3(0, -1.0f, 0);
    }

    void moveLeft()
    {
        lastPosition = a.transform.position;
        findCenters();
        bool wallHit = false;
        Vector2 direction = Vector2.left;
        float distance = 1.0f;

        List<Vector2> tempCenters = new List<Vector2>();
        tempCenters = gameObjectCenters;
        foreach (var centerCoord in tempCenters)
        {
            Vector2 position = centerCoord;
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
            
            if (hit.collider != null)
            {
                wallHit = true;
            }
        }
        if (a.transform.position != lastPosition)
        {
            moveLeft();
        }
        
        else if (wallHit == false)
        {
            if (true==true)
            {
                a.transform.position += new Vector3(-1.0f, 0, 0);
            }
        }
    }

    private void moveRight()
    {
        lastPosition = a.transform.position;
        findCenters();
        List<Vector2> tempCenters = new List<Vector2>();
        tempCenters = gameObjectCenters;
        bool wallHit1 = false;
        Vector2 direction = Vector2.right;
        float distance = 1.0f;
        foreach (var centerCoord in tempCenters)
        {
            Vector2 position = centerCoord;
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

            if (hit.collider != null)
            {
                wallHit1 = true;
            }
        }
        if (a.transform.position != lastPosition)
        {
            moveRight();
        }

        else if (wallHit1 == false)
        {
            if (true==true)
            {
                a.transform.position += new Vector3(+1.0f, 0, 0);           
            }
        }
    }
    void findCenters()
    {
        switch (tileType)
        {
            case 1:
                Vector2 gameObjectPosition1 = a.transform.position;
                gameObjectCenters.Add(gameObjectPosition1 + new Vector2(-0.5f, 0));
                gameObjectCenters.Add(gameObjectPosition1 + new Vector2(-1.5f, 0));
                gameObjectCenters.Add(gameObjectPosition1 + new Vector2(0.5f, 0));
                gameObjectCenters.Add(gameObjectPosition1 + new Vector2(1.5f, 0));
                break;

            case 2:
                Vector2 gameObjectPosition2 = a.transform.position;
                gameObjectCenters.Add(gameObjectPosition2 + new Vector2(0.5f, -0.5f));
                gameObjectCenters.Add(gameObjectPosition2 + new Vector2(-0.5f, -0.5f));
                gameObjectCenters.Add(gameObjectPosition2 + new Vector2(0.5f, 0.5f));
                gameObjectCenters.Add(gameObjectPosition2 + new Vector2(-0.5f, 0.5f));
                break;

            case 3:
                Vector2 gameObjectPosition3 = a.transform.position;
                gameObjectCenters.Add(gameObjectPosition3 + new Vector2(0.5f, -1));
                gameObjectCenters.Add(gameObjectPosition3 + new Vector2(-0.5f, -1));
                gameObjectCenters.Add(gameObjectPosition3 + new Vector2(-0.5f, 0));
                gameObjectCenters.Add(gameObjectPosition3 + new Vector2(-0.5f, 1));
                break;

            case 4:
                Vector2 gameObjectPosition4 = a.transform.position;
                gameObjectCenters.Add(gameObjectPosition4 + new Vector2(0.5f, -1));
                gameObjectCenters.Add(gameObjectPosition4 + new Vector2(0.5f, 0));
                gameObjectCenters.Add(gameObjectPosition4 + new Vector2(-0.5f, 0));
                gameObjectCenters.Add(gameObjectPosition4 + new Vector2(-0.5f, 1));
                break;

            case 5:
                Vector2 gameObjectPosition5 = a.transform.position;
                gameObjectCenters.Add(gameObjectPosition5 + new Vector2(0, -0.5f));
                gameObjectCenters.Add(gameObjectPosition5 + new Vector2(0, 0.5f));
                gameObjectCenters.Add(gameObjectPosition5 + new Vector2(1, 0.5f));
                gameObjectCenters.Add(gameObjectPosition5 + new Vector2(-1, 0.5f));
                break;
        }
    }
}