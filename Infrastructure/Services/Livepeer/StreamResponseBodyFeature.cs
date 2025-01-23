namespace LivepeerTest.Infrastructure.Services.Livepeer
{

    public class StreamResponseBodyFeature
    {
        public long LastSeen { get; set; }
        public bool IsActive { get; set; }
        public bool Record { get; set; }
        public bool Suspended { get; set; }
        public int SourceSegments { get; set; }
        public int TranscodedSegments { get; set; }
        public int SourceSegmentsDuration { get; set; }
        public int TranscodedSegmentsDuration { get; set; }
        public int SourceBytes { get; set; }
        public int TranscodedBytes { get; set; }
        public object LastTerminatedAt { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public long CreatedAt { get; set; }
        public string StreamKey { get; set; }
        public string PlaybackId { get; set; }
        public string CreatedByTokenName { get; set; }
    }
}