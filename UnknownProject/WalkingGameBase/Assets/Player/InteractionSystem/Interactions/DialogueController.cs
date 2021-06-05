using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Derrived Interaction System for controlling Dialogue

namespace InteractionSystem
{
    public class DialogueController : InteractableBase
    {
        // The text object that will be used to print the dialogue
        public TextMeshProUGUI DialogueText;

        // The sentences to be printed
        public string[] Sentences;

        // The index value, used for tracking which sentence the dialogue is on
        private int Index = 0;

        // The speed at which the text is printed
        public float DialogueSpeed;

        // The player object, used for disabling and enabling movement
        public GameObject Player;

        // The camera that the canvas will render everything to
        public GameObject Camera;

        // The Dialogue box that will be used to render everything
        public GameObject DialogueBox;

        // The animation used by the dialogue box
        public Animator DialogueBoxAnim;

        // The boolean that tells whether or not to go to the next sentence/end dialogue
        private bool NextText = true;

        // Override of the OnInteract() virtual function
        public override void OnInteract()
        {
            base.OnInteract();
            if (NextText == true)
            {
                NextText = false;
                Disable();
                this.NextSentence();
            }
        }

        // Calls next sentence, uses animation triggers for proper dialogue box animating
        void NextSentence()
        {
            if (Index <= Sentences.Length - 1)
            {
                if(Index == 0)
                {
                DialogueBoxAnim.SetTrigger("Enter");
                }
                DialogueText.text = "";
                StartCoroutine(WriteSentence());
            }
            else if (Index > Sentences.Length - 1)
            {
                DialogueText.text = "";
                Enable();
                DialogueBoxAnim.ResetTrigger("Enter");
                DialogueBoxAnim.SetTrigger("Exit");
                if (this.MultipleUse == true)
                {
                    Index = 0;
                    NextText = true;
                }
            }
        }

        // Command to write out the sentences word by word
        IEnumerator WriteSentence()
        {
            if(Index == 0)
            {
            yield return new WaitForSeconds(0.8F);
            }
            foreach (char Character in Sentences[Index].ToCharArray())
            {
                DialogueText.text += Character;
                yield return new WaitForSeconds(DialogueSpeed);
            }
            Index++;
            NextText = true;
        }

        // Disables movement before dialogue
        void Disable()
        {
            Player.GetComponent<Movement>().enabled = false;
            Camera.GetComponent<camAnimation>().enabled = false;
            Camera.GetComponent<MouseLook>().enabled = false;
        }

        // Enables movement after dialogue
        void Enable()
        {
            Player.GetComponent<Movement>().enabled = true;
            Camera.GetComponent<camAnimation>().enabled = true;
            Camera.GetComponent<MouseLook>().enabled = true;
        }

        // Pauses animation, prevents dialogue box from displaying before text
        private IEnumerator WaitForAnimation(Animation animation)
        {
            do
            {
                yield return null;
            }
            while (animation.isPlaying);
        }
    }
}
