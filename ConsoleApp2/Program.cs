using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        
    }


}
namespace LibraryProject
{
   
    public class MyBaseClass
    {
        public void PublicMethod()
        {
            Console.WriteLine("Це публічний метод з  простору імен LibraryProject.");
        }
    }
}


namespace MyNamespace
{
    public class MyClass
    {
        public void PublicMethod()
        {
            Console.WriteLine("Це публічний метод з простору імен MyNamespace.");
        }
    }
}
