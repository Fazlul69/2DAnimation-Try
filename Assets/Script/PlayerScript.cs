using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animController;
    public Rigidbody2D playerRigid;
    public GameObject enemy;
    public int playerLife;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        InvokeRepeating("createEnemy",2f,10f);
        playerLife = 50;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        playerRigid.velocity = new Vector2(h*2, 0);
        playerRigid.position = new Vector2(Mathf.Clamp(playerRigid.transform.position.x, -3.93f, 3.44f), -2.56f);


        if (Input.GetMouseButtonDown(0)) {

            animController.SetBool("attack",true);
        }
        if (Input.GetKeyDown("s"))
        {

            animController.SetBool("attack", false);
        }
        if (Input.GetKeyDown("a"))
        {

            animController.SetBool("walkAgain", true);
        }
        if (Input.GetKeyDown("q"))
        {

            animController.SetBool("walkAgain", false);
        }

        //life
        if (playerLife < 1)
        {
            Destroy(gameObject);

        }
    }
    private void createEnemy() {

        float enemyRandomPos = Random.Range(-3.67f, -0.97f);

        Instantiate(enemy, new Vector3(enemyRandomPos, -2.56f,0),Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemySowrd")
        {
            playerLife--;
            Destroy(gameObject);
        }
    }
   
}
