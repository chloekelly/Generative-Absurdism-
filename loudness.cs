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


    float changeTimer = 0;
    public int whichCamera = 0;


    //public RawImage display2;
    public RawImage display;

    public sounds loud1;
    public sounds loud2;
    public sounds loud3;
    public sounds loud4;
    void Start()
    {
       



        Debug.Log(WebCamTexture.devices);
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

        changeTimer += Time.deltaTime;

        if (changeTimer > 0.3)
        {
            whichCamera += 1;

            if (whichCamera > 1)
            {
                whichCamera = 0;
            }

            changeTimer = 0;
        }



        if (Input.GetKeyDown("q")) { display.texture = tex; }
        if (Input.GetKeyDown("w")) { display.texture = tex2; }
        if (Input.GetKeyDown("e")) { display.texture = tex3; }
        if (Input.GetKeyDown("r")) { display.texture = tex4; }

    

       
        if (loud1.DbValue > loud2.DbValue && loud1.DbValue > loud3.DbValue && loud1.DbValue > loud4.DbValue)
        {
            Debug.Log("Mic 1 is loudest!");
            // tex.Stop();
            //tex2.Stop();
            display.texture = tex;
            // tex.Play();

        }


     

            if (loud2.DbValue > loud3.DbValue && loud2.DbValue > loud4.DbValue && loud2.DbValue > loud1.DbValue)
            {

                Debug.Log("Mic 2 is loudest");
                //tex.Stop();
                //  tex.Stop();
                display.texture = tex3;
                // tex2.Play();

            }



         
                if (loud3.DbValue > loud4.DbValue && loud3.DbValue > loud2.DbValue && loud3.DbValue > loud1.DbValue )
                {
            if (whichCamera == 0)
            {
                display.texture = tex2;
            }
            else
            {
                display.texture = tex4;
            }

                }

        if (loud4.DbValue > loud3.DbValue && loud4.DbValue > loud2.DbValue && loud4.DbValue > loud1.DbValue)
        {

            display.texture = tex4;
        }



    
            }
            

        }

