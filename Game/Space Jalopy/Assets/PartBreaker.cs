using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBreaker : MonoBehaviour
{
    public PlayerShip player;
    public float minTime;
    public float maxTime;
    public float currentTime;
    public float currentTimer;
    public int lastBrokenPart = -1;

    private void Start()
    {
        player = FindObjectOfType<PlayerShip>();
        currentTime = Random.Range(minTime, maxTime);
    }

    public void Update()
    {
        if (currentTimer < currentTime)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < player.ShipParts.Length; i++)
            {
                if (/*i != lastBrokenPart && */(player.ShipParts[i].partStatus == repairState.isOk))
                {
                    indices.Add(i);
                }
            }
            int amountOfPossibleBreaks = indices.Count;
            if (amountOfPossibleBreaks > 0)
            {
                int index = Random.Range(0, amountOfPossibleBreaks - 1);
                player.ShipParts[indices[index]].Break();
                lastBrokenPart = index;
            }
            currentTime = Random.Range(minTime, maxTime);
            currentTimer = 0;
        }
    }

}
