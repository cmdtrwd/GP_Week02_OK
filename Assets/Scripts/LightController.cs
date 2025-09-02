using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light lightComponent;
    private float intensityA;
    private Color colorA;
    private float intensityB;
    private Color colorB;

    private float newIntensity;
    private Color newColor;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        lightComponent = GetComponent<Light>();
        
        intensityA = lightComponent.intensity;
        colorA = lightComponent.color;

        intensityB = 3f;
        colorB = new Color(31/255f, 240 / 255f, 245 / 255f);

        StartCoroutine(ChangeLight());
    }

    // Update is called once per frame
    void Update()
    {
        lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, newIntensity, Time.deltaTime);
        lightComponent.color = Color.Lerp(lightComponent.color, newColor, Time.deltaTime);        
    }
    IEnumerator ChangeLight()
    {
        if (!isOn)
        {
            newIntensity = intensityB;
            newColor = colorB;
            isOn = true;
        }
        else
        {
            newIntensity = intensityA;
            newColor = colorA;
            isOn = false;
        }
        yield return new WaitForSeconds(2f);

        StartCoroutine(ChangeLight());
    }
}
