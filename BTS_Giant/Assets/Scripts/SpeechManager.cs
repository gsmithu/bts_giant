using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    //KeywordRecognizer keywordRecognizer = null;
    //Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    //// Use this for initialization
    //void Start()
    //{
    //    keywords.Add("Red", () =>
    //    {
    //        this.OnColourChangeRequested("red");
    //    });

    //    keywords.Add("Green", () =>
    //    {
    //        this.OnColourChangeRequested("green");
    //    });

    //    keywords.Add("Blue", () =>
    //    {
    //        this.OnColourChangeRequested("blue");
    //    });

    //    keywords.Add("Yellow", () =>
    //    {
    //        this.OnColourChangeRequested("yellow");
    //    });

    //    keywords.Add("Orange", () =>
    //    {
    //        this.OnColourChangeRequested("orange");
    //    });

    //    keywords.Add("Pink", () =>
    //    {
    //        this.OnColourChangeRequested("pink");
    //    });

    //    // Tell the KeywordRecognizer about our keywords.
    //    keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

    //    // Register a callback for the KeywordRecognizer and start recognizing!
    //    keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
    //    keywordRecognizer.Start();
    //}

    //private void OnColourChangeRequested(string colour)
    //{
    //    var focusObject = GazeGestureManager.Instance.FocusedObject;
    //    if (focusObject != null)
    //    {
    //        // Call the OnDrop method on just the focused object.
    //        focusObject.SendMessage("OnColourChangeRequested", colour);
    //    }

    //}

    //private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    System.Action keywordAction;
    //    if (keywords.TryGetValue(args.text, out keywordAction))
    //    {
    //        keywordAction.Invoke();
    //    }
    //}
}