using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float jumpSpeed = 9f;
    public float maxSpeed = 10f;
    public float JumpPower = 20f;
    public bool grounded;
    public float jumpRate = 1f;
    public float nextJumpPress = 0.0f; 
    private Rigidbody2D ridigBody2D;
    private Physics2D physic2D;
    Animator animator;
    public int healthbar = 100;
    public Text healthText;
    public Slider sliderHp;
    public Joystick joystick;
    [SerializeField] private bool isRight = true;
    [SerializeField] private float slideSpeed = 1000.00f;
    [SerializeField] private bool isSliding = false;
    public SoundEffect soundEffect;
    private bool isHandFree = true;
    private GameObject isRangObject;
    private bool isOnObject = false;
    private GameObject inHandObject;
    private bool hasRedKey = false;
    private bool isOnRedDoor = false;
    private GameObject redDoorObject;


    void Start()
    {
        ridigBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        
        
    }

     void Update()
    {
        if(healthText !=null)
        {
            healthText.text = "HEALTH: "+healthbar;
        }
        

        if(healthbar <= 0){
            healthbar = 0;
            animator.SetTrigger("Death");
        }
        if(sliderHp)
        {
            sliderHp.value = healthbar;
        }
        

        if(Input.GetKeyUp(KeyCode.L)){
            TakeDamage(10);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            SkillSlide();
        }

        animator.SetBool("Grounded",true);
        animator.SetFloat("Speed",Mathf.Abs(joystick.Horizontal));
        if(joystick.Horizontal < -0.1f){
            isRight = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        }else if(joystick.Horizontal > 0.1f){
            isRight = true;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }

        if(Input.GetButtonDown("Jump") && Time.time > nextJumpPress){
            animator.SetBool("Jump",true);
            nextJumpPress = Time.time + jumpRate;
            ridigBody2D.AddForce(jumpSpeed*(Vector2.up * JumpPower));
            soundEffect.playjumpSound();
        }else{
            animator.SetBool("Jump",false);
        }
        if(isHandFree == true)
        {
            if(isOnObject == true && Input.GetKeyDown(KeyCode.T) && isRangObject.CompareTag("RedKey"))
            {
                // pick up object that in rangr
                inHandObject = isRangObject;
                isRangObject = null;
                // pick up something means hand is not free anaymore
                isHandFree = false;
                isOnObject = false;
                // Get the key after pickup
                hasRedKey = true;
                Debug.Log("Pick Up Red Key");
            }
        }
        else
        {
            if(inHandObject != null)
            {
                // put key on the hand and go along the player
                inHandObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f , transform.position.z);
                if(Input.GetKeyDown(KeyCode.G))
                {
                    // drop key at plyer position
                    inHandObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    hasRedKey = false;
                    isHandFree = true;
                    inHandObject = null;
                }

                if(hasRedKey == true && isOnRedDoor == true && Input.GetKeyDown(KeyCode.T))
                {
                    hasRedKey = false;
                    isHandFree = true;
                    Destroy(inHandObject);
                    inHandObject = null;
                    isOnRedDoor = false;
                    Destroy(redDoorObject);
                    redDoorObject = null;
                }
            }
        }
    }

    public void SkillSlide(){
        isSliding = true;
        animator.SetBool("Slide",true);
        if(isRight){
            //Right'
            ridigBody2D.AddForce(Vector2.right * slideSpeed);
        }else{
            //left
            ridigBody2D.AddForce(Vector2.left * slideSpeed);
        }
        StartCoroutine(StopSlide());
    }

    IEnumerator StopSlide(){
        yield return new WaitForSeconds(0.75f);
        animator.SetBool("Slide",false);
        isSliding = false;
    }


    void TakeDamage(int damage){
        if(!isSliding){
            healthbar = healthbar - damage;
        }
    }


    void OnTriggerEnter2D (Collider2D other ){
        if(other.gameObject.tag == "health"){
            healthbar = healthbar + 50;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "deathzone"){
            healthbar = 0;
            //Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "enemy"){
            TakeDamage(10);
        }
         if(other.gameObject.CompareTag("RedKey"))
        {
            if(isHandFree == true)
            {
                isRangObject = other.gameObject;
                Debug.Log("inRangeObject : " + isRangObject.name);
                isOnObject = true;
            }
            
        }
        if(other.gameObject.CompareTag("RedDoor"))
        {
            isOnRedDoor = true;
            redDoorObject = other.gameObject;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RedKey"))
        {
            isRangObject = null;
            isOnObject = false;
            
        }
        if(collision.gameObject.CompareTag("RedDoor"))
        {
            isOnRedDoor = false;
            redDoorObject = null;
        }
        
    }
    public void JumpButton()
    {
        if(Time.time > nextJumpPress){
            animator.SetBool("Jump",true);
            nextJumpPress = Time.time + jumpRate;
            ridigBody2D.AddForce(jumpSpeed*(Vector2.up * JumpPower));
            soundEffect.playjumpSound();
        }else{
            animator.SetBool("Jump",false);
        }
    }
}