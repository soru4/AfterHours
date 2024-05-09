using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light l;
    [SerializeField] float min, standard, max;
    [SerializeField] float minInterval, maxInterval, unflickerTime;

    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
        Invoke(nameof(Flicker), Time());
    }

    void Flicker()
    {
        float val = Random.Range(min, max);
        l.intensity = val;
        Invoke(nameof(Unflicker), unflickerTime * Random.Range(0.8f, 1.2f));
    }

    void Unflicker()
    {
        l.intensity = standard;
        Invoke(nameof(Flicker), Time());
    }

    float Time() => Random.Range(minInterval, maxInterval);
}
