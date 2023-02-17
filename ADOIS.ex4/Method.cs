using System;
using static System.Console;

namespace ADOIS.ex4;

class Method
{
    // Object Initialization
    Person n1 = new Person("203ND408", "Nguyen Van A", new DateTime(1987, 12, 01), "Buddha", true, "Viet Nam", "Phu Yen", "Married");
    Person n2 = new Person("224CD105", "Vo Thi B", new DateTime(1991, 04, 08), "Buddha", false, "Viet Nam", "Khanh Hoa", "Married");
    Person n3 = new Person("203ND450", "Le Van C", new DateTime(1995, 01, 15), "Islamic", true, "Viet Nam", "Binh Duong", "Married");
    Person n4 = new Person("223NV567", "Do Thi D", new DateTime(2000, 04, 30), "Islamic", false, "Viet Nam", "Binh Dinh", "Married");
    Person n5 = new Person("223TVB56", "Pham Thi T", new DateTime(2001, 01, 24), "Buddha", false, "Viet Nam", "Phu Yen", "Married");
    Person n6 = new Person("204HBN32", "  Tran H   ", new DateTime(2001, 01, 30), "Buddha", true, "Viet Nam", "Phu Yen", "Married");
    List<Couple> couples = new List<Couple>();

    public void runMain()
    {
        SuccessfulPairing();
        creatMenu();
    }

    private void SuccessfulPairing()
    {
        Couple[] list = new Couple[]
        {
            new Couple("KH102", n1, n2, "Couple"),
            new Couple("KH105", n3, n4, "Couple"),
            new Couple("KH106", n5, n6, "Couple")
        };
        // Add a couple to the system
        couples.AddRange(list);
    }

    private void creatMenu()
    {
        // Welcome
        string str1 = "Welcome to the marriage management program";
        string[] str2 =
        {
            "Print list", "Search", "Delete", "Edit", "Check age", "Exit program"
        };
        Menu mainMenu = new Menu(str1, str2);
        int index = mainMenu.Controller();

        // Decoration interface
        switch (index)
        {
            case 0:
                Write("\nPrint list:");
                printList();
                break;
            case 1:
                Write("\nSearch: ");
                Search();
                break;
            case 2:
                Write("\nDelete: ");
                Delete();
                break;
            case 3:
                Write("\nEdit: ");
                Edit();
                break;
            case 4:
                Write("\nCheck age: ");
                CheckCorrectAgeMarriage();
                break;
            case 5:
                endMain();
                break;
            default:
                break;
        }
    }

    private void comeBack()
    {
        ReadKey(true);
        // Press Enter to cancel
        creatMenu();
    }

    private void endMain()
    {
        WriteLine("\nPress any key to exit ...");
        ReadKey(true);
        Environment.Exit(0);
    }

    private void printList()
    {
        foreach (dynamic venus in couples)
        {
            WriteLine(venus);
        }
        comeBack();
    }

    private void Search()
    {
        var seek = ReadLine();
        foreach (dynamic venus in couples)
        {
            if (venus.searchCouple(seek) == true)
            {
                WriteLine(venus);
            }
            else WriteLine("Not found " + seek);
        }
        comeBack();
    }

    private void Delete()
    {
        var delete = ReadLine();
        foreach (dynamic venus in couples)
        {
            if (venus.deleteCouple(delete) == true)
            {
                WriteLine("Delete successfully");
                couples.Remove(venus);
                Write("\nList after update:");
                printList();
                break;
            }
            else WriteLine("Not found " + delete);
        }
    }

    private void Edit()
    {
        var edit = ReadLine();
        foreach (dynamic venus in couples)
        {
            if (venus.editCouple(edit) == true)
            {
                Clear();
                Write("\n1.Edit couple information");
                Write("\n2.Register for divorce");
                Write("\n0.Exit");
                Write("\nEnter selection: ");
                int menu = Convert.ToInt32(ReadLine());
                switch (menu)
                {
                    case 0:
                        Write("\nPress enter to come back ...");
                        ReadKey(true);
                        Clear();
                        creatMenu();
                        break;
                    case 1:
                        // case 1: Marriage registration code can only be changed
                        Write("\nEnter new code: ");
                        var newCode = ReadLine();
                        venus.RegistrationCode = newCode;
                        Write("\nChange code successfully!!!");
                        goto case 0;
                    case 2:
                        // case 2: Change the relationship from 'Married' to 'Single'
                        // Then remove the couple from the system software
                        venus.Hubby.StatusMarital = "Single";
                        venus.Wife.StatusMarital = "Single";
                        if ((venus.Hubby.StatusMarital == "Single") && (venus.Wife.StatusMarital == "Single"))
                        {
                            Write("\nDivorce certificate accepted");
                            couples.Remove(venus);
                            Thread.Sleep(10);
                            WriteLine(venus);
                        }
                        goto case 0;
                    // After editing them to the original interface select 1 to see the updated list
                    default:
                        Write("\nEnter the wrong format. Please re-enter!!!");
                        break;
                }
            }
            else WriteLine("Not found " + edit);
        } comeBack();
    }

    private void CheckCorrectAgeMarriage()
    {
        foreach (dynamic venus in couples)
        {
            try
            {
                venus.getAge();
            }
            catch (MyException e)
            {
                WriteLine(e.Message);
                WriteLine("Error at location:" + e.StackTrace);
                Write("\nRemoved from the system");
                couples.Remove(venus);
            }
        } comeBack();  
    }
}