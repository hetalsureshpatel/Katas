namespace String.Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int result = 0;

            if (!string.IsNullOrEmpty(numbers))
            {
                result = int.Parse(numbers);
            }

            return result;
        }
    }
}