using UnityEngine;
using System.Collections;

public class lightsaber : MonoBehaviour {

	LineRenderer lineRend;
	public GameObject startPos;
	public GameObject endPos;

    private float textureOffset = 0f;
	private bool on = false;
	private Vector3 endPosExtendedPos;

	// Use this for initialization
	void Start () 
	{
		lineRend = GetComponent<LineRenderer>();

        endPosExtendedPos = endPos.GetComponent<Transform>().localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
        var startPosT = startPos.GetComponent<Transform>();
        var endPosT = endPos.GetComponent<Transform>();

        //turn lightsaber off and on//
        if (OVRInput.GetDown(OVRInput.Button.One))
		{
			if(on)
			{
				on = false;
			}
			else
			{
				on = true;
			}
		}
		//extend the line//
		if(on)
		{
            endPosT.localPosition = Vector3.Lerp(endPosT.localPosition,endPosExtendedPos,Time.deltaTime*5f);
            startPos.GetComponent<Light>().enabled = true;
            endPos.GetComponent<Light>().enabled = true;
        }
		//hide line//
		else
		{
            endPosT.localPosition = Vector3.Lerp(endPosT.localPosition,startPosT.localPosition,Time.deltaTime*5f);

            startPos.GetComponent<Light>().enabled = false;
            endPos.GetComponent<Light>().enabled = false;
        }

        //update line positions//
        lineRend.SetPosition(0, startPosT.position);
		lineRend.SetPosition(1, endPosT.position);

		//pan texture//
		textureOffset -= Time.deltaTime*2f;
		if(textureOffset < -10f)
		{
			textureOffset += 10f;
		}
		lineRend.sharedMaterials[1].SetTextureOffset("_MainTex",new Vector2(textureOffset,0f));
	}
}













