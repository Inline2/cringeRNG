using System;

namespace rng
{
    class Program
    {
        static void Main(string[] args)
        {
            var rng = new Random();
            var input = "";
            var parse = 0;
            var killMe = 0;
            var overflow = false;
            var dontParse = false;
            Console.WriteLine("Input the highest number possible to generate:"); //outside of the loop so it doesn't spam the console with information you already know
            while(input!="exit") //typing exit breaks out of the program
            {
                input=Console.ReadLine();
                try
                {
                    parse = Int32.Parse(input); //Parses the input to the int variable parse
                    overflow = false;
                    dontParse = false;
                }
                catch(OverflowException) //for int overflows
                {
                    switch (killMe) //counter goes up with int overflows
                    {
                        default:
                            Console.WriteLine("O-onii-chan your number is too large, I don't think it will fit...");
                            break;
                        case 1:
                            Console.WriteLine("I'm not sure about this onii-chan...");
                            break;
                        case 2:
                            Console.WriteLine("Okay if you insist I guess I'll let you...\nUn-!");
                            Int32.Parse(input); //parses it and crashes
                            break;
                    }
                    parse = 0;
                    overflow = true;
                    dontParse = true;
                }
                catch(FormatException) //for non int input
                {
                    if(input!="exit"){
                        Console.WriteLine("Onii-chan, there's no way that non-integers will fit!");
                    }
                    parse = 0;
                    overflow = false;
                    dontParse = true;
                }
                if(!overflow) //code for displaying cringe text
                {
                    killMe = 0;
                }
                else
                {
                    killMe++;
                }
                if(parse!>=0&&!dontParse)
                {
                    Console.WriteLine(rng.Next(parse)); //rng shit using parse as max number
                }
            }
        }
    }
}
