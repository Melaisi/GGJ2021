using UnityEngine;
using System.Collections;

public class MineExplode : MonoBehaviour 
{
	public AudioClip Hurt;
	public AudioClip Explosion;
	private GameObject Mine;
	
	void Start () 
	{
		GetComponent<ParticleSystem>().Stop();
	}
	
	
	void OnTriggerEnter (Collider other) 
	{
	if (other.tag == "Player")
		{
			GetComponent<ParticleSystem>().Play ();
			GetComponent<AudioSource>().PlayOneShot(Hurt);
			GetComponent<AudioSource>().PlayOneShot(Explosion);
			Destroy (GetComponent<ParticleSystem>());
			Mine = GameObject.Find ("Mine");
			Mine.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
