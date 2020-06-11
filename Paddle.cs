using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters 
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minXInUnits = 1.0f;
    [SerializeField] float maxXInUnits = 15.0f;


    //Cached references
    GameSession theGameSession;
    Ball theBall;

    private void Start()
    {
        theBall = FindObjectOfType<Ball>();
        theGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXInUnits, maxXInUnits);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        }
    }
}
