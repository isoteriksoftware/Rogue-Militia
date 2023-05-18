using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPanelBase Vars")]
    public LobbyPanelType panelType { get; private set; }

    [SerializeField] Animator panelAnimator;

    protected LobbyUIManager lobbyUIManager;

    public enum LobbyPanelType
    {
        None,
        CreateNicknamePanel,
        MiddleSectionPanel
    }

    public virtual void InitPanel(LobbyUIManager uiManager)
    {
        lobbyUIManager = uiManager;
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        panelAnimator.Play(CLIP_NAME);
    }

    protected void ClosePanel()
    {
        const string CLIP_NAME = "Out";
        panelAnimator.Play(CLIP_NAME);

        StartCoroutine(Utils.PlayAnimAndChangeStateAfter(gameObject, panelAnimator, CLIP_NAME, false));
    }
}
