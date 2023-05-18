using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] LobbyPanelBase[] lobbyPanels;
    [SerializeField] LoadingCanvasController loadingCanvasControllerPrefab;

    void Start()
    {
        foreach (var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }

        Instantiate(loadingCanvasControllerPrefab);
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        foreach (var lobby in lobbyPanels)
        {
            if (lobby.panelType == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }
}
