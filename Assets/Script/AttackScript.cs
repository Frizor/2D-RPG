using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // ������ �� ������ �����
    public Camera mainCamera; // ������ �� ������� ������
    public float attackActivationTime = 0.2f; // ����� ��������� �����
    public float attackDeactivationTime = 0.1f; // ����� ����������� �����

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��� ������� ����� ������ ����
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // ������������� ������� ����� � ����������� ��������� ����
            attackObject.transform.position = mousePosition;

            // ���������� ������ �����
            attackObject.SetActive(true);

            // ��������� �������� ��� ����������� ����� ����� �������� ���������� �������
            StartCoroutine(DeactivateAttack(attackDeactivationTime));
        }
    }

    IEnumerator DeactivateAttack(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ������������ ������ �����
        attackObject.SetActive(false);
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // ������ �� ������ �����
    public Camera mainCamera; // ������ �� ������� ������
    public float attackDistance = 2.0f; // ���������� �������� �����
    public float attackSpeed = 10.0f; // �������� �������� �����

    private bool isAttacking = false;
    private Vector3 initialAttackPosition; // ��������� ������� �����

    void Start()
    {
        // ��������� ��������� ������� �����
        initialAttackPosition = attackObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // ��� ��������� ����� ������ ����
        {
            if (!isAttacking)
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // ��������� ����������� ������� �� ������
                Vector3 direction = (mousePosition - transform.position).normalized;

                // ������������� ������� ����� ����� �������
                Vector3 targetPosition = transform.position + direction * attackDistance;

                // ��������� �������� ��� �������� �����
                StartCoroutine(MoveAttack(targetPosition, direction));
            }
        }
    }

    IEnumerator MoveAttack(Vector3 targetPosition, Vector3 attackDirection)
    {
        isAttacking = true;

        // ���������� ������� ����� �� ���������
        attackObject.transform.position = initialAttackPosition;

        attackObject.SetActive(true);

        while (Vector3.Distance(attackObject.transform.position, targetPosition) > 0.1f)
        {
            // ������ ���������� ������ ����� � ������� �������
            attackObject.transform.position = Vector3.MoveTowards(attackObject.transform.position, targetPosition, attackSpeed * Time.deltaTime);

            // ������������ ������ ����� � ����������� ��������
            attackObject.transform.up = attackDirection;

            yield return null;
        }

        // ��������� ������ �����
        attackObject.SetActive(false);

        isAttacking = false;
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // ������ �� ������ �����
    public Camera mainCamera; // ������ �� ������� ������
    public float attackDistance = 2.0f; // ���������� �������� �����
    public float attackSpeed = 10.0f; // �������� �������� �����
    public float attackRotationSpeed = 180.0f; // �������� �������� �����

    private bool isAttacking = false;
    private Vector3 initialAttackPosition; // ��������� ������� �����

    void Start()
    {
        // ��������� ��������� ������� �����
        initialAttackPosition = attackObject.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // ��� ��������� ����� ������ ����
        {
            if (!isAttacking)
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // ��������� ����������� ������� �� ������
                Vector3 direction = (mousePosition - transform.position).normalized;

                // ������������� ������� ����� ����� �������
                Vector3 targetPosition = transform.position + direction * attackDistance;

                // ��������� �������� ��� �������� �����
                StartCoroutine(MoveAttack(targetPosition, direction));
            }
        }
    }

    IEnumerator MoveAttack(Vector3 targetPosition, Vector3 attackDirection)
    {
        isAttacking = true;

        // ���������� ������� ����� �� ���������
        attackObject.transform.position = initialAttackPosition;

        attackObject.SetActive(true);

        while (Vector3.Distance(attackObject.transform.position, targetPosition) > 0.1f)
        {
            // ������ ���������� ������ ����� � ������� �������
            attackObject.transform.position = Vector3.MoveTowards(attackObject.transform.position, targetPosition, attackSpeed * Time.deltaTime);

            yield return null;
        }

        // ������ ������������ ������ ����� � ����������� �����
        Quaternion targetRotation = Quaternion.LookRotation(attackDirection, Vector3.up);
        while (Quaternion.Angle(attackObject.transform.rotation, targetRotation) > 1.0f)
        {
            attackObject.transform.rotation = Quaternion.RotateTowards(attackObject.transform.rotation, targetRotation, attackRotationSpeed * Time.deltaTime);
            yield return null;
        }

        // ��������� ������ �����
        attackObject.SetActive(false);

        isAttacking = false;
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackObject; // ������ �� ������ �����
    public Camera mainCamera; // ������ �� ������� ������

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��� ������� �� ����� ������ ����
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // ��������� ����������� ������� �� ������
            Vector3 direction = (mousePosition - transform.position).normalized;

            // ������������� ������� ����� ������� ������ � �������� ��
            attackObject.transform.position = transform.position + direction;
            attackObject.SetActive(true);

            // ������������ ����� � ����������� �������
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            attackObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Input.GetMouseButtonUp(0)) // ��� ���������� ����� ������ ����
        {
            // ��������� ������ �����
            attackObject.SetActive(false);
        }
    }
}*/