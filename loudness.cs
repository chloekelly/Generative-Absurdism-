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
    WebCamTexture tex3;
    WebCamTexture tex4;
    WebCamDevice[] devices;
    int deviceIndex;


    //public RawImage display2;
    public RawImage display;

    public sounds loud1;
    public sounds loud2;
    public sounds loud3;
    public sounds loud4;
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

        tex3 = new WebCamTexture();
        tex3.deviceName = devices[2].name;

        tex3.Play();

        tex4 = new WebCamTexture();
        tex4.deviceName = devices[3].name;

        tex4.Play();




        // {


        //   AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        //   audioSource.clip = Microphone.Start(Microphone.devices[deviceIndex], true, 10, 44100);
        //  audioSource.Play();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (loud1.DbValue > loud2.DbValue && loud1.DbValue > loud3.DbValue && loud1.DbValue > loud4.DbValue)
        {
            Debug.Log("Mic 1 is loudest!");
            // tex.Stop();
            //tex2.Stop();
            display.texture = tex;
            // tex.Play();

        }


        else
        {

            if (loud2.DbValue > loud3.DbValue && loud2.DbValue > loud4.DbValue)
            {

                Debug.Log("Mic 2 is loudest");
                //tex.Stop();
                //  tex.Stop();
                display.texture = tex2;
                // tex2.Play();

            }



            else
            {
                if (loud3.DbValue > loud4.DbValue)
                {

                    display.texture = tex3;
                }



                else
                {
                    display.texture = tex4;
                }

            }

        }
    }

}
