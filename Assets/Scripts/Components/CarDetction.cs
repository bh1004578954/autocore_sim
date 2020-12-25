#region License
/*
 * Copyright 2020 Autoware Foundation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Authors: AutoCore Members
 *
 */
#endregion



using Assets.Scripts.simController;
using Assets.Scripts.SimuUI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CarDetction : MonoBehaviour
    {
        private Transform parent;
        private void OnEnable()
        {
            parent = GetComponentInParent<EgoVehicleController>().transform;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("RoadEdge"))
            {
                PanelOther.Instance.SetTipText(parent.name+ "Collision with road curb");
                TestManager.Instance.DataManager.WriteTestData(parent.name + "Collision with road curb，location:" + parent.position);
            }
            else if (other.gameObject.CompareTag("Car") && other.gameObject.name == "colider")
            {
                PanelOther.Instance.SetTipText(parent.name + "Collision with other vehicle");
                TestManager.Instance.DataManager.WriteTestData(parent.name + "Collision with other vehicle，location:" + parent.position);
            }
            else if (other.gameObject.CompareTag("Human"))
            {
                PanelOther.Instance.SetTipText(parent.name + "Collision with pedestrian");
                TestManager.Instance.DataManager.WriteTestData(parent.name + "Collision with pedestrian，position:" + parent.position);
            }
            else if (other.gameObject.CompareTag("CheckPoint"))
            {
                ReachCheckPoint(other.transform.forward);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                PanelOther.Instance.SetTipText(parent.name + "Collision with Obstacle");
                TestManager.Instance.DataManager.WriteTestData(parent.name + "Collision with Obstacle，position:" + parent.position);
            }
        }
        private int checkTime;
        private List<float> ArrTime = new List<float>();

        public void ReachCheckPoint(Vector3 dicForward)
        {
            checkTime++;
            //CPController.Instance.SwitchCheckPoint();
            ArrTime.Add(Time.time);
            float angel = Vector3.Angle(parent.forward, dicForward);
            PanelOther.Instance.SetTipText("Reach check point");
            TestManager.Instance.DataManager.WriteTestData("Pass check point，ego vehicle angle:" + angel.ToString("0.00") + ",current lap counts:" + checkTime);
        }
    }
}

