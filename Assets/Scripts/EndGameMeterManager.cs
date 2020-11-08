﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMeterManager : MonoBehaviour
{

    [SerializeField]
    private GameObject MeterItemPrefab;

    [Header("Settings")]
    public int Count;
    [Range(0.0f, 1.0f)]
    public float ScoreRatio;

    [Range(0.0f, 100.0f)]
    public float HorzontalDistance = 10;

    [Range(0.0f, 100.0f)]
    public float VerticalDistance = 10;

    private int columns = 6;
    private List<GameObject> items = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

        float amount = (float)Count * ScoreRatio;
        int filled = (int) amount;
        float tail = amount - (float) filled;


        bool isTailUsed = false; // Totální píčovina.

        int y = -1;
        for (int i = 0; i < Count; i++)
        {
            var j = i % columns;
            if (j == 0) y++;
            int x = (j - columns / 2);
            var item = instanceItem(new Vector2(x * HorzontalDistance, y * -VerticalDistance));
            items.Add(item);


            float s = 0;

             if ((float)i + 1 <= filled) {
                 s = 1;
             } else if (isTailUsed == false) {
                 s = tail;
                 isTailUsed = true;
             }

            var meter = item.GetComponent<EndGameMeterItem>();
            meter.Score = s;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    private GameObject instanceItem(Vector2 pos)
    {
        var item = Instantiate(MeterItemPrefab, new Vector2(0, 0), Quaternion.identity);
        item.transform.SetParent(this.transform);
        item.transform.localPosition = new Vector2(pos.x, pos.y);

        return item;
    }
}
