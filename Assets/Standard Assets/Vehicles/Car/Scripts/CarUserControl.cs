using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : Bolt.EntityBehaviour<ITruckState>
    {
        private CarController m_Car; // the car controller we want to use


        public override void Attached()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if (entity.isOwner)
            {
                // pass the input to the car!
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                m_Car.Move(h, v, v, 0f);
            }
        }
    }
}
