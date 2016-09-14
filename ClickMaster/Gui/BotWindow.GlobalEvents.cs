/*
 * This file is part of the project ClickMaster, licensed under the
 * Creative Commons Attribution-NoDerivatives 4.0 International license.
 * 
 * Copyright (c) 2016 Justin Vogel <dernoki77@gmail.com>
 * 
 * You should have received a copy of the license along with this
 * work. If not, see <http://creativecommons.org/licenses/by-nd/4.0/>.
 * 
 * THIS SOFTWARE IS PROVIDED UNDER THE TERMS
 * OF THIS CREATIVE COMMONS PUBLIC LICENSE ("CCPL" OR "LICENSE").
 * THE SOFTWARE IS PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW.
 * ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE
 * OR COPYRIGHT LAW IS PROHIBITED.
 * 
 * BY EXERCISING ANY RIGHTS TO THE SOFTWARE PROVIDED HERE,
 * YOU ACCEPT AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE.
 * TO THE EXTENT THIS LICENSE MAY BE CONSIDERED TO BE A CONTRACT,
 * THE LICENSOR GRANTS YOU THE RIGHTS CONTAINED HERE IN CONSIDERATION
 * OF YOUR ACCEPTANCE OF SUCH TERMS AND CONDITIONS.
 */

using Gma.UserActivityMonitor;
using System;
using System.Windows.Forms;
namespace ClickMaster.Gui {
    partial class BotWindow : Form {

        private void GlobalMouseMove(object sender, MouseEventArgs e) {
            this.MouseXSpinner.Value = e.X;
            this.MouseYSpinner.Value = e.Y;
        }

        private void GlobalMouseUp(object sender, MouseEventArgs e) {
            this.MouseXSpinner.Value = e.X;
            this.MouseYSpinner.Value = e.Y;
            HookManager.MouseMove -= this.GlobalMouseMove;
            HookManager.MouseUp -= this.GlobalMouseUp;

            if (!this.ContainsFocus) {
                this.Activate();
                //WinApiUtil.SetForegroundWindow(this.Handle);
            }
        }

        private void GlobalKeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == this.StartKey) {
                this.StartButton.PerformClick();
            }
        }

    }
}
