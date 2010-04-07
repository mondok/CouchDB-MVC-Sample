using RedBranch.Hammock;

namespace CouchDbDemo.Sandbox
{
    internal class Program
    {
        private static Session _session;

        private static void Main(string[] args)
        {
            new ClothesExample().Run();

            new PetExample().Run();
        }
    }
}