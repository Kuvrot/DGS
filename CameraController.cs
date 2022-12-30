using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    
    public float speed = 0.5f;
    public bool moving , sprinting;
   [Header("Normal field of view")]
    public float minFieldOfView = 40;
    [Header("Field of view when running")]
    public float maxFieldOfView = 60;
    Animator anim;

    public InputAction sprint , moving_forward;


    //current field of view that will oscile between the two variables above
    float currFOV;


   public CinemachineVirtualCamera _cam;

    // Start is called before the first frame update
    private void Awake()
    {
        _cam = this.GetComponent<CinemachineVirtualCamera>();

        if (_cam == null)
        {
            _cam = this.GetComponent<CinemachineVirtualCamera>();
        }

        anim = GetComponent<Animator>();

    }


    private void OnEnable()
    {


        sprint.Enable();
        moving_forward.Enable();

        _cam = this.GetComponent<CinemachineVirtualCamera>();

        if (_cam == null)
        {
            _cam = this.GetComponent<CinemachineVirtualCamera>();
        }
    }

    private void OnDisable()
    {
        sprint.Disable();
        moving_forward.Disable();
    }

    // Update is called once per frame
    void Update()
    {


         anim.SetBool("sprint" ,  moving);

        if (sprint.ReadValue<float>()> 0.5f)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }

       if (sprinting && moving_forward.ReadValue<float>() > 0f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            if (currFOV < maxFieldOfView)
            {
                currFOV += 50 * Time.deltaTime;
            }
            else
            {
                currFOV = maxFieldOfView;
            }

            

            //currFOV = Mathf.Lerp(maxFieldOfView , minFieldOfView , 10f * Time.deltaTime);
        }
        else
        {
            if (currFOV > minFieldOfView)
            {
                currFOV -= 50 * Time.deltaTime;
            }
            else
            {
                currFOV = minFieldOfView;
            }
            //currFOV = Mathf.Lerp(minFieldOfView, maxFieldOfView, 10f * Time.deltaTime);
        }

       
        _cam.m_Lens.FieldOfView = currFOV;

    }
}
