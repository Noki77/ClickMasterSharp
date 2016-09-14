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

using ClickMaster.Util;
using System;
using System.Threading;

namespace ClickMaster {
    public class ActionWorker {
        public Thread ParentThread { get; private set; }
        public bool Running { get; private set; } = false;

        public void Restart() {
            Stop();
            Start();
        }

        public void Stop() {
            if (this.Running && this.ParentThread != null && this.ParentThread.IsAlive) {
                this.Running = false;
                this.ParentThread.Abort();
                this.ParentThread.Join();
            }
        }

        public void Start() {
            if (this.Running) {
                Restart();
            } else {
                this.Running = true;
                this.ParentThread = new Thread(this.StartWorking);
                this.ParentThread.Start();
            }
        }

        private void StartWorking() {
            int Iterations = Decimal.ToInt32(BotEntryPoint.Bot.IterationsSpinner.Value);
            int Delay = Decimal.ToInt32(BotEntryPoint.Bot.DelaySpinner.Value);
            if (Iterations > 0) {
                for (int i = 0; i < Iterations; i++) {
                    if (!this.Running) {
                        break;
                    }

                    PerformActions(Delay);
                    PerformSleep(Delay);
                }

                this.Running = false;
                BotEntryPoint.Bot.Running = false;
            } else {
                while (this.Running) {
                    PerformActions(Delay);
                    PerformSleep(Delay);
                }
            }
        }

        private void PerformSleep(int Delay) {
            if (Delay > 0) {
                Thread.Sleep(Delay);
            }
        }

        public void PerformActions(int Delay) {
            Action[] Actions = (Action[]) BotEntryPoint.Bot.ActionsList.Invoke(
                new TypedInvoker<Action[]>(() => BotEntryPoint.Bot.ActionsList.GetAll()));

            foreach (Action j in Actions) {
                if (j.Type == Action.ActionType.LeftClick || j.Type == Action.ActionType.RightClick) {
                    WinApiUtil.MouseClick(j.Type.ButtonPressed, (uint) j.Location.X, (uint) j.Location.Y);
                } else if (j.Type == Action.ActionType.MouseDownLeft || j.Type == Action.ActionType.MouseDownRight) {
                    WinApiUtil.MouseDown(j.Type.ButtonPressed, (uint) j.Location.X, (uint) j.Location.Y);
                } else if (j.Type == Action.ActionType.MouseUpLeft || j.Type == Action.ActionType.MouseUpRight) {
                    WinApiUtil.MouseUp(j.Type.ButtonPressed, (uint) j.Location.X, (uint) j.Location.Y);
                } else if (j.Type == Action.ActionType.KeyDown) {
                    WinApiUtil.KeyDown(j.Key);
                } else if (j.Type == Action.ActionType.KeyUp) {
                    WinApiUtil.KeyUp(j.Key);
                } else if (j.Type == Action.ActionType.KeyPress) {
                    WinApiUtil.KeyPress(j.Key);
                }

                PerformSleep(Delay);
            }
        }
    }
}
