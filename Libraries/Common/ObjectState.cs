
namespace Common
{
    public enum ObjectState
	{
        Unchanged,
        Added,
        Modified,
        Deleted
    }

	public interface IObjectState
	{
		ObjectState ObjectState { get; set; }

	}
}
