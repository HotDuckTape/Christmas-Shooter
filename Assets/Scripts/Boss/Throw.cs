using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private float minTimer;
    [SerializeField] private GameObject objectToThrow;
    [SerializeField] private Transform spawnPos;
    private GameObject player;
    public AnimationCurve throwCurve;
    public float throwDuration = 2f;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("PlayerOne")[0];
        timer = Random.Range(minTimer, maxTimer);
    }
    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Debug.Log("Ur Mom");
            StartCoroutine(ThrowCoroutine());
            timer = Random.Range(minTimer, maxTimer);
        }
    }

    private IEnumerator ThrowCoroutine()
    {
        GameObject cupcake = Instantiate(objectToThrow, spawnPos.position, spawnPos.rotation);

        float elapsedTime = 0f;

        while (elapsedTime < throwDuration)
        {
            float normalizedTime = elapsedTime / throwDuration;
            float curveValue = throwCurve.Evaluate(normalizedTime);
            Vector3 throwPosition = Vector3.Lerp(cupcake.transform.position, player.transform.position, normalizedTime);
            throwPosition += Vector3.up * curveValue;
            cupcake.transform.position = throwPosition;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        //Damage
    }
}
