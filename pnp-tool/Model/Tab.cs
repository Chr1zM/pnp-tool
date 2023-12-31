﻿using GalaSoft.MvvmLight.Command;
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
        /* Model Attributes */
        public string Title { get; set; }
        public object Content { get; set; }

        public Tab(string title, object content)
        {
            Title = title;
            Content = content;
        }
    }
}
