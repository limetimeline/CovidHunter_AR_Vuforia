using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class CanvasControl : MonoBehaviour
{
    public GameObject leftHands;
    public GameObject rightHands;
    public GameObject cycleGuideViews;
    public GameObject crossHair;
    public GameObject countDown;
    public GameObject videoPlayer;

    public GameObject virusPoint1;
    public GameObject virusPoint2;
    public GameObject virusPoint3;
    public GameObject virusPoint4;
    public GameObject virusPoint5;
    public GameObject virusPoint6;
    public GameObject virusPoint7;
    public GameObject virusPoint8;

    public Text countDownText;

    public VideoPlayer video;

    bool videoEnd = true; // 동영상 뜨게 하려면 false로 바꾸면 됨
    bool countEnd = false;
    bool realEnd = false;

    static public bool preProcessingEnd = false;


    public int count;

    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += CheckOver;
    }


    /* 영상이 끝났을 때 */
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Is Over");
        videoEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool Ts = DefaultObserverEventHandler.TrackingSuccess;

        if (Ts) // 인식에 성공했을 때
        {

            if (!videoEnd) // 인식이 성공하고 최초 1회
            {
                videoPlayer.SetActive(true); // 동영상 플레이어 렌더링
                video.Play(); // 동영상 재생
            }
            else // 동영상을 다 보고 나서 videoEnd가 true일 경우
            {
                if (!countEnd && !realEnd) // 인식 성공 후 동영상 다보고 카운트 최초 1회
                {
                    videoPlayer.SetActive(false); // 동영상 플레이어 렌더링 해제
                    StartCoroutine("CountDown");
                }
                else if(!realEnd)
                {
                    leftHands.SetActive(true); // 왼손 렌더링
                    rightHands.SetActive(true); // 오른손 렌더링
                    crossHair.SetActive(true); // 크로스헤어 렌더링
                    cycleGuideViews.SetActive(false); // 가이드뷰 전환 렌더링 해제



                    preProcessingEnd = true;
                }
            }
        }
        else // 인식 실패 시
        {
            preProcessingEnd = false;

            leftHands.SetActive(false); // 왼손 렌더링 해제
            rightHands.SetActive(false); // 오른손 렌더링 해제
            crossHair.SetActive(false); // 크로스헤어 렌더링 해제
            cycleGuideViews.SetActive(true); // 가이드뷰 전환 렌더링

        }
    }

    IEnumerator CountDown()
    {
        realEnd = true;
        count = 3;
        countDown.SetActive(true);
        for (int i = count; i >= 0; i--)
        {
            if (i == 0)
            {
                countDownText.text = string.Format("START!");
            }
            else
            {
                countDownText.text = string.Format(i.ToString());
            }
            yield return new WaitForSeconds(1f);
        }
        countEnd = true;
        realEnd = false;
        countDown.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
