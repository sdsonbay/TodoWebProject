namespace TodoWebProject.Model.Todo
{
    public class GetTodoDataModel
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool UserId { get; set; }
    }
}