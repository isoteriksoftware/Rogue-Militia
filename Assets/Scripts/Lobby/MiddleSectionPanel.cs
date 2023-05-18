using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : LobbyPanelBase
{
    [Header("MiddleSectionPanel Vars")]
    [SerializeField] Button joinRandomRoomBtn;
    [SerializeField] Button joinRoomByNameBtn;
    [SerializeField] Button createRoomBtn;

    [SerializeField] TMP_InputField joinRoomField;
    [SerializeField] TMP_InputField createRoomField;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        joinRandomRoomBtn.onClick.AddListener(JoinRandomRoom);
        joinRoomByNameBtn.onClick.AddListener(() => CreateRoom(GameMode.Client, joinRoomField.text));
        createRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomField.text));
    }

    void CreateRoom(GameMode mode, string fieldText)
    {
        if (fieldText.Length >= 2)
        {
            GlobalManagers.Instance.NetworkRunnerController.StartGame(mode, fieldText);
        }
    }

    void JoinRandomRoom()
    {
        GlobalManagers.Instance.NetworkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
    }
}
