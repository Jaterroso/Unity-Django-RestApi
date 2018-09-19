using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using UnityEngine.Networking;
using System.IO;
using UniRx;
public class UploadPanel : MonoBehaviour
{

    public InputField pathInput;

    public Text errorLabel;
    public Image progress;

    public Manager manager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelectFile()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", true);
        if (paths != null && paths.Length > 0)
        {
            pathInput.text = paths[0];
        }
        errorLabel.gameObject.SetActive(false);
    }

    public void Upload()
    {
        if (string.IsNullOrEmpty(pathInput.text) || !System.IO.File.Exists(pathInput.text))
        {
            errorLabel.text = "Please Select File!!!";
            errorLabel.gameObject.SetActive(true);
            return;
        }
        else

        {
            errorLabel.text = "Uploading";
            errorLabel.gameObject.SetActive(true);

            manager.Lock = true;

            WWWForm form = new WWWForm();

            var file = File.ReadAllBytes(pathInput.text);
            form.AddBinaryData("file", file);
            var fileinfo = (new System.IO.FileInfo(pathInput.text));
            form.AddField("filename", fileinfo.Name);

            string authorization = authenticate(Registry.username, Registry.password);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("AUTHORIZATION", authorization);

            var progressNotifier = new ScheduledNotifier<float>();
            progressNotifier.Subscribe(x => progress.fillAmount = x);

            ObservableWWW.Post(Constants.API_FILE, form, headers, progressNotifier)
                 .Subscribe(
                     x =>
                     {
                         Debug.Log("Upload success");
                         errorLabel.text = "upload success";
                         errorLabel.gameObject.SetActive(true);

                         manager.Lock = false;
                     }, // onSuccess
                     ex =>
                     {
                         Debug.Log(ex.ToString());
                         errorLabel.text = ex.ToString();
                         errorLabel.gameObject.SetActive(true);
                         manager.Lock = false;
                     }); // onError
        }
    }
    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }

    public void Back()
    {
        manager.SetPanel(PANEL.Menu);
    }

}
