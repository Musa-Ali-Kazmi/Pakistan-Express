using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trainReference;

    private GameObject spawnedTrain;

    [SerializeField]
    private Transform leftPos, midPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTrains());
    }

    // Update is called once per frame
    IEnumerator SpawnTrains(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,5));
        
            randomIndex  = Random.Range(0,trainReference.Length);
            randomSide = Random.Range(0,3);

            spawnedTrain = Instantiate(trainReference[randomIndex]);

            if (randomSide==0){
                spawnedTrain.transform.position = leftPos.position;  
                spawnedTrain.GetComponent<TrainMovment>().speed = Random.Range(1,9); 
            }
            else if (randomSide==1){
                spawnedTrain.transform.position = midPos.position; 
                spawnedTrain.GetComponent<TrainMovment>().speed = Random.Range(1,9);
            }
            else{
                spawnedTrain.transform.position = rightPos.position;
                spawnedTrain.GetComponent<TrainMovment>().speed = Random.Range(1,9);
 
            }
        }

    }
}
