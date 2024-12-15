using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class XRTurretInteraction : XRBaseInteractable
{
    private Vector3 turretReset;
    public Transform turretBase;
    public Transform turretHorizontal;
    public Transform turretVertical;

    public float maxHorizontalAngle = 45f;
    public float minHorizontalAngle = -45f;
    // public float maxVerticalAngle = 30f;
    // public float minVerticalAngle = -30f;

    private IXRSelectInteractor _mSelectInteractor;

    [SerializeField] private InputActionReference triggerActionReference;

    void Start()
    {
        turretReset = transform.position;
        ResetTurret();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(StartGrab);
        selectExited.AddListener(EndGrab);
    }

    protected override void OnDisable()
    {
        selectEntered.RemoveListener(StartGrab);
        selectExited.RemoveListener(EndGrab);
        base.OnDisable();
    }


    void StartGrab(SelectEnterEventArgs args)
    {
        _mSelectInteractor = args.interactorObject;
    }

    void EndGrab(SelectExitEventArgs args)
    {
        _mSelectInteractor = null;
        ResetTurret();
    }

    void ResetTurret()
    {
        transform.position = turretReset;
        turretHorizontal.localRotation = Quaternion.identity;
        turretVertical.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        if (_mSelectInteractor != null)
        {
            UpdateBarrel();
            UpdateAttack();
        }
    }

    private void UpdateBarrel()
    {
        // 获取控制器位置
        Vector3 controllerPosition = _mSelectInteractor.transform.position;

        // 计算水平方向角度
        float scaleHorizontal = 1f;
        Vector3 horizontalDirection = turretBase.position - controllerPosition;
        horizontalDirection.y = 0;
        float horizontalAngle = Vector3.SignedAngle(turretBase.forward, horizontalDirection, turretBase.up);
        float scaleHorizontalAngle = horizontalAngle * scaleHorizontal;
        horizontalAngle = Mathf.Clamp(scaleHorizontalAngle, minHorizontalAngle, maxHorizontalAngle);
        turretHorizontal.localRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
    }

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float AttaclInterval = 0.2f;
    private float lastAttackTime = 0f;

    private void UpdateAttack()
    {
        if (Time.time - lastAttackTime < AttaclInterval)
        {
            return;
        }

        lastAttackTime = Time.time;

        if (triggerActionReference.action.ReadValue<float>() > 0.1f)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}