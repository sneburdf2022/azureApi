namespace Negocio.Entidade.Azure
{
    public class Links
    {
        public Avatar avatar { get; set; }
        public Self self { get; set; }
        public WorkItemUpdates workItemUpdates { get; set; }
        public WorkItemRevisions workItemRevisions { get; set; }
        public WorkItemComments workItemComments { get; set; }
        public Html html { get; set; }
        public WorkItemType workItemType { get; set; }
        public Fields fields { get; set; }
    }
}
