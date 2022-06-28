using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmers
{
	public class MainClass
	{
		static int Main(string[] ss)
		{
#if DEBUG
			ss = new string[] { "one4seveneight" };
#endif		
			string a = ss[0];
			a = a.Replace("zero","0");
			a = a.Replace("one","1");
			a = a.Replace("two","2");
			a = a.Replace("three","3");
			a = a.Replace("four","4");
			a = a.Replace("five","5");
			a = a.Replace("six","6");
			a = a.Replace("seven","7");
			a = a.Replace("eight","8");
			a = a.Replace("nine","9");

			return Convert.ToInt32(a);
		}
	}
}
