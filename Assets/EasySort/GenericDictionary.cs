using System.Collections.Generic;

public class GenericDictionary<T1, T2> : Dictionary<T1, T2>
{
	private Dictionary<string, object> _dict = new Dictionary<string, object>();

	public void Add<T>(string key, T value) where T : class
	{
		_dict.Add(key, value);
	}

	public T GetValue<T>(string key) where T : class
	{
		return _dict[key] as T;
	}
}