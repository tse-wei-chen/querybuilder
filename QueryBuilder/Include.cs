namespace SqlKata
{
    public class Include
    {
        public string Name { get; set; }
        public Query Query { get; set; }
        public string ForeignKey { get; set; }
        public string LocalKey { get; set; }
        public bool IsMany { get; set; }

        public Include Clone()
        {
            return new Include
            {
                Name = Name,
                Query = Query.Clone(),
                ForeignKey = ForeignKey,
                LocalKey = LocalKey,
                IsMany = IsMany,
            };
        }
    }
}
