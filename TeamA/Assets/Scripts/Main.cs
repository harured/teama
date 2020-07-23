namespace DefaultNamespace
{
    using System.Diagnostics;
    using System.IO;
    using UnityEngine;

    public class Main : MonoBehaviour
    {
        public static bool react;

        //pythonがある場所
        private string pyExePath = @"/Users/akira/workspace/teama/dist/main\main";

        //実行したいスクリプトがある場所
        private string pyCodePath = @"/Users/akira/workspace/teama/api/main.py";

        private void Start()
        {
            UnityEngine.Debug.Log("start");
            //外部プロセスの設定
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = pyExePath, //実行するファイル(python)
                UseShellExecute = false, //シェルを使うかどうか
                CreateNoWindow = true, //ウィンドウを開くかどうか
                RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
                Arguments = pyCodePath + " " + "Hello,python.", //実行するスクリプト 引数(複数可)
            };

            //外部プロセスの開始
            Process process = Process.Start(processStartInfo);

            //ストリームから出力を得る
            StreamReader streamReader = process.StandardOutput;
            string str = streamReader.ReadLine();

            //外部プロセスの終了
            process.WaitForExit();
            process.Close();

            //実行
            print(str);
        }
        void Update () {
            if (Input.GetKey("up"))
            {
                react = true;
            }
            else
            {
                react = false;
            }
        }
    }
}