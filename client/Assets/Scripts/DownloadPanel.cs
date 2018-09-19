using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft;
using UniRx;
using Mosframe;

public class DownloadPanel : MonoBehaviour
{

    public Manager manager;

    public static List<FileInfo> fileinfos;



    public DynamicScrollView scrollView;
    // Use this for initialization
    private void OnEnable()
    {
        string authorization = authenticate(Registry.username, Registry.password);
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("AUTHORIZATION", authorization);

        manager.Lock = true;
       
        ObservableWWW.Get(Constants.API_FILE, headers)
                .Subscribe(
                    x =>
                    {


                        fileinfos = JsonConvert.DeserializeObject<List<FileInfo>>(x);
                        if (fileinfos != null)
                        {
                            Debug.Log("[*] Do success");
                            this.scrollView.totalItemCount = fileinfos.Count;
                        }

                        manager.Lock = false;
                    }, // onSuccess
                    ex =>
                    {
                        Debug.Log(ex.ToString());

                        manager.Lock = false;
                    }); // onError

    }

    public void Back()
    {
        manager.SetPanel(PANEL.Menu);
    }

    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }


}
