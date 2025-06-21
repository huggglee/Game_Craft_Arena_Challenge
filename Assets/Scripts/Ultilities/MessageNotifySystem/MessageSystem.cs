using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] GameObject messageText;
    private void Start()
    {
        Observer.Instance.Register(EventId.OnShowMessage, ShowMessage);
    }
    public void ShowMessage(object obj)
    {
        string message = (string)obj;
        GameObject messageObj = MyPoolManager.Instance.GetFromPool(messageText, this.transform);    
        messageObj.GetComponent<MessageText>().SetText(message);
    }
    private void OnDisable()
    {
        Observer.Instance.Unregister(EventId.OnShowMessage, ShowMessage);
    }
}
