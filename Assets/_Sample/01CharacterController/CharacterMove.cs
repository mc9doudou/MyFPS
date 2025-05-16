using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
namespace MySample
{
    //캐릭터 이동 관리 클래스
    public class CharacterMove : MonoBehaviour
    {
        #region Variables
        //참조
        private CharacterController controller;

        //입력
        private Vector2 inputMove;

        //이동
        [SerializeField]private float moveSpeed = 10f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            controller = this.GetComponent<CharacterController>();
        }

        private void Update()
        {
            //방향
            Vector3 moveDir = Vector3.right * inputMove.x + Vector3.forward * inputMove.y ;
            
            //이동
            controller.Move(moveDir * Time.deltaTime * moveSpeed);
        }
        #endregion

        #region Custom Method
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
            Debug.Log($"inputMove:{inputMove}");
        }
        #endregion
    }
}
