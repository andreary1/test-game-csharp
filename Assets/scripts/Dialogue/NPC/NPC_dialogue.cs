using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_dialogue : MonoBehaviour
{
    public float DialogueRange;
    public LayerMask PlayerLayer;

    public DialogueSettings dialogue;

    private List<string> sentences = new List<string>();
    private List<string> actorName = new List<string>();
    private List<Sprite> actorSprite = new List<Sprite>();

    private void Start()
    {
        GetDialogue();
    }

    bool PlayerHit;
    // É chamado a cada frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
        }
    }

    void GetDialogue()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }

            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);
        }
    }

    // É usado pela física
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogueRange, PlayerLayer);

        if (hit != null)
        {
            PlayerHit = true;
        }
        else
        {
            PlayerHit = false;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DialogueRange);
    }

}
