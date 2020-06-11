using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    // Cached references
    //Cached references
    GameSession theGameSession;

    private void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theGameSession.SubtractLives();
        theGameSession.ResetCurScore();
    }


}
