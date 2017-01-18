using UnityEngine;
using System.Collections;

public class multi_touch : MonoBehaviour {

    //public GUITexture test;
    // Update is called once per frame
    public void Check_touches  () {
	    if(Input.touches.Length <= 0)
        {

        }
        else
        {
            
            for(int i = 0; i < Input.touchCount; i++)
            {
                if (this.GetComponent<GUITexture>() != null && (this.GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position)))
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        ///Debug.Log("Button has been touched at" + Input.GetTouch(i).position);
                        this.SendMessage("OnTouchBeganAnywhere");
                    }
                    if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        ///Debug.Log("Button has been ended at" + Input.GetTouch(i).position);
                        this.SendMessage("OnTouchEndedAnywhere");
                    }
                    if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        ///Debug.Log("Button has been ended at" + Input.GetTouch(i).position);
                        this.SendMessage("OnTouchMovedAnywhere");
                    }
                    if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                    {
                        ///Debug.Log("Button has been ended at" + Input.GetTouch(i).position);
                        this.SendMessage("OnTouchStationaryAnywhere");
                    }

                }

            }
        }
	}

    public virtual void OnTouchBeganAnywhere()
    {

    }

    public virtual void OnTouchEndedAnywhere()
    {

    }
    public virtual void OnTouchMovedAnywhere()
    {

    }
    public virtual void OnTouchStationaryAnywhere()
    {

    }
}
