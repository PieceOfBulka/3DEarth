using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeorphyCompare : MonoBehaviour
{
    public GameObject[] geographyObjs;
    public GameObject earth;
    public GameObject textObject;
    private string inputText;

    void Start()
    {
        geographyObjs = GameObject.FindGameObjectsWithTag("Geography_obj");
    }

    public void SetText(string text)
    {
        inputText = text;
    }

    public void ButtonSearchPressed()
    {
        //тут проверка ввода
        if (!int.TryParse(inputText, out int num))
        {
            GameObject obj = FindObj(inputText);
            //тут проверка, нашли ли объект
            if (obj != null)
            {
                StartCoroutine(RotateActiveObject(obj));
                //Rotate(obj);
            }
            //else ошибка
        }
        //else ошибка
    }

    public GameObject FindObj(string name)
    {
        //цикл по всем объектам. ищите компонент GeographyObj, а в нем имя. Сравниваем имена и возвращаем нужный объект. Если не нашли, возвращаем нулевой указатель
        GameObject gm;
        for (int i = 0; i<geographyObjs.Length; i++)
        {
            gm = geographyObjs[i];
            if (gm.GetComponent<GeographyObject>().name == name) 
                return gm;
        }
        return null; //возвращаем, когда объекта нет
    }

    // метод юнити, разворачивающий объект
    public void Rotate(GameObject gm)
    {
        Vector3 vectorToObj = gm.transform.position - earth.transform.position;
        Vector3 vectorToCamera = Camera.main.transform.position - earth.transform.position;
        
        earth.transform.rotation = Quaternion.FromToRotation(vectorToObj, vectorToCamera);
        print(Quaternion.FromToRotation(vectorToObj, vectorToCamera));
    }

    IEnumerator RotateActiveObject(GameObject gm)
    {
        float initAngel = earth.transform.rotation.y;
        Vector3 vectorToObj = gm.transform.position - earth.transform.position;
        Vector3 vectorToCamera = Camera.main.transform.position - earth.transform.position;
        Quaternion currentRotation = earth.transform.rotation;
        Quaternion finalRotation = Quaternion.FromToRotation(vectorToObj, vectorToCamera);

        for (float i = 0f; i <= 1f; i += Time.deltaTime / 1f)
        {
            print(Quaternion.FromToRotation(vectorToObj, vectorToCamera));
            earth.transform.rotation = Quaternion.Lerp(currentRotation, finalRotation, i);

            yield return null;
        }
    }
}
