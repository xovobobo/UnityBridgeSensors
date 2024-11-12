// Copyright [2020-2024] Ryodo Tanaka (groadpg@gmail.com) and Akiro Harada
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnitySensors.Data.PointCloud;

namespace UnitySensors.Sensor.Camera
{
    [BurstCompile]
    public struct ITextureToPointsJob : IJobParallelFor
    {
        public float near;
        public float far;

        [ReadOnly]
        public NativeArray<float3> directions;

        [ReadOnly]
        public NativeArray<Color> depthPixels;
        [ReadOnly]
        public NativeArray<float> noises;

        public NativeArray<PointXYZ> points;

        public void Execute(int index)
        {
            float distance = (1.0f - Mathf.Clamp01(depthPixels.AsReadOnly()[index].r)) * far;
            float distance_noised = distance + noises[index];
            distance = (near < distance && distance < far && near < distance_noised && distance_noised < far) ? distance_noised : 0;

            PointXYZ point = new PointXYZ()
            {
                position = directions[index] * distance
            };
            points[index] = point;
        }
    }
}
