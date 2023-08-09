using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trainReference;

    private GameObject spawnedTrain;

    private int randomIndex;

    private int randomNumber;

    public static int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTrains());
    }

    // Update is called once per frame
    IEnumerator SpawnTrains(){
        while(true){
            
            yield return new WaitForSeconds(Random.Range(2,5));
         
            randomIndex  = Random.Range(0,trainReference.Length);

            randomNumber = Random.Range(1,4);
            
            spawnedTrain = Instantiate(trainReference[randomIndex]);
            if (randomIndex == 0){
            spawnedTrain.GetComponent<follower_L>().speed = randomNumber;
            }
            else if (randomIndex == 1){
                spawnedTrain.GetComponent<follower_R>().speed = randomNumber;
            }
            
            
        }

    }
}
