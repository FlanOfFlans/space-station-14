﻿using Content.Shared.GameObjects.Components.Power;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Interfaces.Network;

namespace Content.Client.GameObjects.Components.Power
{
    [RegisterComponent]
    public class PowerDebugTool : SharedPowerDebugTool
    {
        SS14Window LastWindow;
        public override void HandleMessage(ComponentMessage message, INetChannel netChannel = null, IComponent component = null)
        {
            base.HandleMessage(message, netChannel, component);

            switch (message)
            {
                case OpenDataWindowMsg msg:
                    if (LastWindow != null && !LastWindow.Disposed)
                    {
                        LastWindow.Dispose();
                    }
                    LastWindow = new SS14Window()
                    {
                        Title = "Power Debug Tool",
                    };
                    LastWindow.Contents.AddChild(new Label() { Text = msg.Data });
                    LastWindow.Open();
                    break;
            }
        }
    }
}
