using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerName : MonoBehaviour
{
    TMP_InputField tmPROInput;
    
    private void Start()
    {
        tmPROInput = GetComponent<TMP_InputField>();
    }
    public void SetName()
    {
        PersistentDataManager.instance.SetPlayerName(tmPROInput.text);
    }
}
