using UnityEngine;
using TMPro;
using System.Collections;

namespace MyFPS
{
    //플레이 씬 오프닝 연출
    public class AOpenning : MonoBehaviour
    {
        #region
        //플레이어 오브젝트
        public GameObject thePlayer;
        //페이더 객체
        public SceneFader fader;

        public TextMeshProUGUI sequenceText;

        [SerializeField] private string sequence = "I need get out of here";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //오프닝 연출 시작
            StartCoroutine(SequencePlay());
        }
        #endregion

        #region Custom Method
        //오픈닝 연출 코루틴 함수
        IEnumerator SequencePlay()
        {
            //0. 플레이 캐릭터 비 활성화
            thePlayer.SetActive(false);

            // 1. 페이드인 연출 (1초 대기후 페인드인 효과)
            fader.FadeStart(1f);

            //2. 화면 하단에 시나리오 텍스트 화면 출력(3초) 
            sequenceText.text = sequence;

            // 3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            sequenceText.text = "";

            //4. 플레이 캐릭터 활성화
            thePlayer.SetActive(true);
        }
        #endregion
    }
}
