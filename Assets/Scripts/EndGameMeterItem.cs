using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMeterItem : MonoBehaviour
{

    public GameObject ProgressObject;
    public AnimationCurve ProgressAnimationFunction;

    [Range(0.0f, 1.0f)]
    public float Score = 0;

    private float progress = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (progress < 1)
        {
            progress += 0.01f;
        }

        var v = ProgressAnimationFunction.Evaluate(progress) * Score;
        ProgressObject.transform.localScale = new Vector2(1, v);
    }
}
