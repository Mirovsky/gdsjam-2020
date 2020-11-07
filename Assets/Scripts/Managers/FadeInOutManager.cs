﻿using System;
using System.Collections;
using UnityEngine;

public class FadeInOutManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeCanvasGroup = default;

    [Space]
    [SerializeField] private float _fadeDuration = default;
    [SerializeField] private AnimationCurve _fadeCurve = default;

    public void FadeOut(Action callback)
    {
        StartCoroutine(Fade(0.0f, 1.0f, callback));
    }

    public void FadeIn(Action callback)
    {
        StartCoroutine(Fade(1.0f, 0.0f, callback));
    }

    IEnumerator Fade(float fromAlpha, float toAlpha, Action callback)
    {
        var current = 0.0f;
        while (current < _fadeDuration)
        {
            _fadeCanvasGroup.alpha = Mathf.Lerp(fromAlpha, toAlpha, _fadeCurve.Evaluate(current / _fadeDuration));
            current += Time.deltaTime;

            yield return null;
        }

        _fadeCanvasGroup.alpha = toAlpha;
        
        callback?.Invoke();
    }
}