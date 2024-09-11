// Copyright [2020-2024] Ryodo Tanaka (groadpg@gmail.com) and Akiro Harada
// SPDX-License-Identifier: Apache-2.0

using Unity.Collections;

namespace UnitySensors.Data.PointCloud
{
    public interface IPointCloudInterface<T> where T : struct, IPointInterface
    {
        public PointCloud<T> pointCloud { get; }
        public int pointsNum { get; }
    }
}