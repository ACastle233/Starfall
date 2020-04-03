using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    bool isDead = false;
    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        //Add something
        while (!isDead)
        {
            scoreBoard.ScoreHit(scorePerHit);
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            isDead = true;
            Destroy(gameObject);
        }
        
    }
}
