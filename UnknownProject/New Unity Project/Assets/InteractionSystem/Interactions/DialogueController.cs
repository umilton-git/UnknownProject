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
                DialogueText.text = "";
                StartCoroutine(WriteSentence());
            }
            else if (Index > Sentences.Length - 1)
            {
                DialogueText.text = "";
                Enable();
                if (this.MultipleUse == true)
                {
                    Index = 0;
                    NextText = true;
                }
            }
        }

        IEnumerator WriteSentence()
        {
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
    }
}
