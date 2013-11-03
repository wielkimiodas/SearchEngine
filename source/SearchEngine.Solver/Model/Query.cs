namespace SearchEngine.Solver.Model
{
    public sealed class Query : TfidfBase
    {
        public Query(string query)
            : base(query)
        {
        }
    }
}