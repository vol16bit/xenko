// Copyright (c) 2016-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

namespace SiliconStudio.Xenko.Input
{
    /// <summary>
    /// Describes a button on a mouse changing state
    /// </summary>
    public class MouseButtonEvent : ButtonEvent
    {
        /// <summary>
        /// The button that changed state
        /// </summary>
        public MouseButton Button;

        /// <summary>
        /// The mouse that sent this event
        /// </summary>
        public IMouseDevice Mouse => (IMouseDevice)Device;

        public override string ToString()
        {
            return $"{nameof(Button)}: {Button}, {nameof(IsDown)}: {IsDown}, {nameof(Mouse)}: {Mouse.Name}";
        }
    }
}