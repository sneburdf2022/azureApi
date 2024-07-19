using Negocio.Entidade.Azure;

namespace Api.Dto
{
    public class CreateWorkItemDto
    {
        public int id { get; set; }
        public string organization { get; set; }
        public string project { get; set; }
        public WorkItem workItemNovo { get; set; }

    }
}
