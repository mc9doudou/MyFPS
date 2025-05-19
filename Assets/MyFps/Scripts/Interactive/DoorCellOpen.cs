using UnityEngine;
using TMPro;

namespace MyFPS
{
    //쿤열기 인터렉티브 액션 구현
    public class DoorCellOpen : MonoBehaviour
    {
        #region Veriables
        //문과 클레이어와의 거리
        private float theDistance;

        //액션 UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;

        //크로스 헤이
        public GameObject extraCross;

        public string action = "Open The Door";

        //애니메이션
        public Animator animator;

        //애니 파라미터 스트링
        private string paramIsOpen = "IsOpen";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            
        }
        private void Update()
        {
            //문과 클레이어와의 거리 가져오기
            theDistance = PlayerCasting.distancFromTarget;
        }
        private void OnMouseOver()
        {
            extraCross.SetActive(true);

            if (theDistance <= 2f)
            {
                ShowActionUI();

                //TODO : New Input System 대체 구현
                //키입력 체크
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //UI 숨기기, 문열고, 충돌체 제거
                    HideActionUI();
                    animator.SetBool(paramIsOpen, true);        //문 여는 애니메이션 연출
                    this.GetComponent<BoxCollider>().enabled = false;   //문 충돌체 제거
                }
            }
            else
            {
                HideActionUI();
            }
        }
        private void OnMouseExit()
        {
            extraCross.SetActive(false);

            HideActionUI();
        }
        #endregion

        #region Cunstom Method
        //Action UI 보여주기
        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
        }

        //Action UI 숨기기
        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }
        #endregion

    }
}
