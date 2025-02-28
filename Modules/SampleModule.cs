using ProsoftERP;

namespace ProsoftERP.SampleModule
{
    public class SampleModule : IModule
    {
        public string Name => "Testowy Moduł";

        public void Initialize()
        {
            Console.WriteLine("Testowy Moduł został załadowany!");
        }
    }


   
}
