using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using AudioSynthesis.Bank;
using AudioSynthesis.Midi;
using AudioSynthesis.Sequencer;
using AudioSynthesis.Synthesis;
using Kazedan.Construct;
using UnityEngine;
using UnityMidi;

[RequireComponent(typeof(AudioSource))]
public class Bars : MonoBehaviour {

    [SerializeField] StreamingAssetResouce bankSource;
    [SerializeField] StreamingAssetResouce midiSource;
    [SerializeField] int channel = 1;
    [SerializeField] int sampleRate = 44100;
    [SerializeField] int bufferSize = 1024;

    private MidiPlayer player;
    //SpriteRenderer sr;
    //private Sprite[] sprites;

    // Use this for initialization
    void Start () {
	    
	    //sequencer.ShowDebug = true;
	    
	    //sequencer.Load("C:/repo/Piano/Assets/bach.mid");
     //   sequencer.Start();


        var synthesizer = new Synthesizer(sampleRate, channel, bufferSize, 1);
        var sequencer = new MidiFileSequencer(synthesizer);
        var audioSource = GetComponent<AudioSource>();

        
        player = new UnityMidi.MidiPlayer();
        player.Awake(synthesizer,sequencer,audioSource, bankSource, midiSource);
        player.Play();

    }


    // Update is called once per frame
    void Update () {
        //sequencer.UpdateNotePositions();
        //sequencer.UpdateRenderer();
        ////sr.size.Set(sr.size.x + count, sr.size.y + count);
        //int noteIndex = 0;

        //foreach (var bar in BarPool.bars)
        //{
        //    bar.SetActive(false);
        //}

        //var notesArray = sequencer.NoteManager.Notes.ToArray();

        //foreach (var n in notesArray)
        //{
        //    var noteOffset = 0;
        //    var noteCount = 88;
        //    float keywidth = 3f;
        //    float scale = 0.001f;
        //    float yoffset = 5f;
        //    float xspacing = 30f;
        //    if (n.Key >= noteOffset && n.Key < noteOffset + noteCount && n.Length > 0 && n.Velocity > 0)
        //    {
        //        float left = n.Key * keywidth + (xspacing * n.Key);
        //        float x = left;
        //        float y = 100f - n.Position;
        //        float width = keywidth;
        //        float height = n.Length * 1f ;
        //        var bar = BarPool.bars[noteIndex];
        //        var renderer = bar.GetComponentInChildren<SpriteRenderer>();
        //        renderer.transform.position = new Vector3(x * scale, (y - (height / 2))* scale);
        //        renderer.size = new Vector3(width * 0.01f, height * scale);
        //        bar.SetActive(true);
                
        //    }
        //    noteIndex++;
        //}
        
    }
}
