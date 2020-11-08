using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMeterItem : MonoBehaviour
{

    public GameObject ProgressObject;
    public AnimationCurve ProgressAnimationFunction;

    [Range(0.0f, 1.0f)]
    public float Score = 0;

    private float AnimationProgress = 0.0f;
    public float AnimationDelay = 0.0f;
    private float AnimationStep = 0.005f;


    // Start is called before the first frame update
    void Start()
    {
        AnimationProgress = -AnimationDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimationProgress < 1)
        {
            AnimationProgress += AnimationStep;
        }

        var p = Mathf.Max(0, AnimationProgress);
        var v = ProgressAnimationFunction.Evaluate(p) * Score;
        ProgressObject.transform.localScale = new Vector2(1, v);
    }
}
