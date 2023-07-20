using GalaSoft.MvvmLight.Command;
using Microsoft.Xaml.Behaviors.Core;
using pnp_tool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pnp_tool.Model
{
    public class Tab
    {
        /* Statics */
        private static int Id = 1;
        private static int getNextId() { return Id++; }

        /* Event Attributes */
        public event EventHandler CloseRequested;
        public ICommand CloseCommand { get; }

        /* Model Attributes */
        public string Title { get; set; }
        public object Content { get; set; }

        // TODO: use this constructor for giving Tab Name https://github.com/Chr1zM/pnp-tool/issues/11
        public Tab(string title, object content)
        {
            Title = title;
            Content = content;

            CloseCommand = new ActionCommand(OnCloseRequested);
        }

        public Tab(object content)
        {
            Title = "Tab " + getNextId();
            Content = content;

            CloseCommand = new ActionCommand(OnCloseRequested);
        }

        private void OnCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
