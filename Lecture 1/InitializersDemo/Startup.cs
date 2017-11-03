namespace InitializersDemo
{
    using System.Collections.Generic;

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Startup
    {
        private static void Main(string[] args)
        {
            List<string> text = new List<string>();
            text.Add("One");
            text.Add("Two");

            var anotherText = new List<string>()
            {
                "The", "Quick", "Brown", "Fox"
            };

            var p = new Person() { Name = "Ivan", Age = 20 };
        }
    }
}