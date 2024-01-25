using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject objectToScaleDown;
    public GameObject objectToScaleUp;
    public float scaleDownSpeed = 1f;
    public float scaleUpSpeed = 1f;
    public float targetScaleUpSize = 1f;

    public WordDetector _wordDetector;
    private bool isScaling = false;

    private void Update()
    {
        if ( _wordDetector.menuOpening==true)
        {
            StartScaling();
        }
       // if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
       // {
       // ReverseScaling();
       // }
        if (_wordDetector.menuOpening==false)
        {
            ReverseScaling();
        }

        if (isScaling)
        {
            ScaleObjects();
        }
    }

    private void StartScaling()
    {
        isScaling = true;
    }

    private void ReverseScaling()
    {
        isScaling = false;
        objectToScaleDown.transform.localScale = Vector3.one;
        objectToScaleUp.transform.localScale = Vector3.zero;
    }

    private void ScaleObjects()
    {
        if (objectToScaleDown.transform.localScale.x > 0.01f ||
            objectToScaleDown.transform.localScale.y > 0.01f ||
            objectToScaleDown.transform.localScale.z > 0.01f)
        {
            objectToScaleDown.transform.localScale -= Vector3.one * scaleDownSpeed * Time.deltaTime;
          //  print("scaling Down started :"+objectToScaleDown.transform.localScale );

             if (objectToScaleDown.transform.localScale.x < 0.01f)
        objectToScaleDown.transform.localScale = new Vector3(0, objectToScaleDown.transform.localScale.y, objectToScaleDown.transform.localScale.z);
    if (objectToScaleDown.transform.localScale.y < 0.01f)
        objectToScaleDown.transform.localScale = new Vector3(objectToScaleDown.transform.localScale.x, 0, objectToScaleDown.transform.localScale.z);
    if (objectToScaleDown.transform.localScale.z < 0.01f)
        objectToScaleDown.transform.localScale = new Vector3(objectToScaleDown.transform.localScale.x, objectToScaleDown.transform.localScale.y, 0);


        }//else if(objectToScaleDown.transform.localScale== Vector3.zero)
        //{
           // isScaling = false;
           // print("scaling stopped  111:"+objectToScaleDown.transform.localScale );
        //}

        if (objectToScaleUp.transform.localScale.x < targetScaleUpSize ||
            objectToScaleUp.transform.localScale.y < targetScaleUpSize ||
            objectToScaleUp.transform.localScale.z < targetScaleUpSize)
        {
            objectToScaleUp.transform.localScale += Vector3.one * scaleUpSpeed * Time.deltaTime;
            //print("scaling Up started :"+objectToScaleUp.transform.localScale );
        } 
        
        else if(objectToScaleDown.transform.localScale== Vector3.zero)
        {
            isScaling = false;
            //print("scaling stopped 222:"+objectToScaleDown.transform.localScale );
            return;
        }
    }
}