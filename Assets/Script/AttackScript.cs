using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // Ссылка на объект атаки
    public Camera mainCamera; // Ссылка на главную камеру
    public float attackActivationTime = 0.2f; // Время активации атаки
    public float attackDeactivationTime = 0.1f; // Время деактивации атаки

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // При нажатии левой кнопки мыши
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Устанавливаем позицию атаки в направлении указателя мыши
            attackObject.transform.position = mousePosition;

            // Активируем объект атаки
            attackObject.SetActive(true);

            // Запускаем корутину для деактивации атаки через короткий промежуток времени
            StartCoroutine(DeactivateAttack(attackDeactivationTime));
        }
    }

    IEnumerator DeactivateAttack(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Деактивируем объект атаки
        attackObject.SetActive(false);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // Ссылка на объект атаки
    public Camera mainCamera; // Ссылка на главную камеру
    public float attackDistance = 2.0f; // Расстояние движения атаки
    public float attackSpeed = 10.0f; // Скорость движения атаки

    private bool isAttacking = false;
    private Vector3 initialAttackPosition; // Начальная позиция атаки

    void Start()
    {
        // Сохраняем начальную позицию атаки
        initialAttackPosition = attackObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // При удержании левой кнопки мыши
        {
            if (!isAttacking)
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // Вычисляем направление курсора от игрока
                Vector3 direction = (mousePosition - transform.position).normalized;

                // Устанавливаем позицию атаки перед игроком
                Vector3 targetPosition = transform.position + direction * attackDistance;

                // Запускаем корутину для движения атаки
                StartCoroutine(MoveAttack(targetPosition, direction));
            }
        }
    }

    IEnumerator MoveAttack(Vector3 targetPosition, Vector3 attackDirection)
    {
        isAttacking = true;

        // Сбрасываем позицию атаки на начальную
        attackObject.transform.position = initialAttackPosition;

        attackObject.SetActive(true);

        while (Vector3.Distance(attackObject.transform.position, targetPosition) > 0.1f)
        {
            // Плавно перемещаем объект атаки к целевой позиции
            attackObject.transform.position = Vector3.MoveTowards(attackObject.transform.position, targetPosition, attackSpeed * Time.deltaTime);

            // Поворачиваем объект атаки в направлении движения
            attackObject.transform.up = attackDirection;

            yield return null;
        }

        // Отключаем объект атаки
        attackObject.SetActive(false);

        isAttacking = false;
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // Ссылка на объект атаки
    public Camera mainCamera; // Ссылка на главную камеру
    public float attackDistance = 2.0f; // Расстояние движения атаки
    public float attackSpeed = 10.0f; // Скорость движения атаки
    public float attackRotationSpeed = 180.0f; // Скорость поворота атаки

    private bool isAttacking = false;
    private Vector3 initialAttackPosition; // Начальная позиция атаки

    void Start()
    {
        // Сохраняем начальную позицию атаки
        initialAttackPosition = attackObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // При удержании левой кнопки мыши
        {
            if (!isAttacking)
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // Вычисляем направление курсора от игрока
                Vector3 direction = (mousePosition - transform.position).normalized;

                // Устанавливаем позицию атаки перед игроком
                Vector3 targetPosition = transform.position + direction * attackDistance;

                // Запускаем корутину для движения атаки
                StartCoroutine(MoveAttack(targetPosition, direction));
            }
        }
    }

    IEnumerator MoveAttack(Vector3 targetPosition, Vector3 attackDirection)
    {
        isAttacking = true;

        // Сбрасываем позицию атаки на начальную
        attackObject.transform.position = initialAttackPosition;

        attackObject.SetActive(true);

        while (Vector3.Distance(attackObject.transform.position, targetPosition) > 0.1f)
        {
            // Плавно перемещаем объект атаки к целевой позиции
            attackObject.transform.position = Vector3.MoveTowards(attackObject.transform.position, targetPosition, attackSpeed * Time.deltaTime);

            yield return null;
        }

        // Плавно поворачиваем объект атаки в направлении атаки
        Quaternion targetRotation = Quaternion.LookRotation(attackDirection, Vector3.up);
        while (Quaternion.Angle(attackObject.transform.rotation, targetRotation) > 1.0f)
        {
            attackObject.transform.rotation = Quaternion.RotateTowards(attackObject.transform.rotation, targetRotation, attackRotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Отключаем объект атаки
        attackObject.SetActive(false);

        isAttacking = false;
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // Ссылка на объект атаки
    public Camera mainCamera; // Ссылка на главную камеру

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // При нажатии на левую кнопку мыши
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Вычисляем направление курсора от игрока
            Vector3 direction = (mousePosition - transform.position).normalized;

            // Устанавливаем позицию атаки впереди игрока и включаем ее
            attackObject.transform.position = transform.position + direction;
            attackObject.SetActive(true);

            // Поворачиваем атаку в направлении курсора
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            attackObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Input.GetMouseButtonUp(0)) // При отпускании левой кнопки мыши
        {
            // Выключаем объект атаки
            attackObject.SetActive(false);
        }
    }
}*/