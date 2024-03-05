using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToRecieveDamage : MonoBehaviour
{
    public bool damaged = false;

    public float duration = 1f;
    public float magnitude = 0.1f;

    [SerializeField] private EntityStats eStats;
    [SerializeField] private AsignTeam eTeam;
    [SerializeField] private NavMeshAgent eNavmesh;

    private void Start()
    {
        eStats = GetComponent<EntityStats>();
        eTeam = GetComponent<AsignTeam>();
        eNavmesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (damaged)
        {
            
            StartCoroutine(Shake());
            toDecreseLife(15);
            damaged = false;
        }
    }
    

    public void toDecreseLife(int damageRecieved)
    {
        eStats.life -= damageRecieved;
    }

    public IEnumerator Shake()
    {
       
        //Vector3 originalPosition = transform.localPosition;
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;
        eNavmesh.enabled = false;

        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude + originalPosition.x;
            float y = Random.Range(-1f, 1f) * magnitude + originalPosition.y;
             
            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        eNavmesh.enabled = true;
        transform.localPosition = originalPosition;
    }
}
