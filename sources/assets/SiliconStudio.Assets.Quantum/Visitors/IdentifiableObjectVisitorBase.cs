﻿// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using SiliconStudio.Core;
using SiliconStudio.Core.Annotations;
using SiliconStudio.Core.Extensions;
using SiliconStudio.Quantum;

namespace SiliconStudio.Assets.Quantum.Visitors
{
    /// <summary>
    /// A visitor that allows specific handling of all <see cref="IIdentifiable"/> instances visited, whether they are object references of not.
    /// </summary>
    public abstract class IdentifiableObjectVisitorBase : AssetGraphVisitorBase
    {
        /// <summary>
        /// Initializes a new instance of hte <see cref="IdentifiableObjectVisitorBase"/> class.
        /// </summary>
        /// <param name="propertyGraph">The <see cref="AssetPropertyGraph"/> used to analyze object references.</param>
        protected IdentifiableObjectVisitorBase(AssetPropertyGraph propertyGraph)
            : base(propertyGraph)
        {
        }

        /// <inheritdoc/>
        protected override void VisitMemberTarget(IMemberNode node)
        {
            CheckAndProcessIdentifiableMember(node);
            base.VisitMemberTarget(node);
        }

        /// <inheritdoc/>
        protected override void VisitItemTargets(IObjectNode node)
        {
            node.ItemReferences?.ForEach(x => CheckAndProcessIdentifiableItem(node, x.Index));
            base.VisitItemTargets(node);
        }

        /// <summary>
        /// Processes an <see cref="IIdentifiable"/> instance that is a member of an object.
        /// </summary>
        /// <param name="identifiable">The identifiable instance to process.</param>
        /// <param name="member">The member node referencing the identifiable instance.</param>
        protected abstract void ProcessIdentifiableMembers([NotNull] IIdentifiable identifiable, IMemberNode member);

        /// <summary>
        /// Processes an <see cref="IIdentifiable"/> instance that is an item of a collection.
        /// </summary>
        /// <param name="identifiable">The identifiable instance to process.</param>
        /// <param name="collection">The object node representing the collection referencing the identifiable instance.</param>
        /// <param name="index">The index at which the identifiable instance is referenced.</param>
        protected abstract void ProcessIdentifiableItems([NotNull] IIdentifiable identifiable, IObjectNode collection, Index index);

        private void CheckAndProcessIdentifiableMember(IMemberNode member)
        {
            var identifiable = member.Retrieve() as IIdentifiable;
            if (identifiable == null)
                return;

            ProcessIdentifiableMembers(identifiable, member);
        }

        private void CheckAndProcessIdentifiableItem(IObjectNode collection, Index index)
        {
            var identifiable = collection.Retrieve(index) as IIdentifiable;
            if (identifiable == null)
                return;

            ProcessIdentifiableItems(identifiable, collection, index);
        }
    }
}
