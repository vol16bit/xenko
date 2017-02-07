﻿// Copyright (c) 2017 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using SiliconStudio.Core.Annotations;
using SiliconStudio.Core.IO;

namespace SiliconStudio.Assets
{
    public interface IAssetFinder
    {
        /// <summary>
        /// Finds an asset by its identifier.
        /// </summary>
        /// <param name="assetId">The identifier of the asset.</param>
        /// <returns>The corresponding <see cref="AssetItem" /> if found; otherwise, <c>null</c>.</returns>
        [CanBeNull]
        AssetItem FindAsset(AssetId assetId);

        /// <summary>
        /// Finds an asset by its location.
        /// </summary>
        /// <param name="location">The location of the asset.</param>
        /// <returns>The corresponding <see cref="AssetItem" /> if found; otherwise, <c>null</c>.</returns>
        [CanBeNull]
        AssetItem FindAsset([NotNull] UFile location);

        /// <summary>
        /// Finds an asset from an attached reference.
        /// </summary>
        /// <param name="container">The object containing the attached reference.</param>
        /// <returns>The corresponding <see cref="AssetItem" /> if found; otherwise, <c>null</c>.</returns>
        [CanBeNull]
        AssetItem FindAssetFromAttachedReference([CanBeNull] object container);
    }
}
