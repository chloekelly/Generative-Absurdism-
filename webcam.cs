using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class webcam : MonoBehaviour
{
    int currentCamIndex = 2;

    WebCamTexture tex;
    //WebCamTexture tex2;
    WebCamDevice[] devices;
    int deviceIndex;

    //public RawImage webcam2;


    public RawImage webcam1;
    // Start is called before the first frame update
    void Start()
    {
        devices = WebCamTexture.devices;
        tex = new WebCamTexture();
        tex.deviceName = devices[0].name;
        webcam1.texture = tex;
        tex.Play();

        {


            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.clip = Microphone.Start(Microphone.devices[deviceIndex], true, 10, 44100);
            audioSource.Play();
        }
    }

    void Update()
    {
        // for()

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
}


    // Update is called once per frame
  