using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VHS
{
    public class DialogueController : InteractableBase
    {
        public TextMeshProUGUI DialogueText;

        public string[] Sentences;

        private int Index = 0;

        public float DialogueSpeed;

        public GameObject Player;

        public GameObject Camera;

        public GameObject DialogueBox;

        public Animator DialogueBoxAnim;

        private bool NextText = true;

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

        void Disable()
        {
            Player.GetComponent<Movement>().enabled = false;
            Camera.GetComponent<camAnimation>().enabled = false;
            Camera.GetComponent<MouseLook>().enabled = false;
        }

        void Enable()
        {
            Player.GetComponent<Movement>().enabled = true;
            Camera.GetComponent<camAnimation>().enabled = true;
            Camera.GetComponent<MouseLook>().enabled = true;
        }

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
