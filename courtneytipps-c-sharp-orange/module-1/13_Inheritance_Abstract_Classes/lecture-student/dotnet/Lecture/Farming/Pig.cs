namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public override string Name { get; } = "Pig";
        public decimal Price { get; }

        public Pig() : base("oink")
        {
            Price = 300;
        }
    }
}
