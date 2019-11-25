using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : EnsinaRunnerController
{
    public float countdownTimer = 1f;
    public List<int> matrizPower;
    public List<int> matrizMutant;
    public GameObject iconPrefab;

    void Start()
    {
        ResetMatriz();
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        
        if (countdownTimer <= 0)
        {
            countdownTimer = 1f;

            var randomRangeMatriz = Random.Range(0, matrizMutant.Count);

            var randomValue = matrizMutant[randomRangeMatriz];

            if (randomValue == matrizMutant[0])
            {
                // Icone dá pergunta
                GameObject.Instantiate(iconPrefab);

                ResetMatriz();

                Debug.Log("Gera Pergunta!");
            }
            else
            {
                matrizMutant.Remove(randomValue);
                Debug.Log($"Não gera Pergunta: {randomValue}");
            }
        }
    }

    public void ResetMatriz()
    {
        matrizMutant = new List<int>();

        matrizMutant.AddRange(matrizPower);
    }
}