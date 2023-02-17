using System;
using static System.Console;

namespace ADOIS.ex4;

class Person
{
    // Attribute declaration
    private string indentityCard;
    private string name;
    private DateTime birthDay;
    private string religion;
    // Gender return true : male, false : female
    private bool gender;
    private string nationality;
    private string adress;
    private string statusMarital;

    public Person(string indentityCard, string name, DateTime birthDay, string religion
        , bool gender, string nationality, string adress, string statusMarital)
    {
        this.indentityCard = indentityCard;
        this.name = name;
        this.birthDay = birthDay;
        this.religion = religion;
        this.gender = gender;
        this.nationality = nationality;
        this.adress = adress;
        this.statusMarital = statusMarital;
    }

    /// <summary>
    /// Constructor
    /// If you do not have a citizen ID than declare your identity card
    /// </summary>
    public string IndentityCard { get { return indentityCard; } set { indentityCard = value; } }
    public string Name { get { return name; } set { name = value; } }
    public DateTime BirthDay { get { return birthDay; } set { birthDay = value; } }
    public string Religion { get { return religion; } set { religion = value; } }
    public bool Gender { get { return gender; } set { gender = value; } }
    public string Nationality { get { return nationality; } set { nationality = value; } }
    public string Adress { get { return adress; } set { adress = value; } }
    public string StatusMarital { get { return statusMarital; } set { statusMarital = value; } }

    private string Topic()
    {
        return "\nIndentity card\t  Name\t  Birth year\tReligion\tGender\tNationality\tAdress\t\tMarital status";
    }

    private string getGender()
    {
        if (gender == true) return "Male";
        else return "Female";
    }

    public string Display()
    {
        return Topic() + "\n" + indentityCard + "\t" + name + "\t" + birthDay.Year + "\t" + religion + "\t\t"
            + getGender() + "\t" + nationality + "\t" + adress + "\t" + statusMarital;
    }
}
class Couple
{
    // Attribute declaration
    private string registrationCode;
    private Person hubby;
    private Person wife;
    private string relationship;

    public Couple(string registrationCode, Person hubby, Person wife, string relationship)
    {
        this.registrationCode = registrationCode;
        this.hubby = hubby;
        this.wife = wife;
        this.relationship = relationship;
    }

    // Constructor
    public string RegistrationCode { get { return registrationCode; } set { registrationCode = value; } }
    public Person Hubby { get { return hubby; } set { hubby = value; } }
    public Person Wife { get { return wife; } set { wife = value; } }
    public string Relationship { get { return relationship; } set { relationship = value; } }

    // Output()
    // Redefine the ToString() method
    public override string ToString()
    {
        return "\nCode ID: " + registrationCode + "\nHusband:" + hubby.Display() + "\nWife:" + wife.Display()
             + "\nRelationship: " + relationship;
    }

    // Method()
    public bool searchCouple(string seek)
    {
        // Search based on marriage registration code
        if (seek == registrationCode) return true;
        else return false;
    }

    public bool deleteCouple(string delete)
    {
        // Delete with marriage registration code
        if (delete == registrationCode) return true;
        else return false;
    }

    public bool editCouple(string edit)
    {
        // Edit object when entering marriage registration code
        if (edit == registrationCode) return true;
        else return false;
    }

    // Exception()
    public void getAge()
    {
        if ((DateTime.Now.Year - hubby.BirthDay.Year >= 18)
          || (DateTime.Now.Year - wife.BirthDay.Year >= 18))
        {
            Write($"\n{registrationCode} legal age");
        }
        else throw (new MyException($"\n{registrationCode} unlawful age"));
    }
}