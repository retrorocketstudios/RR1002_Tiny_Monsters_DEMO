using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private Light light;
    private float lastUpdate;
    private float desiredRange;
    public float updateFrequency = 0.15f;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Time.time - lastUpdate > updateFrequency)
        {
            lastUpdate = Time.time;
            desiredRange = Random.Range(10f, 15f);
        }

        light.range = Mathf.Lerp(light.range, desiredRange, 0.5f);
    }
}
