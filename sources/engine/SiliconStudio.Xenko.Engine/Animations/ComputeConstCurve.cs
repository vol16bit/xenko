// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using SiliconStudio.Core;
using SiliconStudio.Core.Annotations;

namespace SiliconStudio.Xenko.Animations
{
    /// <summary>
    /// A node which describes a constant value for a compute curve
    /// </summary>
    /// <typeparam name="T">Sampled data's type</typeparam>
    [DataContract(Inherited = true)]
    [Display("Constant")]
    [InlineProperty]
    public class ComputeConstCurve<T> : IComputeCurve<T> where T : struct 
    {
        /// <summary>
        /// Constant value to return every time this flat curve is sampled
        /// </summary>
        /// <userdoc>
        /// The constant value to return every time this flat function is sampled
        /// </userdoc>
        [DataMember(10)]
        [Display("Value")]
        [InlineProperty]
        public T Value
        {
            get { return typeValue; }
            set
            {
                typeValue = value;
                hasChanged = true;
            }
        }

        private T typeValue;

        private bool hasChanged = true;
        /// <inheritdoc/>
        public bool UpdateChanges()
        {
            if (hasChanged)
            {
                hasChanged = false;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public T Evaluate(float location)
        {
            return Value;
        }
    }
}
