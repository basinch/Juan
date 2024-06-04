using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Vector3 throwVector;
    Rigidbody2D _rb;
    LineRenderer _lr;
    Vector3 startPosition;

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _lr = this.GetComponent<LineRenderer>();
        startPosition = transform.position; // Başlangıç pozisyonunu kaydediyoruz
    }

    //onmouse events possible thanks to monobehaviour + collider2d
    void OnMouseDown()
    {
        CalculateThrowVector();
        SetArrow();
    }

    void OnMouseDrag()
    {
        CalculateThrowVector();
        SetArrow();
    }

    void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //doing vector2 math to ignore the z values in our distance.
        Vector2 distance = mousePos - this.transform.position;
        //dont normalize the distance if you want the throw strength to vary
        throwVector = distance.normalized * 300;
    }

    void SetArrow()
    {
        _lr.positionCount = 2;
        _lr.SetPosition(0, Vector3.zero);
        _lr.SetPosition(1, throwVector.normalized / 2);
        _lr.enabled = true;
    }

    void OnMouseUp()
    {
        RemoveArrow();
        Throw();
    }

    void RemoveArrow()
    {
        _lr.enabled = false;
    }

    public void Throw()
    {
        _rb.AddForce(throwVector);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Objeyi başlangıç pozisyonuna ışınla
        transform.position = startPosition;
        _rb.velocity = Vector2.zero; // Hareketi durdurmak için hızını sıfırla
        _rb.angularVelocity = 0f; // Dönme hızını sıfırla
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Objeyi durdur
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0f;

        // Başlangıç pozisyonuna yavaşça dön
        StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart()
    {
        float duration = 1f; // Dönüş süresi
        float elapsedTime = 0f;

        Vector3 initialPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, startPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
    }
}