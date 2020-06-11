using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    //Keep track of balls
    [SerializeField] int numBreakableBlocks;

    // cached reference
    Sceen_Loader sceneLoader;
    GameSession theGameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<Sceen_Loader>();
        theGameSession = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
        numBreakableBlocks++;
    }

    public void BlockDestroyed()
    {
        numBreakableBlocks--;
        if (numBreakableBlocks <= 0)
        {
            theGameSession.UpdatePrevScore();
            sceneLoader.LoadNextScene();
        }
    }

}
