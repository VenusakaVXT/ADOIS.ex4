using System;

namespace ADOIS.ex4;

class MyException : Exception
{
    public MyException (string error) : base(error) { }
}