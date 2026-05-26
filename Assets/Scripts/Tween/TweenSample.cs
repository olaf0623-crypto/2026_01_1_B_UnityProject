using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEditor.Purchasing;

public class TweenSample : MonoBehaviour
{

    [Header("펀치 스케일 예시")]
    public RectTransform punchUITarget;
    public GameObject punchObjectTarget;

    [Header("숫자 연출 예시")]
    public TMP_Text countText;
    public int currentValue = 0;
    public int addValue = 100;

    private int targetValue;

    [Header("색 변형 연출 예시")]
    public Color flashColor = Color.yellow;

    private Color originalColor;

    [Header("페이드 UI 그룹")]
    public CanvasGroup fadeTarget;

    private Color originaColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originaColor = countText.color;
        fadeTarget.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayPunckUIScale();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayPunchObjectScale();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayUIShake();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayCountUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayColorFlash();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayFade();
        }
    }

    public void PlayPunckUIScale()
    {
        if (punchUITarget == null)
            return;

        punchUITarget.DOKill();
        punchUITarget.localScale = Vector3.one;
        punchUITarget.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayPunchObjectScale()
    {
        if (punchObjectTarget == null)
            return;

        punchObjectTarget.transform.DOKill();
        punchObjectTarget.transform.localScale = Vector3.one;
        punchObjectTarget.transform.DOPunchScale(Vector3.one * 0.3f, 0.25f, 8, 1.0f);
    }

    public void PlayUIShake()
    {
        if (punchUITarget == null)
            return;

        punchUITarget.DOKill();
        punchUITarget.DOShakeAnchorPos(0.3f, 20f, 20, 90f);
    }

    public void PlayCountUp()
    {
        if (countText == null)
            return;

        targetValue += addValue;

        DOTween.Kill("CountTween", true);


        DOTween.To(
            () => currentValue,
            value =>
            {
                currentValue = value;
                countText.text = currentValue.ToString();
            },
            targetValue,
            0.5f
        )
        .SetEase(Ease.OutQuad)
        .SetId("CountTween");
    }

    public void PlayColorFlash()
    {
        if (countText == null)
            return;

        countText.DOKill();

        countText.color = originaColor;

        countText.DOColor(flashColor, 0.1f)
            .OnComplete(() =>
            {
                countText.DOColor(originaColor, 0.2f);
            });
    }

    public void PlayFade()
    {
        if (fadeTarget == null)
            return;

        fadeTarget.DOKill();         //이전 연출이 있으면 정리한다.
        fadeTarget.alpha = 0f;       //처음에는 알파 값을 0으로 초기화 한다.

        Sequence seq = DOTween.Sequence();

        seq.Append(fadeTarget.DOFade(1f, 0.2f));
        seq.AppendInterval(0.5f);
        seq.Append(fadeTarget.DOFade(0f, 0.3f));
    }
}