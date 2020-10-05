using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Preferences
{
    class СustomizableObjects
    {
        public Window window { get; set; }
        public Grid mainGrid { get; set; }
        public WrapPanel filesViewer { get; set; }

        public Label name { get; set; }
        public TextBox editableName { get; set; }

        public СustomizableObjects() { }

        public СustomizableObjects(Window window, Grid mainGrid ,WrapPanel filesViewer, Label name, TextBox editableName)
        {
            this.window = window;
            this.mainGrid = mainGrid;
            this.filesViewer = filesViewer;
            this.name = name;
            this.editableName = editableName;
        }

    }
}
