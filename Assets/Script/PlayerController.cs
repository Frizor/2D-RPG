/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public Transform arrow; // ������ �� ����������� �������
    public Camera mainCamera; // ������ �� ������� ������
    public Transform playerModel; // ������ �� ������ ������
    private bool isTurning = false; // ����, �����������, ��� ����� � �������� ��������
    private float targetRotationY = 0.0f; // ������� ���� �������� ������ �� Y
    public float rotationSpeed = 90.0f; // �������� �������� ������
    public GameObject weapon; // ������ �� ������ ������
    private bool isAttacking = false; // ����, �����������, ��� ����� � �������� �����
    public float attackCooldown = 1.0f; // ����� ����������� �����
    private bool isMovingLeft = false; // ����, �����������, ��� ����� ��������� �����

    public float leftOffset = -0.2f; // �������� ����� ��� �����
    public float attackDuration = 0.5f; // ������������ �����

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ������ ��������
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // ���������� ������
        transform.Translate(movement);

        // ������ �������� ������� ������
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

        // ������������ ������� � ����������� �����
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������� ������� ������, ����� ��� ������� �� �������
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

        // ��������� ����� ��� ������� ���
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

        // �������� ������ ������
        weapon.SetActive(true);

        // ��������� �������� ����� ��� �����, ���� ��������� �����
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

        // ����� �� ������ �������� ������ ����� ��� �������� "������"

        // ���� ��������� ����� ��� �������� �����
        yield return new WaitForSeconds(attackDuration);

        // ������������ � �������� ��������� ����� �����
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

        // ��������� ������ ������
        weapon.SetActive(false);

        isAttacking = false;

        // �������� ����� ��������� ������ (�����������)
        yield return new WaitForSeconds(attackCooldown);
    }
}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public Transform arrow; // ������ �� ����������� �������
    public Camera mainCamera; // ������ �� ������� ������
    public Transform playerModel; // ������ �� ������ ������
    private bool isTurning = false; // ����, �����������, ��� ����� � �������� ��������
    private float targetRotationY = 0.0f; // ������� ���� �������� ������ �� Y
    public float rotationSpeed = 90.0f; // �������� �������� ������
    public GameObject weapon; // ������ �� ������ ������
    private bool isAttacking = false; // ����, �����������, ��� ����� � �������� �����
    public float attackCooldown = 1.0f; // ����� ����������� �����

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ������ ��������
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // ���������� ������
        transform.Translate(movement);

        // ������ �������� ������� ������
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

        // ������������ ������� � ����������� �����
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������� ������� ������, ����� ��� ������� �� �������
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);

        // ��������� ����� ��� ������� � ��������� ���
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

        // �������� ������ ������
        weapon.SetActive(true);

        // ����� �� ������ �������� ������ ����� ��� �������� "������"

        // ���� ��������� ����� ��� �������� �����
        yield return new WaitForSeconds(0.5f);

        // ��������� ������ ������
        weapon.SetActive(false);

        isAttacking = false;

        // �������� ����� ��������� ������ (�����������)
        yield return new WaitForSeconds(attackCooldown);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public Transform arrow; // ������ �� ����������� �������
    public Camera mainCamera; // ������ �� ������� ������
    public Transform playerModel; // ������ �� ������ ������
    public Animator playerAnimator; // ������ �� ��������� ���������
    private bool isTurning = false; // ����, �����������, ��� ����� � �������� ��������
    private float targetRotationY = 0.0f; // ������� ���� �������� ������ �� Y
    public float rotationSpeed = 90.0f; // �������� �������� ������

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ������ ��������
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        if (movement.magnitude > 0) // ���������, ��������� �� �����
        {
            // ������������� �������� "Move" � true ��� ��������������� �������� ������
            playerAnimator.SetBool("Move", true);
        }
        else
        {
            // ������������� �������� "Move" � false ��� ��������������� �������� �����
            playerAnimator.SetBool("Move", false);
        }

        // ���������� ������
        transform.Translate(movement);

        // ������ �������� ������� ������
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

        // ������������ ������� � ����������� �����
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������� ������� ������, ����� ��� ������� �� �������
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public Transform arrow; // ������ �� ����������� �������
    public Camera mainCamera; // ������ �� ������� ������
    public Transform playerModel; // ������ �� ������ ������
    private bool isTurning = false; // ����, �����������, ��� ����� � �������� ��������
    private float targetRotationY = 0.0f; // ������� ���� �������� ������ �� Y
    public float rotationSpeed = 90.0f; // �������� �������� ������

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ������ ��������
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * moveSpeed * Time.deltaTime;

        // ���������� ������
        transform.Translate(movement);

        // ������ �������� ������� ������
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

        // ������������ ������� � ����������� �����
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������� ������� ������, ����� ��� ������� �� �������
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public Transform arrow; // ������ �� ����������� �������
    public Camera mainCamera; // ������ �� ������� ������

    void Update()
    {
        // �������� ���� � ����������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ������ ��������
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // ���������� ������
        transform.Translate(movement);

        // ������������ ������� � ����������� �������� �����
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������� ������� ������, ����� ��� ������� �� �������
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
*/