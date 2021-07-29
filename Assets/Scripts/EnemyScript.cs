using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigidBody;
    private NavMeshAgent nav;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        nav = this.GetComponent<NavMeshAgent>();

        nav.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(this.transform.position, player.transform.position);

        //print(distancia);
        //print(nav.isStopped);

        if(distancia < 2)
        {
            anim.SetBool("Walk", false);

            StartCoroutine(TempoDeAtaque());

            //anim.SetTrigger("Attack");
        }
        else if(distancia < 10)
        {
            this.gameObject.transform.LookAt(player.transform.position);
            //nav.destination = player.transform.position;
            anim.SetBool("Walk", true);
            nav.SetDestination(player.transform.position);
            rigidBody.velocity = transform.forward * 5;
            //nav.Move(player.transform.position);
        }
        else if (distancia >= 10)
        {

            nav.isStopped = true;
            anim.SetBool("Walk", false);
        }
    }

    IEnumerator TempoDeAtaque()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
    }
}
