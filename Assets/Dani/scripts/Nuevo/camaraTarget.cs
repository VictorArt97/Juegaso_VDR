using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class camaraTarget : MonoBehaviour
{
     private Camera mainCamera;   
    public CinemachineVirtualCamera virtualCamera; // Referencia a la Cinemachine Camera
    public Transform cursorTarget; // GameObject al que la cámara mirará

    public float zoomSpeed = 2f;      // Velocidad del zoom con la rueda del ratón
    public float minFOV = 20f;        // Mínimo Field of View (Zoom In)
    public float maxFOV = 60f;        // Máximo Field of View (Zoom Out)
    public float moveSpeed = 5f;      // Velocidad de movimiento del cursorTarget
    public Vector2 limitX = new Vector2(-10f, 10f); // Límites en X
    public Vector2 limitY = new Vector2(-5f, 5f);   // Límites en Y

    private float currentFOV;

    void Start()
    {
        FindMainCamera(); // Encuentra la cámara activa al inicio

        if (virtualCamera != null)
        {
            currentFOV = virtualCamera.m_Lens.FieldOfView;
        }
    }

    void Update()
    {
        if (mainCamera == null || !mainCamera.gameObject.activeInHierarchy) 
        {
            FindMainCamera(); // Buscar nueva cámara si cambia
        }

        if (mainCamera == null || virtualCamera == null || cursorTarget == null) return;

        HandleZoom();
        MoveCursorTarget();
    }

    void FindMainCamera()
    {
        mainCamera = Camera.main; // Encuentra automáticamente la nueva cámara principal
        if (mainCamera == null)
        {
            Debug.LogWarning("No se encontró una cámara principal activa.");
            return;
        }

        // Cuando cambiamos de cámara, aseguramos que la CinemachineVirtualCamera sigue funcionando
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.FieldOfView = currentFOV; // Restaurar el FOV al nuevo cambio de cámara
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Detecta la rueda del ratón
        if (scroll != 0)
        {
            currentFOV -= scroll * zoomSpeed * 10f;
            currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, currentFOV, Time.deltaTime * 10f);
        }
    }

    void MoveCursorTarget()
    {
        Vector3 targetPosition = GetMouseWorldPosition();
        targetPosition.x = Mathf.Clamp(targetPosition.x, limitX.x, limitX.y); // Limita en X
        targetPosition.y = Mathf.Clamp(targetPosition.y, limitY.x, limitY.y); // Limita en Y

        cursorTarget.position = Vector3.Lerp(cursorTarget.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null) return Vector3.zero;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(mainCamera.transform.forward, virtualCamera.transform.position + virtualCamera.transform.forward * 10f);

        if (plane.Raycast(ray, out float distanceToPlane))
        {
            return ray.GetPoint(distanceToPlane);
        }

        return Vector3.zero;
    }
}
