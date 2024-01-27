using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {

    public float moveRange;
    private  Light _light;
    float range;
    public float min, max;
    float timeRand;
    Vector3 pos;
	void Start () {
        _light = GetComponent<Light>();
        range = _light.range;
        pos = _light.transform.position;
        StartCoroutine(lightF());
    }
    IEnumerator lightF()
    {
        float r = r = range * Random.Range(min, max);
        Vector2 newPos = Random.insideUnitCircle * moveRange;
        Vector3 randPos = new Vector3(newPos.x,0, newPos.y);
        while (true)
        {
            if (timeRand > 10)
            {
                r = range * Random.Range(min, max);
                newPos =  Random.insideUnitCircle * moveRange;
                randPos = new Vector3(newPos.x, 0, newPos.y);
                timeRand = 0;
            }
            _light.transform.position = Vector3.Lerp(_light.transform.position, pos + randPos, 0.05f);
            _light.range = Mathf.Lerp(_light.range, r,0.1f);
            timeRand++;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
