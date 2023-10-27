/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения игрока
    public Transform arrow; // Ссылка на изображение стрелки
    public Camera mainCamera; // Ссылка на главную камеру
    public Transform playerModel; // Ссылка на модель игрока
    private bool isTurning = false; // Флаг, указывающий, что игрок в процессе поворота
    private float targetRotationY = 0.0f; // Целевой угол поворота игрока по Y
    public float rotationSpeed = 90.0f; // Скорость поворота игрока
    public GameObject weapon; // Ссылка на объект оружия
    private bool isAttacking = false; // Флаг, указывающий, что игрок в процессе атаки
    public float attackCooldown = 1.0f; // Время перезарядки атаки
    private bool isMovingLeft = false; // Флаг, указывающий, что игрок двигается влево

    public float leftOffset = -0.2f; // Смещение влево при атаке
    public float attackDuration = 0.5f; // Длительность атаки

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Рассчитываем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);

        // Плавно изменяем поворот игрока
        if (horizontalInput < 0)
        {
            if (!isTurning && targetRotationY != -180.0f)
            {
                targetRotationY = -180.0f;
                isTurning = true;
                isMovingLeft = true;
            }
        }
        else if (horizontalInput > 0)
        {
            if (!isTurning && targetRotationY != 0.0f)
            {
                targetRotationY = 0.0f;
                isTurning = true;
                isMovingLeft = false;
            }
        }
        else
        {
            isTurning = false;
        }

        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.Euler(0, targetRotationY, 0), rotationSpeed * Time.deltaTime);

        // Поворачиваем стрелку в направлении мышки
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Обновляем позицию камеры, чтобы она следила за игроком
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

        // Обработка атаки при нажатии ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;

        // Включаем объект оружия
        weapon.SetActive(true);

        // Выполняем смещение влево при атаке, если двигаемся влево
        if (isMovingLeft)
        {
            Vector3 originalPosition = transform.position;
            Vector3 targetPosition = new Vector3(originalPosition.x + leftOffset, originalPosition.y, originalPosition.z);
            float elapsedTime = 0;

            while (elapsedTime < attackDuration)
            {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / attackDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        // Здесь вы можете вставить логику атаки или анимацию "взмаха"

        // Ждем некоторое время для анимации атаки
        yield return new WaitForSeconds(attackDuration);

        // Возвращаемся в исходное положение после атаки
        if (isMovingLeft)
        {
            Vector3 originalPosition = transform.position;
            Vector3 targetPosition = new Vector3(originalPosition.x - leftOffset, originalPosition.y, originalPosition.z);
            float elapsedTime = 0;

            while (elapsedTime < attackDuration)
            {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / attackDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        // Выключаем объект оружия
        weapon.SetActive(false);

        isAttacking = false;

        // Задержка перед следующей атакой (перезарядка)
        yield return new WaitForSeconds(attackCooldown);
    }
}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения игрока
    public Transform arrow; // Ссылка на изображение стрелки
    public Camera mainCamera; // Ссылка на главную камеру
    public Transform playerModel; // Ссылка на модель игрока
    private bool isTurning = false; // Флаг, указывающий, что игрок в процессе поворота
    private float targetRotationY = 0.0f; // Целевой угол поворота игрока по Y
    public float rotationSpeed = 90.0f; // Скорость поворота игрока
    public GameObject weapon; // Ссылка на объект оружия
    private bool isAttacking = false; // Флаг, указывающий, что игрок в процессе атаки
    public float attackCooldown = 1.0f; // Время перезарядки атаки

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Рассчитываем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);

        // Плавно изменяем поворот игрока
        if (horizontalInput < 0)
        {
            if (!isTurning && targetRotationY != -180.0f)
            {
                targetRotationY = -180.0f;
                isTurning = true;
            }
        }
        else if (horizontalInput > 0)
        {
            if (!isTurning && targetRotationY != 0.0f)
            {
                targetRotationY = 0.0f;
                isTurning = true;
            }
        }
        else
        {
            isTurning = false;
        }

        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.Euler(0, targetRotationY, 0), rotationSpeed * Time.deltaTime);

        // Поворачиваем стрелку в направлении мышки
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Обновляем позицию камеры, чтобы она следила за игроком
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

        // Обработка атаки при нажатии и удержании ЛКМ
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;

        // Включаем объект оружия
        weapon.SetActive(true);

        // Здесь вы можете вставить логику атаки или анимацию "взмаха"

        // Ждем некоторое время для анимации атаки
        yield return new WaitForSeconds(0.5f);

        // Выключаем объект оружия
        weapon.SetActive(false);

        isAttacking = false;

        // Задержка перед следующей атакой (перезарядка)
        yield return new WaitForSeconds(attackCooldown);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения игрока
    public Transform arrow; // Ссылка на изображение стрелки
    public Camera mainCamera; // Ссылка на главную камеру
    public Transform playerModel; // Ссылка на модель игрока
    public Animator playerAnimator; // Ссылка на компонент аниматора
    private bool isTurning = false; // Флаг, указывающий, что игрок в процессе поворота
    private float targetRotationY = 0.0f; // Целевой угол поворота игрока по Y
    public float rotationSpeed = 90.0f; // Скорость поворота игрока

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Рассчитываем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        if (movement.magnitude > 0) // Проверяем, двигается ли игрок
        {
            // Устанавливаем параметр "Move" в true для воспроизведения анимации ходьбы
            playerAnimator.SetBool("Move", true);
        }
        else
        {
            // Устанавливаем параметр "Move" в false для воспроизведения анимации покоя
            playerAnimator.SetBool("Move", false);
        }

        // Перемещаем игрока
        transform.Translate(movement);

        // Плавно изменяем поворот игрока
        if (horizontalInput < 0)
        {
            if (!isTurning && targetRotationY != -180.0f)
            {
                targetRotationY = -180.0f;
                isTurning = true;
            }
        }
        else if (horizontalInput > 0)
        {
            if (!isTurning && targetRotationY != 0.0f)
            {
                targetRotationY = 0.0f;
                isTurning = true;
            }
        }
        else
        {
            isTurning = false;
        }

        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.Euler(0, targetRotationY, 0), rotationSpeed * Time.deltaTime);

        // Поворачиваем стрелку в направлении мышки
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Обновляем позицию камеры, чтобы она следила за игроком
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения игрока
    public Transform arrow; // Ссылка на изображение стрелки
    public Camera mainCamera; // Ссылка на главную камеру
    public Transform playerModel; // Ссылка на модель игрока
    private bool isTurning = false; // Флаг, указывающий, что игрок в процессе поворота
    private float targetRotationY = 0.0f; // Целевой угол поворота игрока по Y
    public float rotationSpeed = 90.0f; // Скорость поворота игрока

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Рассчитываем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);

        // Плавно изменяем поворот игрока
        if (horizontalInput < 0)
        {
            if (!isTurning && targetRotationY != -180.0f)
            {
                targetRotationY = -180.0f;
                isTurning = true;
            }
        }
        else if (horizontalInput > 0)
        {
            if (!isTurning && targetRotationY != 0.0f)
            {
                targetRotationY = 0.0f;
                isTurning = true;
            }
        }
        else
        {
            isTurning = false;
        }

        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.Euler(0, targetRotationY, 0), rotationSpeed * Time.deltaTime);

        // Поворачиваем стрелку в направлении мышки
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Обновляем позицию камеры, чтобы она следила за игроком
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения игрока
    public Transform arrow; // Ссылка на изображение стрелки
    public Camera mainCamera; // Ссылка на главную камеру

    void Update()
    {
        // Получаем ввод с клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Рассчитываем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);

        // Поворачиваем стрелку в направлении движения мышки
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Обновляем позицию камеры, чтобы она следила за игроком
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
*/