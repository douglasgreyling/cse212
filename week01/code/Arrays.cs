public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array of doubles with size 'length'
        double[] result = new double[length];

        // Loop from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // For each index 'i', calculate the multiple for this iteration in the loop and store it in the result array
            result[i] = number * (i + 1);
        }

        // Return the array of multiples
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // NOTE: To 'rotate' a list to the right by 'amount' means the last 'amount' elements need to move to the front of the list.

        // Find the count of elements in the list.
        int count = data.Count;

        // Get the last 'amount' elements (from count - amount to end).
        List<int> tail = data.GetRange(count - amount, amount);

        // Get the first 'count - amount' elements.
        List<int> head = data.GetRange(0, count - amount);

        // Clear the original list to prepare for reconstruction.
        data.Clear();

        // Add the tail elements (rotated part) first, then add the remaining head elements.
        data.AddRange(tail);
        data.AddRange(head);
    }
}
