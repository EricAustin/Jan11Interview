namespace Jan11Interview
{
    public class IndexFinder : IIndexFinder
    {

        public int[] getFirstAndLastFor(int[] arrayToSearch, int target)
        {
            int[] outputData = { -1, -1 };

            if (arrayToSearch == null || arrayToSearch.Length == 0) { return outputData; };

            // iterate through the array
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                // check for the target
                if (arrayToSearch[i] == target)
                {
                    // if the target hasn't been found yet, write it to position 0
                    // if the target has already been found, write it to position 1
                    _ = outputData[0] == -1 ? outputData[0] = i : outputData[1] = i;
                    // this effectively saves the first hit's index to the first position and
                    // updates the second position with every hit's index until it reaches the end of the array
                    // so the last hit is the last time the second position was updated
                }
            }
            return outputData;
        }

        public int[] getFirstAndLastWhile(int[] arrayToSearch, int target)
        {
            // this method searches from the beginning and the end at the same time
            // eliminating the need to iterate through the entire array
            int[] outputData = { -1, -1 };

            if (arrayToSearch == null || arrayToSearch.Length == 0) { return outputData; };

            int firstPositionBeingChecked = 0;
            int lastPositionBeingChecked = arrayToSearch.Length - 1;

            while (true)
            {
                // if the first possibility doesn't match, increment the position checked
                if (arrayToSearch[firstPositionBeingChecked] != target)
                {
                    firstPositionBeingChecked++;
                }
                // if it does match and hasn't already been assigned, assign the index to the first position on the output
                else if (outputData[0] == -1)
                {
                    outputData[0] = firstPositionBeingChecked;
                }
                // this is where we start searching from the back forwards
                // if it doesn't match decrement the position being checked
                if (arrayToSearch[lastPositionBeingChecked] != target)
                {
                    lastPositionBeingChecked--;
                }
                // if it does match and hasn't already been assigned, assign the index to the second position on the output
                else if (outputData[1] == -1)
                {
                    outputData[1] = lastPositionBeingChecked;
                }
                // this is where we check if we should be exiting the loop.
                // if the whole array has been scanned, or if both positions in the output have been updated, stop looking
                if (firstPositionBeingChecked >= lastPositionBeingChecked || (outputData[0] != -1 && outputData[1] != -1))
                {
                    // this covers the case that the last position is found first and there is no first position found
                    if (outputData[0] == -1)
                    {
                        // it just swaps the first and second positions so that it will always return the first position
                        // found as first and -1 as last
                        Array.Reverse(outputData);
                    }
                    break;
                }
            }
            return outputData;
        }
    }
};
