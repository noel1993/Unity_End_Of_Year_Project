using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

        private PlatformerCharacter2D character;
        private bool jump;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if(!jump)
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");

        }

        private void FixedUpdate()
        {
            character.Move(1, false, jump);
            jump = false;
        }

		private void onTriggerEnter2D(Collider2D destroyed)
		{
			if (destroyed.tag == "Destoryed") 
			{
				Destroy(this.gameObject);
				
			}
		}


    }
}