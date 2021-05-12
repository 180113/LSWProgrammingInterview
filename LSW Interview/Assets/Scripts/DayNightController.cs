using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayNightController : MonoBehaviour {
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;

    int days;

    [SerializeField] float timeScale = 60f;
    [SerializeField] Color dayLightColor = Color.white;
    [SerializeField] Text timeText;
    [SerializeField] Light2D globalLight;
    float time;

    float Hours {
        get { return time / 3600f; }
    }
    float Minutes {
        get { return time % 3600f / 60f; }
    }
    void Update () {
        time += Time.deltaTime * timeScale;
        int hh = (int) Hours;
        int mm = (int) Minutes;
        timeText.text = hh.ToString ("00");
        float v = nightTimeCurve.Evaluate (Hours);
        Color c = Color.Lerp (dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondsInDay) {
            NextDay ();
        }
    }

    void NextDay () {
        time = 0;
        days++;
    }
}