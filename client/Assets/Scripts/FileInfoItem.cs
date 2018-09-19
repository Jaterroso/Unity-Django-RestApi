using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Mosframe;
using UnityEngine.EventSystems;
using SFB;
public class FileInfoItem : UIBehaviour, IDynamicScrollViewItem
{

    public Image progress;
    public Text stateLabel;
    public Text filenameLabel;
    public Image background;

    private int index;
    public void DownloadFile()
    {


        progress.fillAmount = 0;
        var fileinfo = DownloadPanel.fileinfos[index];

        var pathsave = StandaloneFileBrowser.SaveFilePanel("Open File", Application.persistentDataPath, fileinfo.filename,"");


        var progressNotifier = new ScheduledNotifier<float>();
        progressNotifier.Subscribe(x => progress.fillAmount = x);
      
        ObservableWWW.GetAndGetBytes(fileinfo.file, null, progressNotifier)
                .Subscribe(
                    x =>
                    {
                        System.IO.File.WriteAllBytes(pathsave, x);
                        stateLabel.text = "download success";


                    }, // onSuccess
                    ex =>
                    {
                        Debug.Log(ex.ToString());
                        stateLabel.text = ex.ToString();


                    }); // onError
    }

    public void onUpdateItem(int index)
    {
        var filedata = DownloadPanel.fileinfos[index];
        var filepath = System.IO.Path.Combine(Application.persistentDataPath, filedata.filename);

        stateLabel.text = "";
        progress.fillAmount = 0;
        filenameLabel.text = filedata.filename;
    }



}
