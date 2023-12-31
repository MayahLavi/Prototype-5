using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 15;
    private float maxTourqe =10;
    private float xRange = 4;
    private float ySpawnsPos = -2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle; 
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTourqe(),RandomTourqe(),RandomTourqe());
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }
    float RandomTourqe(){
        return Random.Range(-maxTourqe,maxTourqe);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange,xRange),ySpawnsPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }
    
}
