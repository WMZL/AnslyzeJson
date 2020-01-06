using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AnalyzeJson : MonoBehaviour
{
    private string path;
    public Text m_Text;
    void Start()
    {
        path = Application.streamingAssetsPath + "/aaa.json";
        Debug.Log(path);
    }

    /// <summary>
    /// 点击按钮
    /// </summary>
    public void OnClick()
    {
        C_UnityWebRequest.Instance.Get(path, CallBackMth);
    }

    /// <summary>
    /// 回调接收数据
    /// </summary>
    private void CallBackMth(UnityWebRequest r)
    {
        jsonclass jd = JsonMapper.ToObject<jsonclass>(r.downloadHandler.text);
        Debug.Log("接收到返回消息！");
        m_Text.text = jd.cmd.ToString() + jd.description;
    }
}

public class jsonclass
{
    public int cmd;
    public string description;
}
