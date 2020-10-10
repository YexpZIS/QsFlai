using QsFlai.Animations.Colors;
using QsFlai.Animations.GridSize;
using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QsFlai.VirtualFolderModuls
{
    class AnimationGridController
    {
        private ElementSizeChanger elementSize;
        private ColorChanger colorChanger;
        private Gap settingsCopy;

        private UIElement element;

        private Size InitialScale;

        public AnimationGridController(Gap settings, UIElement element, UIElement color, MenuItem button)
        {
            // создать дубликат settings при сожранении 
            // может потерятся Inital width т.к. мы ее изменяем (this.Meshure)(deepcopy)

            // заменить упоминание об UI елементах на обобщение UIElements например вместо Grid

            this.element = element;
            this.settingsCopy = settings.DeepCopy();

            InitialScale = settings.Scale.Initial;

            elementSize = new ElementSizeChanger(ref settingsCopy, element);
            colorChanger = new ColorChanger(settingsCopy, settingsCopy.editMode);

            // События меняющие размер элемента
            elementSize.sizeChanged += Size_Changed;
            element.MouseEnter += Element_MouseEnter;
            element.MouseLeave += Element_MouseLeave;

            // Пользователь меняет рамер элемента по нажатию кнопки
            button.Click += edit_Click;
            // Устанавливаем цвет элемента, который будет менять цвет
            (color as Grid).Background = colorChanger.GetBrush();
        }

        /// <summary>
        /// Если после того, как закончиласть анимация 
        /// увеличения Grid курсор не находится в Grid,
        /// то окно сворачивается
        /// </summary>
        private void Size_Changed()
        {
            if (element.IsMouseOver || isEditable())
            {
                elementSize.setSize(SizeState.Max);
            }
            else
            {
                elementSize.setSize(SizeState.Min);
            }
        }
        private bool isEditable()
        {
            return settingsCopy.Scale.Initial != InitialScale;
        }

        /// <summary>
        /// Когда курсор находится внутри Grid, то окно 
        /// увеличивается в размере до settings.Scale.Final
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_MouseEnter(object sender, MouseEventArgs e)
        {
            elementSize.setSize(SizeState.Max);
        }
        /// <summary>
        /// Когда курсор выходит из области Grid, то окно
        /// уменьшается в размерах до settings.Scale.Initial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            elementSize.setSize(SizeState.Min);
        }
        
        
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (isEditable()) 
            {
                colorChanger.Stop(); // Останавливает анимацию. Выход из режима редактирования
                settingsCopy.Scale.Initial = InitialScale;
                Size_Changed();
            }
            else
            {
                settingsCopy.Scale.Initial = settingsCopy.Scale.Final; // Делаем окно однго размера. Указываем одинаковые размеры для начального и конечного размера окон.
                elementSize.setSize(SizeState.Max);
                colorChanger.Begin(); // Запускает анимацию. Информирование пользователя о том, что окно находиться в режиме редактирования
            }
        }

        public void changeSize(Size size)
        {
            settingsCopy.Scale.Initial = size;
            settingsCopy.Scale.Final = size;
            elementSize.setSizeUnchecked(SizeState.Max);
        }
    }
}
