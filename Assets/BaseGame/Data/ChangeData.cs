using BaseGame.Data;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeData : MonoBehaviour
{
    [SerializeField] Button Save;
    [SerializeField] Button Load;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField password;
    private AccountInfo curAcount;

    private void Start()
    {
        curAcount = new();
        Save.onClick.AddListener(OnClickSaveBtn);
        Load.onClick.AddListener(OnClickLoadBtn);
        
    }
    public void OnClickLoadBtn()
    {
        AccountInfo curdata = DataHelper.Load<AccountInfo>(curAcount.UserID.ToString());
        curAcount = curdata;
        nameInput.text = curdata.UserName;
        password.text = curdata.Password;
    }

    public void OnClickSaveBtn() 
    {
        curAcount.UserName = nameInput.text;
        curAcount.Password = password.text;
        DataHelper.Save(curAcount, curAcount.UserID.ToString());
    }
}
