using UnityEngine;

namespace Soulseek
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private string layerPlatformName = "Platform";
        [SerializeField] private string layerWallName = "Wall";
        [SerializeField] private string layerItemName = "Item";
        [SerializeField] private string animationWalkBool = "IsWalking";
        [Space(3)]
        [SerializeField] private Animator animator = null;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float speed = 0.5f; 
        [SerializeField] private float jumpForce = 100f;
        [Space(3)] [SerializeField] private SpriteRenderer[] spriteRenderers;
        private Vector2 direction;
        private int layerPlatform;
        private float mass;
        private Vector3 initialPosition;

        public void GoBackToInitialPosition()
        {
            rigidBody.velocity = Vector3.zero;
            gameObject.transform.position = initialPosition;
        }

        private void Awake()
        {
            if (rigidBody == null)
            {
                Debug.LogError("No rigidbody assigned");
            }

            initialPosition = transform.position;
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            var horizontal = (int)Input.GetAxisRaw("Horizontal");
            animator.SetBool(animationWalkBool, horizontal != 0);
            AdjustForward(horizontal, (int)direction.x);
            direction.x = horizontal;
            
            if (Input.GetButtonDown("Jump"))
            {
                audioSource.Play();
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }


        private void FixedUpdate()
        {
            
            direction.x = speed * Time.fixedDeltaTime * direction.x;
            direction.y = rigidBody.velocity.y;

            rigidBody.velocity = direction;
        }

        public void Initialize()
        {
            mass = rigidBody.mass;
            layerPlatform = LayerMask.NameToLayer("Platform");
        }

        public void AdjustForward(int horizontalNew, int horizontalOld)
        {
            if (horizontalNew == horizontalOld) return;

            var flipHorizontal = horizontalNew < 0 ? true : false;
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = flipHorizontal;
            }
        }
        
    }
}
