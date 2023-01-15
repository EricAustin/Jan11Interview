namespace Jan11Interview
{
    public interface IIndexFinder
    {
        public int[] getFirstAndLastFor(int[] arrayToSearch, int target);
        public int[] getFirstAndLastWhile(int[] arrayToSearch, int target);
    }
};