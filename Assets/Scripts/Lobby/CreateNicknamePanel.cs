using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNicknamePanel : LobbyPanelBase
{
    [Header("CreateNicknamePanel Vars")]
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Button createNicknameBtn;

    const int MAX_CHAR_FOR_NICKNAME = 2;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        createNicknameBtn.interactable = false;
        createNicknameBtn.onClick.AddListener(OnClickCreateNickname);
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void OnClickCreateNickname()
    {
        var nickname = inputField.text;
        if (nickname.Length >= MAX_CHAR_FOR_NICKNAME)
        {
            base.ClosePanel();
            lobbyUIManager.ShowPanel(LobbyPanelType.MiddleSectionPanel);
        }
    }

    void OnInputValueChanged(string arg)
    {
        createNicknameBtn.interactable = arg.Length >= MAX_CHAR_FOR_NICKNAME;
    }    
}
