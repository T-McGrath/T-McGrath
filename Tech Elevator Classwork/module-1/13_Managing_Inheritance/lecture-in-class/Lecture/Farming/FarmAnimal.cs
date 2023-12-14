namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        private string sound;

        /// <summary>
        /// The farm animal's sound
        /// </summary>
        public string Sound
        {
            get
            {
                if (IsAsleep)
                {
                    return "zzzz...";
                }
                return sound;
            }
            set
            {
                sound = value;
            }
        }

        public bool IsAsleep { get; set; }

        public abstract string Eat();


        public FarmAnimal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
    }
}
