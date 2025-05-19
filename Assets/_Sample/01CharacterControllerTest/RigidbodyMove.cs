using UnityEngine;
using UnityEngine.InputSystem;
namespace MySample
{
    public class RigidbodyMove : MonoBehaviour
    {
        #region Variables
        //����
        private Rigidbody rb;
        private CapsuleCollider capsuleCollider;

        //�Է� - �̵�
        private Vector2 inputMove;

        //�̵� �ӵ�
        [SerializeField] private float movePower = 10f;

        //�߷� üũ
        private bool isGround = false;

        //����
        [SerializeField] private float jumpPower = 10f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //����
            rb = this.GetComponent<Rigidbody>();
            capsuleCollider = this.GetComponent<CapsuleCollider>() ;
        }
        private void FixedUpdate()
        {
            //�׶��� üũ
            isGround = GroundCheck();

            //
            if (isGround)
            {
                if (inputMove == Vector2.zero)
                {
                    rb.linearDamping = 20f;
                }
                else
                {
                    rb.linearDamping = 5f;
                }
            }
            else
            {
                rb.linearDamping = 2f;
            }

            //����
            Vector3 moveDir = transform.right * inputMove.x + transform.forward * inputMove.y;

            //�̵� - �̵��� �������� ���ش�
            rb.AddForce(moveDir * movePower, ForceMode.Force);
        }
        #endregion

        #region Custom Method
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started && isGround)
            {
                //���� �������� ���� �ش�(1ȸ��)
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            }
        }
        //�׶��� üũ
        bool GroundCheck()
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position,capsuleCollider.radius,Vector3.down,out hit,
                (capsuleCollider.height/2 - capsuleCollider.radius)+0.01f,Physics.AllLayers,QueryTriggerInteraction.Ignore))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
