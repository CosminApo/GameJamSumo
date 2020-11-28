using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class PointsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players; //serialize this so that you can add players from editor

    private Dictionary<GameObject, int> points = new Dictionary<GameObject, int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gO in players) 
        {
            points.Add(gO, 0); //add it to dictionary
        }
    }

    //// DEBUGS
    //void Update()
    //{
    //    foreach (GameObject gO in players)
    //    {
    //        Debug.Log(points[gO]);
    //    }
    //}

    public void addOppositePoints(GameObject _player)
    {
        foreach (GameObject gO in players) //give a point to other players
        {
            if (gO != _player)
            points[gO] += 1;
        }
    }
}
