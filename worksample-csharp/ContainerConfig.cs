using Autofac;
using MultiValueDictionaryLibrary;
using MultiValueDictionaryLibrary.Services;

namespace MultiValueDictionaryUI
{
    public static class  ContainerConfig
    {
        /// <summary>
        /// configure the container for DI
        /// </summary>
        /// <returns></returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DictionaryCommands>().As<IDictionaryCommands>();
            builder.RegisterType<HandleUserInput>().As<IHandleUserInput>();
            builder.RegisterType<ValidateUserInput>().As<IValidateUserInput>();
            builder.RegisterType<WritingService>().As<IWritingService>();


            //stores all the classes I want to register
            return builder.Build();
        }
    }
}
