// Copyright [2020-2024] Ryodo Tanaka (groadpg@gmail.com) and Akiro Harada
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

using UnitySensors.Interface.Sensor;

namespace UnitySensors.Sensor.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public abstract class CameraSensor : UnitySensor, ICameraInterface
    {
        [SerializeField]
        public Vector2Int _resolution = new Vector2Int(640, 480);
        [SerializeField]
        public float _fov = 30.0f;

        public abstract UnityEngine.Camera m_camera { get; }
    }
}
