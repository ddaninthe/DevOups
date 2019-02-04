using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AppConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //check that data input is valid if command is CHECK
                if (args[0] == "check")
                {
                    if (Check(args))
                    {
                        Console.WriteLine("data is valid");
                    } 
                    else
                    {
                        // TODO
                        Console.WriteLine("Error");
                    }
                }
                else if (args[0] == "fill")
                {
                    Console.WriteLine(Fill(args));
                }
            }
            else
            {
                Console.WriteLine("valid commands are [check],[fill]");
            }
        }

        // TODO: Refactor dictionnaries check

        public static bool Check(string[] args) // TODO: several args
        {
            if (args.Length < 2)
            {
                throw new MissingArgumentException("Check", 2);
            }

            var lines = File.ReadAllLines(args[1]);
            //first line is the header
            var header = lines[0].Split(":".ToCharArray());
            //if it is data for template of type "register-confirmation"
            if (header[0] == "template" && header[1] == "register-confirmation")
            {
                var body = lines.Skip(1);
                //the list of the mandatory keys
                Dictionary<string, bool> dic = new Dictionary<string, bool> {
                        { "name",false },
                        { "title", false },
                        { "mail",false },
                        { "code",false }
                    };
                //then try to find if the keys are present in the data
                foreach (var line in body)
                {
                    var pair = line.Split(":".ToCharArray());
                    var key = pair[0].Trim();
                    //if key is present then it's ok, 
                    if (dic.ContainsKey(key))
                    {
                        //mark it true
                        dic[key] = true;
                    }
                }
                //if there is at least one false value remaining then error
                if (dic.Any(x => !x.Value))
                {
                    throw new InvalidDataException();
                }
                else return true;
            }
            else
            {
                //it's not a valid data file
                throw new InvalidFileException(header[0] + header[1]);
            }
        }

        public static string Fill(string[] args) // TODO: several args
        {
            if (args.Length < 3) throw new MissingArgumentException("Fill", 3);

            var lines = File.ReadAllLines(args[1]);
            //first line is the header
            var header = lines[0].Split(":".ToCharArray());
            //if it is data for template of type "register-confirmation"
            if (header[0] == "template" && header[1] == "register-confirmation")
            {
                var content = File.ReadAllText(args[2]);
                var body = lines.Skip(1);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                Dictionary<string, string> dic3 = new Dictionary<string, string> {
                        {"datetime",DateTime.Now.ToString()},
                        {"website","http://thelightsabersguild.com"}
                    };
                //then add all the keys found to a dictionary of values
                foreach (var line in body)
                {
                    var pair = line.Split(":".ToCharArray());
                    var key = pair[0].Trim();
                    var value = pair[1];
                    //if key is present then it's ok, 
                    if (dic.ContainsKey(key))
                    {
                        //mark it true
                        dic[key] = value;
                    }
                    else
                    {
                        dic.Add(key, value);
                    }
                }

                //then replace the values
                foreach (var keyvalue in dic)
                {
                    content = content.Replace("{{" + keyvalue.Key + "}}", keyvalue.Value);
                }
                //and replace the special function keys
                foreach (var funcvalue in dic3)
                {
                    content = content.Replace("{{=" + funcvalue.Key + "}}", funcvalue.Value);
                }

                return content;
            }
            else
            {
                //it's not a valid data template
                throw new InvalidTemplateException();
            }
        }
    }

    [Serializable]
    public class MissingArgumentException: Exception
    {
        public MissingArgumentException(string functionName, int minArguments)
            : base(String.Format("Method '{0}' needs {1} arguments", functionName, minArguments))
        {
            
        }
    }

    public interface IFileException
    {

    }

    [Serializable]
    public class InvalidFileException : Exception, IFileException
    {
        public InvalidFileException(string filePath)
            : base(String.Format("Invalid file path: '{0}'", filePath))
        {

        }
    }

    [Serializable]
    public class InvalidDataException : Exception, IFileException
    {
        public InvalidDataException()
            : base("Invalid data input")
        {

        }
    }

    [Serializable]
    public class InvalidTemplateException : Exception, IFileException
    {
        public InvalidTemplateException()
         : base("Can't fill a template with invalid data")
        {

        }
    }
}
