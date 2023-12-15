namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {
        public Cow() : base("Cow", "moo")
        {
        }

        public override string Eat()
        {
            return "Chewing its cud...";
        }
    }
}
