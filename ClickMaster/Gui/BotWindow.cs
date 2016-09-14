using Gma.UserActivityMonitor;
using System.Windows.Forms;
namespace ClickMaster.Gui {
    public partial class BotWindow {
        private bool _rng = false;
        public bool Running {
            set {
                if (!value) {
                    this.StartButton.BeginInvoke(new MethodInvoker(() => {
                        this.StartButton.Text = "Start Bot";
                    }));
                } else {
                    this.StartButton.BeginInvoke(new MethodInvoker(() => {
                        this.StartButton.Text = "Stop Bot";
                    }));
                }
                this._rng = value;
            }
            
            get { return this._rng; }
        } 
        private bool IsWatingForPress = false;
        private KeyType KeyToAccept = KeyType.NONE;
        private ActionWorker Worker = new ActionWorker();

        public BotWindow() {
            InitializeComponent();
            Running = false;
            HookManager.KeyUp += this.GlobalKeyUp;
        }

        public void StartBot() {
            if (!this.Running) {
                Worker.Restart();
                this.Running = true;
            }
        }

        public void StopBot() {
            if (this.Running) {
                Worker.Stop();
                this.Running = false;
            }
        }
    }

    enum KeyType {
        KEY_START_STOP, KEY_ADD, NONE
    }
}
