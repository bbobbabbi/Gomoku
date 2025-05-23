using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanelController : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject BuyingPanel;
    [SerializeField] private GameObject RankingPanel;
    [SerializeField] private GameObject ProfilePanel;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private GameObject FadePanel;
    [SerializeField] private GameObject KiboPanel;

    private GameObject settingPanel;
    private RectTransform settingPanelRect;

    private GameObject buyingPanel;
    private RectTransform buyingPanelRect;

    private GameObject rankingPanel;
    private RectTransform rankingPanelRect;
    private GameObject profilePanel;
    private RectTransform profilePanelRect;
    private GameObject kiboPanel;
    private RectTransform kiboPanelRect;
    
    void Awake()
    {
        FindCanvas();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void FindCanvas()
    {
        // Canvas를 다시 찾음
        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj != null)
        {
            canvasTransform = canvasObj.transform;
        }
        else
        {
            Debug.LogError("Canvas를 찾을 수 없습니다!");
        }
    }
    public void OnClickPlayButton()
    {
        FadePanel = Instantiate(FadePanel, canvasTransform);

        FadePanel.GetComponent<CanvasGroup>().alpha = 0;

        FadePanel.GetComponent<CanvasGroup>().DOFade(1, 1.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickRankingButton() 
    {
        if (rankingPanel == null)
        {
            rankingPanel = Instantiate(RankingPanel, canvasTransform);
            rankingPanelRect = rankingPanel.GetComponent<RectTransform>();
            rankingPanelRect.anchoredPosition = new Vector2(-500f, 0f); // 초기 위치 설정
        }
        else
        {
            rankingPanel.SetActive(true);
        }

        rankingPanelRect.DOLocalMoveX(0f, 0.3f);
    }

    public void OnClickSettingButton()
    {
        if (settingPanel == null)
        {
            settingPanel = Instantiate(SettingPanel, canvasTransform);
            settingPanelRect = settingPanel.GetComponent<RectTransform>();
            settingPanelRect.anchoredPosition = new Vector2(-500f, 0f); // 초기 위치 설정
        }
        else
        {
            settingPanel.SetActive(true);
        }

        settingPanelRect.DOLocalMoveX(0f, 0.3f);
    }

    public void OnClickBuyingButton() 
    {
        if (buyingPanel == null)
        {
            buyingPanel = Instantiate(BuyingPanel, canvasTransform);
            buyingPanelRect = buyingPanel.GetComponent<RectTransform>();
            buyingPanelRect.anchoredPosition = new Vector2(-500f, 0f); // 초기 위치 설정
        }
        else
        {
            buyingPanel.SetActive(true);
        }

        buyingPanelRect.DOLocalMoveX(0f, 0.3f); 
    }

    public void OnClickProfileButton()
    {
       if(profilePanel == null) 
       {
            profilePanel = Instantiate(ProfilePanel, canvasTransform);
            profilePanelRect = profilePanel.GetComponent<RectTransform>();
            profilePanelRect.anchoredPosition = new Vector2(-500f, 0f); // 초기 위치 설정
       }
       else
       {
           profilePanel.SetActive(true);
       }

       profilePanelRect.DOLocalMoveX(0f, 0.3f);
       
    }

    public void OnClickKiboButton()
    {

        NotationManager.Instance.NotationManagerinit();
        if (kiboPanel == null)
        {
            kiboPanel = Instantiate(KiboPanel, canvasTransform);
            kiboPanelRect = kiboPanel.GetComponent<RectTransform>();
            kiboPanelRect.anchoredPosition = new Vector2(-500f, 0f); // 초기 위치 설정
        }
        else
        {
            kiboPanel.SetActive(true);
        }

        //기보 파일 가져오기
        NotationManager.Instance.GetRecentFiles();
        kiboPanelRect.DOLocalMoveX(0f, 0.3f);

    }
    
    // 각 버튼에 마우스 포인터가 들어갈 때 호출할 함수
    // 인자로 전달받은 tooltipMessage를 보여줌.
    public void OnButtonPointerEnter(string tooltipMessage)
    {
        TooltipManager.Instance.ShowTooltip(tooltipMessage);
    }

    // 각 버튼에서 마우스 포인터가 나갈 때 호출할 함수
    public void OnButtonPointerExit()
    {
        TooltipManager.Instance.CloseTooltip();
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindCanvas();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
