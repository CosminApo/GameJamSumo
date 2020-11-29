using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class PointsManager : MonoBehaviour
{
    public Text p1score;
    public Text p2score;


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


    void Update()
    {

    }

    public void addOppositePoints(GameObject _player)
    {
        int currentplayer = 0;
        foreach (GameObject gO in players) //give a point to other players
        {
            currentplayer += 1;
            if (gO != _player)
            {
                Debug.Log(currentplayer);
                points[gO] += 1;
                if (currentplayer == 1)
                {
                    //p1score.text = points[gO].ToString();
                }
                else if (currentplayer == 2)
                {
                    //p2score.text = points[gO].ToString();
                }
            }
        }
    }
}