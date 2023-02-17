using System;
using static System.Console;

namespace ADOIS.ex4;

// Create the interface of the marriage management program
class Menu
{
    private int indexSelect;
    private string remindCurrent;
    private string[] option;

    public Menu(string remindCurrent, string[] option)
    {
        this.remindCurrent = remindCurrent;
        this.option = option;
        indexSelect = 0;
    }

    private void displayOption()
    {
        WriteLine(remindCurrent);
        for (int i = 0; i < option.Length; i++)
        {
            string optionCurrent = option[i];
            string pointer;

            if (i == indexSelect)
            {
                pointer = "*";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
            else
            {
                pointer = " ";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }

            WriteLine($"{pointer} << {optionCurrent} >>");

            ResetColor();
        }
    }

    // Use interface
    public int Controller()
    {
        ConsoleKey keyPresed;
        do
        {
            Clear();
            displayOption();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPresed = keyInfo.Key;

            if (keyPresed == ConsoleKey.UpArrow)
            {
                indexSelect--;
                if (indexSelect == -1)
                {
                    indexSelect = option.Length - 1;
                }
            }
            else if (keyPresed == ConsoleKey.DownArrow)
            {
                indexSelect++;
                if (indexSelect == option.Length)
                {
                    indexSelect = 0;
                }
            }

        }
        while (keyPresed != ConsoleKey.Enter);

        return indexSelect;
    }

}