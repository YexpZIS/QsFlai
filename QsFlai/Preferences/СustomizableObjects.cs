using QsFlai.UserControls;
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
        public Image image { get; set; }
        public WrapPanel filesViewer { get; set; }

        public EditableLabel editableName { get; set; }

        public Border border { get; set; }
        public RowDefinition borderHeight { get; set; }

        public СustomizableObjects() { }

        public СustomizableObjects(Window window, Grid mainGrid ,ref Image image ,WrapPanel filesViewer,
            EditableLabel editableName, Border border, RowDefinition borderHeight)
        {
            this.window = window;
            this.mainGrid = mainGrid;
            this.image = image;
            this.filesViewer = filesViewer;
            this.editableName = editableName;
            this.border = border;
            this.borderHeight = borderHeight;
        }

    }
}
