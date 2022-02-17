using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    Rigidbody rb;
    bool movingLeft = true;
    private bool playing;
    bool firstInput = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (!GameManager.instance.gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playing = true;
            }
        }

        else if (playing)
        {
            CheckInput();
            Move();
        }*/

        if (GameManager.instance.gameStarted)
        {
            
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            playing = false;
            GameManager.instance.GameOver();
        }
        
    }

    private void FixedUpdate()
    {
        if (playing)
        {
            //Move();
        }
        
    }

    void CheckInput()
    {
        if (firstInput) {

            firstInput = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void Move()
    {
        //rb.velocity = transform.forward * playerSpeed;

        transform.position += transform.forward * playerSpeed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90f, 0);
            

        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //started = false;
        //rb.isKinematic = false;
        //rb.velocity = Vector3.down * 20f;
        
    }

}
