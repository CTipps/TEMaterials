namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public override string Name { get; } = "Cow";
        public decimal Price { get; }

        public Cow() : base("moo")
        {
            Price = 1500;
        }
    }
}
