using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loudness : MonoBehaviour
{
    // Start is called before the first frame update

    int currentCamIndex = 2;

    WebCamTexture tex;
    WebCamTexture tex2;
    WebCamDevice[] devices;
    int deviceIndex;


    //public RawImage display2;
    public RawImage display;

    public sounds loud1;
    public sounds loud2;
    void Start()
    {
        devices = WebCamTexture.devices;
        tex = new WebCamTexture();
        tex.deviceName = devices[1].name;
        display.texture = tex;

        tex.Play();

        tex2 = new WebCamTexture();
        tex2.deviceName = devices[0].name;

        tex2.Play();
      



       // {


         //   AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
         //   audioSource.clip = Microphone.Start(Microphone.devices[deviceIndex], true, 10, 44100);
          //  audioSource.Play();
       // }
    }

    // Update is called once per frame
    void Update()
    {
        if (loud1.DbValue > loud2.DbValue)
        {
            Debug.Log("Mic 1 is loudest!");
            // tex.Stop();
            //tex2.Stop();
            display.texture = tex;
           // tex.Play();
            
        }
        
        else {

            Debug.Log("Mic 2 is loudest");
            //tex.Stop();
          //  tex.Stop();
            display.texture = tex2;
           // tex2.Play();
            
        }
        
    }
}
