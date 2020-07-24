using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Voice : MonoBehaviour
{
    public GameObject score_object = null;
    public float timeOut;

    public float timeOut1;
    private float timeElapsed;

    private float timeElapsed1;

    private int num;
    // 一秒立ったか計測

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
        // float[] spectrum = new float[256];
        float[,] spectrum = new float[10,256];
        
        // AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        timeElapsed += Time.deltaTime;
        timeElapsed1 += Time.deltaTime;
        float[] tmp = new float[256];

        if(timeElapsed1 >= timeOut1){
            AudioListener.GetSpectrumData(tmp, 0, FFTWindow.Rectangular);
            for(int i=0; i<256; i++){
                spectrum[num,i] = tmp[i];
            }
            timeElapsed1 = 0.0f;
            num += 1;


        }
        //　一秒立ったか計測

        if(timeElapsed >= timeOut) {
            // Do anything
            timeElapsed = 0.0f;
            string print_array = "";
            for (int i=0; i < spectrum.GetLength(0); i++) {
                for (int j=0; j < spectrum.GetLength(1); j++) {
                    print_array += spectrum[i,j].ToString() + ":";
                }
                print_array += "\n";
            }
            Debug.Log(print_array);
            
        }
    }
}