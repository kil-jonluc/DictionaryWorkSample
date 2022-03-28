using Autofac;
using MultiValueDictionaryLibrary;
using MultiValueDictionaryUI;
using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //holds all the instantiations of classes 
            //Dependency injection
            var container = ContainerConfig.Configure();

            // the multi string diction for the application
            Dictionary<string, List<string>> demoDictionary;

            // lifetime of our container and will dispose it when done using
            using (var scope = container.BeginLifetimeScope())
            {
                var handleInput = scope.Resolve<IHandleUserInput>();
                demoDictionary = new Dictionary<string, List<string>>();

                //the console application will run until its manually closed
                while (true)
                {
                    Console.Write(">");

                    //gather user input 
                    string input = Console.ReadLine();

                    // send data to be handled 
                    handleInput.Handle(demoDictionary, input); 
                }
            }
        }


    }
}
