namespace BusinessDomain.Seedwork
{
    public class MyEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; private set; } = string.Empty;
    }
}
