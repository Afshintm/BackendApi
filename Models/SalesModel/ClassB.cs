
namespace SalesModel
{
    public interface IClassB
    {
        int Index { get; set; }
        string Lable { get; set; }
        int Id { get; set; }
    }

    public class ClassB: EntityBase, IClassB
    {
        public int Index { get; set; }
        public string Lable { get; set; }
    }
}