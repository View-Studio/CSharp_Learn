using System;

namespace Hello
{
    class MainApp
    {

        enum Result : int
        {
            YES = 1004,
            NO,
            CANCEL,
            CONFIRM,
            OK
        }

        static void Main(string[] args) // EntryPoint
        {
            string formattingStr = string.Format("공학: {0:D5}", "123");

            Console.WriteLine(formattingStr);
        }
    }
}
