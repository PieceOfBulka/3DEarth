using DigitalRubyShared;
using System.Collections;
using UnityEngine;

public class Finger_Touch : MonoBehaviour
{
    public GameObject activeObj;
    
    private TapGestureRecognizer tapGesture;
    private SwipeGestureRecognizer swipeGesture;
    private ScaleGestureRecognizer scaleGesture;

    void Start()
    {
        CreateTapGesture();
        CreateSwipeGesture();
        CreateScaleGesture();
    }

   // нажатие на экран
    private void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            print("Tap");
        }
    }

    private void CreateTapGesture()
    {
        tapGesture = new TapGestureRecognizer();
        tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(tapGesture);
    }

    IEnumerator RotateActiveObject(float angel)
    {
        float initAngel = activeObj.transform.rotation.y;
        for (float i = 0f; i <= 1f; i += Time.deltaTime / 0.01f)
        {
            activeObj.transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(initAngel, initAngel + angel, i), Vector3.up);
            yield return null;
        }
    }

    // проводим по экрану
    private void SwipeGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            print("Swipe");
            StartCoroutine(RotateActiveObject(-gesture.DistanceX / Screen.width * 360f));
        }
    }

    private void CreateSwipeGesture()
    {
        swipeGesture = new SwipeGestureRecognizer();
        swipeGesture.Direction = SwipeGestureRecognizerDirection.Any;
        swipeGesture.StateUpdated += SwipeGestureCallback;
        swipeGesture.DirectionThreshold = 1.0f;
        FingersScript.Instance.AddGesture(swipeGesture);
    }

    //разводим, сводим пальцы
    private void ScaleGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            float newScale = Mathf.Clamp(activeObj.transform.localScale.x + scaleGesture.ScaleMultiplier, 0.3f, 0.3f);
            activeObj.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    private void CreateScaleGesture()
    {
        scaleGesture = new ScaleGestureRecognizer();
        scaleGesture.StateUpdated += ScaleGestureCallback;
        FingersScript.Instance.AddGesture(scaleGesture);
    }
}
