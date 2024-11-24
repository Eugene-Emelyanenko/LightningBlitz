using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovement : MonoBehaviour
{
    public GameObject circles;
    public Transform[] objects; // Массив объектов
    public Vector3[] targetScales; // Целевые масштабы объектов
    private Vector3[] initialPositions; // Начальные позиции объектов

    public float transitionDuration = 1f; // Длительность анимации перемещения

    private bool isMoving = false;

    private void Start()
    {
        // Сохраняем начальные позиции объектов
        initialPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            initialPositions[i] = objects[i].position;
        }
        
        ShowCircles();
    }

    public void ShiftObjects()
    {
        if(isMoving)
            return;

        circles.SetActive(false);
        
        // Смещаем объекты на одну позицию вперёд в массиве
        Transform temp = objects[objects.Length - 1];
        for (int i = objects.Length - 1; i > 0; i--)
        {
            objects[i] = objects[i - 1];
        }
        objects[0] = temp;

        // Запускаем корутину для плавного перемещения объектов
        StartCoroutine(MoveObjects());
    }

    private void ShowCircles()
    {
        objects[2].gameObject.SetActive(false);
        circles.SetActive(true);
        circles.GetComponent<Circles>().SpawnNewCircles();
    }

    private IEnumerator MoveObjects()
    {
        foreach (var myObject in objects)
        {
            myObject.gameObject.SetActive(true);
        }
        isMoving = true;

        float elapsedTime = 0f;
        Vector3[] targetPositions = new Vector3[objects.Length];

        // Вычисляем целевые позиции для объектов
        for (int i = 0; i < objects.Length; i++)
        {
            targetPositions[i] = initialPositions[i];
        }

        // Плавно перемещаем объекты к целевым позициям и изменяем их размеры
        while (elapsedTime < transitionDuration)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].position = Vector3.Lerp(objects[i].position, targetPositions[i],
                    elapsedTime / transitionDuration);
                objects[i].localScale =
                    Vector3.Lerp(objects[i].localScale, targetScales[i], elapsedTime / transitionDuration);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем объекты на их новые позиции и размеры точно
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].position = targetPositions[i];
            objects[i].localScale = targetScales[i];
        }

        isMoving = false;
        
        ShowCircles();
    }
}
