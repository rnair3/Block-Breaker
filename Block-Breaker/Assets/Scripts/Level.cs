using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;                //For debugging

    //Cached ref
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroy()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
