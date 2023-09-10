using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public SpawnDeathAnimation AnimationSpawner;
    public EnemySpawner EnemySpawner;
    public EnemyHealthbar Healthbar;
    public float respawnTime = 1.0f;
    public float MoveSpeed = 0.1f;
    public float EnemyStartY = 10f;
    public int Health = 100;
    public bool CanBeAttacked;
    public GameObject ShipBody;

    private Vector2 screenBounds;

    Vector3 RotationAngleLeft;
    Vector3 RotationAngleRight;
    Vector3 StopAngle;

    public ScoreCounter Score;
    public GameObject BonusPoint;
    public PlayerMouseController player;
 

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.GetComponent<Rigidbody>();
        StartCoroutine(EnemyMover());
        CanBeAttacked = false;
        // Vector 100 entspricht 20 Grad in Engine 
        RotationAngleLeft = new Vector3(-90, 100, 0);
        RotationAngleRight = new Vector3(-90, -100, 0);
        StopAngle = new Vector3(0, 0, 0);
        EnemySpawner = FindObjectOfType<EnemySpawner>();
        EnemySpawner.EnemyIsAlive = true;
        Score = FindObjectOfType<ScoreCounter>();
        player = FindObjectOfType<PlayerMouseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.transform.position.y >= screenBounds.y * 0.8f)
        {
            rb.velocity = new Vector3(0, -2, 0);
            
        }
        else
        {
            //Gegner kann erst angegriffen werden, wenn er eine bestimmte Position auf dem Bildschirm erreicht
            CanBeAttacked = true;
        }
        

        //Rotiert den Gegner bei Bewegung
        if (rb.velocity.x > 0.2f)
        {
            
            Vector3 RotationRight2 = new Vector3(ShipBody.transform.rotation.x, ShipBody.transform.rotation.y - 80, ShipBody.transform.rotation.z);
            Quaternion RotationRight = Quaternion.Euler(RotationRight2);
            ShipBody.transform.rotation = Quaternion.Slerp(transform.rotation, RotationRight, 0.2f);
            
        }

        if (rb.velocity.x < -0.2f)
        {
            Vector3 RotationLeft2 = new Vector3(ShipBody.transform.rotation.x, ShipBody.transform.rotation.y + 80, ShipBody.transform.rotation.z);
            Quaternion RotationLeft = Quaternion.Euler(RotationLeft2);
            //Quaternion RotationLeft = Quaternion.Euler(RotationAngleLeft);
            ShipBody.transform.rotation = Quaternion.Slerp(transform.rotation, RotationLeft, 0.2f);
           
        }

        if (rb.velocity.x > -0.2f && rb.velocity.x < 0.2f)
        {

            Quaternion StopDeltaRotation = Quaternion.Euler(StopAngle);
            ShipBody.transform.rotation = Quaternion.Slerp(transform.rotation, StopDeltaRotation, 0.2f);

        }

      
    }

    private void MoveEnemy()
    {
        MoveSpeed = Random.Range(2f, -2f);
        
        rb.velocity = new Vector3(MoveSpeed, 0, 0);

        if (transform.position.x < (-screenBounds.x + 2))
        {
            rb.velocity = new Vector3(+2, 0, 0);
        }

        if (transform.position.x > (screenBounds.x - 2))
        {
            rb.velocity = new Vector3(-2, 0, 0);
        }

    }


    IEnumerator EnemyMover()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            MoveEnemy();
        }
    }

    public void TakeDamage(int damage)
    {
        if (CanBeAttacked == true)
        {
            Health -= damage;
            Healthbar.SetHealth(Health);
            if (Health <= 0)
            {
                
                Die();
            }
        }
    }

    public void Die()
    {
        //Hier Todesanimation abspielen
        AnimationSpawner.spawnAniamtion(transform.position);
        EnemySpawner.EnemyIsAlive = false;
        player.OnKill(BonusPoint);
        Score.ScoreAddEnemy();
        Destroy(this.gameObject);
    }




}
