using System.Collections.Generic;

namespace TwitterRequests.Domain
{

    public partial class Tweets
    {
        public List<Datum> Data { get; set; }
        public Meta Meta { get; set; }
    }

    public partial class Datum
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public partial class Meta
    {
        public string NewestId { get; set; }
        public string OldestId { get; set; }
        public long ResultCount { get; set; }
        public string NextToken { get; set; }
    }
}
