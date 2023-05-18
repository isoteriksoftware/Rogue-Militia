using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button cancelBtn;

    NetworkRunnerController networkRunnerController;

    // Start is called before the first frame update
    void Start()
    {
        networkRunnerController = GlobalManagers.Instance.NetworkRunnerController;
        networkRunnerController.OnStartedRunnerConnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccessfully += OnPlayerJoinedSuccessfully;

        cancelBtn.onClick.AddListener(CancelRequest);
        this.gameObject.SetActive(false);
    }

    void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);

        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimAndChangeStateAfter(gameObject, animator, CLIP_NAME));
    }

    void OnPlayerJoinedSuccessfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimAndChangeStateAfter(gameObject, animator, CLIP_NAME, false));
    }

    void CancelRequest()
    {
        networkRunnerController.ShutDownRunner();
    }

    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnerConnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccessfully -= OnPlayerJoinedSuccessfully;
    }
}
