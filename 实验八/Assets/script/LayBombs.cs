using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LayBombs : MonoBehaviour
{
	[HideInInspector]
	public bool bombLaid = false;       // Whether or not a bomb has currently been laid.
	public int bombCount = 0;           // How many bombs the player has.
	public AudioClip bombsAway;         // Sound for when the player lays a bomb.
	public GameObject bomb;             // Prefab of the bomb.
	PlayerControl playerCtrl;

	private Text bombHUD;           // Heads up display of whether the player has a bomb or not.


	void Awake()
	{
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		// Setting up the reference.
		bombHUD = GameObject.Find("ui_bombHUD").GetComponent<Text>();
	}


	void Update()
	{
		// If the bomb laying button is pressed, the bomb hasn't been laid and there's a bomb to lay...
		if (Input.GetButtonDown("Fire2") && !bombLaid && bombCount > 0)
		{
			// Decrement the number of bombs.
			bombCount--;

			// Set bombLaid to true.
			bombLaid = true;

			// Play the bomb laying sound.
			AudioSource.PlayClipAtPoint(bombsAway, transform.position);

			// Instantiate the bomb prefab.
			Vector3 direction = new Vector3(0, 0, 0);
			//Instantiate(bomb, transform.position, transform.rotation);

			if (playerCtrl.bFaceRight)
			{
				direction.y = 180;
				Instantiate(bomb, transform.position, Quaternion.Euler(direction));
			}
			else
			{
				Instantiate(bomb, transform.position, Quaternion.Euler(direction));
			}
		}

		// The bomb heads up display should be enabled if the player has bombs, other it should be disabled.
		//bombHUD.enabled = bombCount > 0;
	}
}