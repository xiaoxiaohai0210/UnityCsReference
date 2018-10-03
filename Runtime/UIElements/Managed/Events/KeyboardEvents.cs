// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine.Experimental.UIElements
{
    public abstract class KeyboardEventBase : UIEvent
    {
        public EventModifiers modifiers { get; private set; }
        public char character { get; private set; }
        public KeyCode keyCode { get; private set; }

        public bool shiftKey
        {
            get { return (modifiers & EventModifiers.Shift) != 0; }
        }

        public bool ctrlKey
        {
            get { return (modifiers & EventModifiers.Control) != 0; }
        }

        public bool commandKey
        {
            get { return (modifiers & EventModifiers.Command) != 0; }
        }

        public bool altKey
        {
            get { return (modifiers & EventModifiers.Alt) != 0; }
        }

        // FIXME: see https://www.w3.org/TR/DOM-Level-3-Events/#interface-keyboardevent for key, code and location values.
        public KeyboardEventBase(EventFlags flags, Event systemEvent)
            : base(flags, systemEvent)
        {
            if (systemEvent != null)
            {
                modifiers = systemEvent.modifiers;
                character = systemEvent.character;
                keyCode = systemEvent.keyCode;
            }
        }
    }

    public class KeyDownEvent : KeyboardEventBase
    {
        static readonly long s_EventClassId;

        static KeyDownEvent()
        {
            s_EventClassId = EventBase.RegisterEventClass();
        }

        public override long GetEventTypeId()
        {
            return s_EventClassId;
        }

        public KeyDownEvent()
            : base(EventFlags.Bubbles | EventFlags.Cancellable, null) {}

        public KeyDownEvent(Event systemEvent)
            : base(EventFlags.Bubbles | EventFlags.Cancellable, systemEvent)
        {
        }
    }

    public class KeyUpEvent : KeyboardEventBase
    {
        static readonly long s_EventClassId;

        static KeyUpEvent()
        {
            s_EventClassId = EventBase.RegisterEventClass();
        }

        public override long GetEventTypeId()
        {
            return s_EventClassId;
        }

        public KeyUpEvent()
            : base(EventFlags.Bubbles | EventFlags.Cancellable, null) {}

        public KeyUpEvent(Event systemEvent)
            : base(EventFlags.Bubbles | EventFlags.Cancellable, systemEvent)
        {
        }
    }
}