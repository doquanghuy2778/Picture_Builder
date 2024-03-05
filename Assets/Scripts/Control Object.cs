using UnityEngine;

public class ControlObject : MonoBehaviour
{
    public GameObject ObjTarget;
    private bool _isDrag;
    Vector2 _mousPos;
    private Vector2 _posInit, _offSet;

    private void Start()
    {
        _posInit = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDrag)
            return;

        _mousPos = GetMousePos();
        transform.position = _mousPos;
        //fix tinh trang bi giat anh khi bam 
        transform.position = _mousPos - _offSet;
    }

    private void OnMouseDown()
    {
        _isDrag = true;
        //fix tinh trang bi giat anh khi bam 
        _offSet = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        _isDrag = false;
        float distance = Vector2.Distance(transform.position, (Vector2)ObjTarget.transform.position);
        if (distance <= 0.2f)
        {
            transform.position = ObjTarget.transform.position;
        }
        else
        {
            transform.position = _posInit;
        }
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
