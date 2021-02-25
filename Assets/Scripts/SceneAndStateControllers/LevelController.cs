using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int pointsToFinish;
    private int currentPoints;
    public GameObject pieces;

    private void Start()
    {
        pointsToFinish = pieces.transform.childCount - 1;
    }

    public void AddPoints()
    {
        if (currentPoints >= pointsToFinish)
        {
            // TODO Particle Trigger here
            SceneManager.LoadScene("SampleScene");
            Debug.Log("All points: " + pointsToFinish);
        }
        
        Debug.Log("Current points: " + currentPoints);
        currentPoints++;
    }
}