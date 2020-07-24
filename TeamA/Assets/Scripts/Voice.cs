using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Voice : MonoBehaviour
{
    public GameObject score_object = null;

    void Start()
    {
        AudioSource aud = GetComponent<AudioSource>();
        // マイク名、ループするかどうか、AudioClipの秒数、サンプリングレート を指定する
        Debug.Log("bbb");
        aud.clip = Microphone.Start(null, true, 100, 44100);
        var devices = Microphone.devices;
        bool is_record = Microphone.IsRecording(devices[1]);
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = devices[1] + ":" + is_record;
        Debug.Log(devices[1] + ":" + is_record);
        aud.Play();
    }

    void Update()
    {
        string log = "";
        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < 256; i++)
        {
            log += spectrum[i].ToString() + ",";
        }

        Debug.Log(log);
        Debug.Log("yazirusi");
    }
}