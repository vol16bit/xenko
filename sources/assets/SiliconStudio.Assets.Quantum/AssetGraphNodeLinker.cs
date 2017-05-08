﻿// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using System.Collections.Generic;
using SiliconStudio.Quantum;

namespace SiliconStudio.Assets.Quantum
{
    public class AssetGraphNodeLinker : GraphNodeLinker
    {
        private readonly AssetPropertyGraph propertyGraph;

        public AssetGraphNodeLinker(AssetPropertyGraph propertyGraph)
        {
            this.propertyGraph = propertyGraph;
        }

        protected override bool ShouldVisitMemberTarget(IMemberNode member)
        {
            return !propertyGraph.Definition.IsMemberTargetObjectReference(member, member.Retrieve()) && base.ShouldVisitMemberTarget(member);
        }

        protected override bool ShouldVisitTargetItem(IObjectNode collectionNode, Index index)
        {
            return !propertyGraph.Definition.IsTargetItemObjectReference(collectionNode, index, collectionNode.Retrieve(index)) && base.ShouldVisitTargetItem(collectionNode, index);
        }
    }
}
