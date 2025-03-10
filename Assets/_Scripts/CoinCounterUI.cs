using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;


    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}"); //set score to masked text UI
        //trigger the local move animation
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);

        //start a coroutine
        StartCoroutine(ResetCoinContainer(score));

    }

    private IEnumerator ResetCoinContainer(int score)
    {
        //tells editor to wait for a given period of time
        yield return new WaitForSeconds(duration);

        //we use duration since thats the same as the animation
        current.SetText($"{score}"); //update original score
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
        //then rest the y local position of the coin text container

    }

    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
