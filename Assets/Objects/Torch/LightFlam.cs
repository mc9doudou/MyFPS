using UnityEngine;
using System.Collections;
namespace MyFPS
{
    public class LightFlam : MonoBehaviour
    {
        #region Variables
        //애니메이터
        public Animator animator;

        //애니메이터 모드
        private int lightMode = 0;
        #endregion


        private void Start()
        {
            //초기화
            lightMode = 0;
        }
        private void Update()
        {
            if (lightMode == 0)
            {
                StartCoroutine(PlayAnimation());
            }
        }

        IEnumerator PlayAnimation()
        {
            lightMode = Random.Range(1, 4);     //1, 2, 3
            animator.SetInteger("LightMod", lightMode);

            //0.99초 대기
            yield return new WaitForSeconds(0.99f);

            lightMode = 0;
        }
    }
}