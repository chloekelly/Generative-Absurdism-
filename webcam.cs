using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class webcam : MonoBehaviour
{
    int currentCamIndex = 2;

    WebCamTexture tex;
    WebCamDevice[] devices;

    public RawImage display;
    // Start is called before the first frame update
    void Start()
    {
        devices = WebCamTexture.devices;
        tex = new WebCamTexture();
        tex.deviceName = devices[0].name;
        display.texture = tex;
        tex.Play();
    }

    void OnGUI()

    {

        if (GUI.Button(new Rect(0, 0, 100, 100), "switch"))
        {
            tex.Stop();
            tex.deviceName = (tex.deviceName == devices[0].name) ? devices[1].name : devices[0].name;
            tex.Play();
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}