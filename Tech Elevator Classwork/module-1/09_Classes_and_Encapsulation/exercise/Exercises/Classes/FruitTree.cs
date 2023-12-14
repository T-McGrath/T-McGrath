namespace Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if(PiecesOfFruitLeft >= numberOfPiecesToRemove)
            {
                PiecesOfFruitLeft -= numberOfPiecesToRemove;
                return true;
            }
            else
            {
                return false;
            }
        }      
    }
}
