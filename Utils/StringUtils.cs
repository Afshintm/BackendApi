using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringUtils
    {
	    public static string EncodeToBase64(this string input)
	    {
		    var byteArray = Encoding.UTF8.GetBytes(input);
		    var encodedResult  = Convert.ToBase64String(byteArray);
		    return encodedResult;
	    }

	    public static string DecodeFromBase64(this string input)
	    {
		    var decodedByteArray = Convert.FromBase64String(input);
		    var resultString = Encoding.UTF8.GetString(decodedByteArray);
		    return resultString;
	    }
    }
}
