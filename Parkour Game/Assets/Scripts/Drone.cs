using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    public float follow_distance = 10f;

    public float speed = 1.0f;

    private float cooldown = 2f;

    public GameObject mesh;
    public GameObject bullet;

    public float health = 100f;

    public GameObject death_effect;

    public AudioClip death_sound;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No player object found!");
        }
    }
    private void Update()
    {
        FollowPlayer();
        Shot();
        Death(); 
    }
    private void FollowPlayer()
    {
        //Look The Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(-90,-180,0);

        //Move To Player
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {


            transform.Translate(transform.forward * Time.deltaTime * speed / 1);
        }
        else
        {
            transform.RotateAround(player.position, transform.forward , Time.deltaTime * speed * Random.Range(0.2f , 3f));
            
        }
        
    }
    private void Shot()
    {
        if(cooldown > 0) 
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(90,0,0)));
        }
    }
    private void Death()
    {
        if (health <= 0)
        {
            //Spawn Particle
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //Play Sound Effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);

            //Destroy Gameobject
            Destroy(this.gameObject);
        }
    }
}
