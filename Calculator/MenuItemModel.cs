using System;
using System.Windows.Input;

namespace Calculator;

public class MenuItemModel
{
    public string Text { get; set; } // Text for the menu item
    public ICommand Command { get; set; }


}

