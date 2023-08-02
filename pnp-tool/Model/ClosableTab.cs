using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pnp_tool.Model
{
    public class ClosableTab : Tab
    {
        /* Event Attributes */
        public event EventHandler CloseRequested;
        public ICommand CloseCommand { get; }

        public ClosableTab(string title, object content) : base(title, content)
        {
            CloseCommand = new ActionCommand(OnCloseRequested);
        }

        private void OnCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
