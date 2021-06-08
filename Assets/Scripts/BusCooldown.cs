using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCooldown : MonoBehaviour
{
    public GameObject bus;
    public GameObject meter;
    public float currentTime = 0.0f;
    public float maxTime = 20.0f;
    public float threshehold = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if (currentTime < maxTime && bus.activeSelf == false)
        {
            meter.GetComponent<Renderer>().material.color = bus.GetComponent<Renderer>().material.color;
            currentTime += Time.deltaTime;
            float tempTime = currentTime / maxTime;
            if (maxTime - currentTime < threshehold)
            {
                bus.GetComponent<BusManager>().timeRemaining = bus.GetComponent<BusManager>().maxTime;
                bus.SetActive(true);
                meter.GetComponent<Renderer>().material.color = Color.white;
                currentTime = 0.0f;
                
            }
            meter.transform.localScale = (new Vector3(meter.transform.localScale.x, tempTime, meter.transform.localScale.z));
        }
    }
}
