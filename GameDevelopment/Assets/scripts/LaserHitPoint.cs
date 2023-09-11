using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHitPoint : MonoBehaviour
{
    public PlayerMouseController player;
    EnemyController enemy;
    asteroidController asteroid;
    public float LaserTime = 5f;
    public bool LaserisHitting;
    public bool LaserisHittingAst;
    [SerializeField]
    private int Damage = 2;
    [SerializeField]
    private float DoTSpeed = 0.5f;
    private bool DoTIsActive;
    private bool AstDoTIsActive;

    public void OnTriggerStay(Collider EnemyHit)
    {
        //Laser zerstört Gegner mit einem hit
        
        enemy = EnemyHit.GetComponent<EnemyController>();

        if (enemy != null)
        {

            if (enemy.CanBeAttacked == true)
            {
                DoTIsActive = true;
                LaserisHitting = true;
                Invoke("DamageEnemy", DoTSpeed);
                enemy.CanBeAttacked = false;
            } 

        }
        else
        {      
            DoTIsActive = false;
            LaserisHitting = false;
            enemy = null;
            return;  
        }


    }

    public void OnTriggerEnter(Collider AsteroidHit)
    {
        asteroid = AsteroidHit.GetComponent<asteroidController>();

        if (asteroid != null)
        {
            Invoke("HitAsteroid", DoTSpeed);
            
        }
       

    }

    public void DamageEnemy()
    {
        if (LaserisHitting)
        {

            if (enemy.Health > 0)
            {
                enemy.TakeDamage(Damage);
                enemy.CanBeAttacked = true;
            }
            else
            {
                enemy = null;
                LaserisHitting = false;
                return;
            }
        }
        else return;
    }


    public void HitAsteroid()
    {
        if (asteroid != null)
        {
            asteroid.GetHit(2);   
        }
        
       else
        {
            return;
        }
    }

}
