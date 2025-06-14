using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestManagementSystem.Common.Text
{
    public partial class TextBoxControl: Component
    {    
        public TextBoxControl()
        {
            InitializeComponent();
        }

        public TextBoxControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
